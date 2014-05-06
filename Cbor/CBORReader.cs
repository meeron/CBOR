/*
Written by Peter O. in 2014.
Any copyright is dedicated to the Public Domain.
http://creativecommons.org/publicdomain/zero/1.0/
If you like this, you should donate to Peter O.
at: http://upokecenter.com/d/
 */
using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace PeterO.Cbor {
    /// <summary>Description of CBORReader.</summary>
  internal class CBORReader
  {
    private SharedRefs sharedRefs;
    private StringRefs stringRefs;
    private Stream stream;
    private bool addSharedRef;
    private int depth;

    public CBORReader(Stream stream) {
      this.stream = stream;
      this.sharedRefs = new SharedRefs();
    }

    private static long ReadDataLength(Stream s, int headByte, int expectedType) {
      if (headByte < 0) {
        throw new CBORException("Unexpected data encountered");
      }
      if (((headByte >> 5) & 0x07) != expectedType) {
        throw new CBORException("Unexpected data encountered");
      }
      headByte &= 0x1f;
      if (headByte < 24) {
        return headByte;
      }
      byte[] data = new byte[8];
      switch (headByte & 0x1f) {
          case 24: {
            int tmp = s.ReadByte();
            if (tmp < 0) {
              throw new CBORException("Premature end of data");
            }
            return tmp;
          }
          case 25: {
            if (s.Read(data, 0, 2) != 2) {
              throw new CBORException("Premature end of data");
            }
            int lowAdditional = ((int)(data[0] & (int)0xff)) << 8;
            lowAdditional |= (int)(data[1] & (int)0xff);
            return lowAdditional;
          }
          case 26: {
            if (s.Read(data, 0, 4) != 4) {
              throw new CBORException("Premature end of data");
            }
            long uadditional = ((long)(data[0] & (long)0xff)) << 24;
            uadditional |= ((long)(data[1] & (long)0xff)) << 16;
            uadditional |= ((long)(data[2] & (long)0xff)) << 8;
            uadditional |= (long)(data[3] & (long)0xff);
            return uadditional;
          }
          case 27: {
            if (s.Read(data, 0, 8) != 8) {
              throw new CBORException("Premature end of data");
            }
            // Treat return value as an unsigned integer
            long uadditional = ((long)(data[0] & (long)0xff)) << 56;
            uadditional |= ((long)(data[1] & (long)0xff)) << 48;
            uadditional |= ((long)(data[2] & (long)0xff)) << 40;
            uadditional |= ((long)(data[3] & (long)0xff)) << 32;
            uadditional |= ((long)(data[4] & (long)0xff)) << 24;
            uadditional |= ((long)(data[5] & (long)0xff)) << 16;
            uadditional |= ((long)(data[6] & (long)0xff)) << 8;
            uadditional |= (long)(data[7] & (long)0xff);
            return uadditional;
          }
        case 28:
        case 29:
        case 30:
          throw new CBORException("Unexpected data encountered");
        case 31:
          throw new CBORException("Indefinite-length data not allowed here");
        default:
          return headByte;
      }
    }

    internal static BigInteger ToUnsignedBigInteger(long val) {
      BigInteger lval = (BigInteger)(val & ~(1L << 63));
      if ((val >> 63) != 0) {
        BigInteger bigintAdd = BigInteger.One << 63;
        lval += (BigInteger)bigintAdd;
      }
      return lval;
    }

    private static byte[] ReadByteData(Stream s, long uadditional, Stream outputStream) {
      if ((uadditional >> 63) != 0 || uadditional > Int32.MaxValue) {
        throw new CBORException("Length " + ToUnsignedBigInteger(uadditional) + " is bigger than supported");
      }
      if (uadditional <= 0x10000) {
        // Simple case: small size
        byte[] data = new byte[(int)uadditional];
        if (s.Read(data, 0, data.Length) != data.Length) {
          throw new CBORException("Premature end of stream");
        }
        if (outputStream != null) {
          outputStream.Write(data, 0, data.Length);
          return null;
        } else {
          return data;
        }
      } else {
        byte[] tmpdata = new byte[0x10000];
        int total = (int)uadditional;
        if (outputStream != null) {
          while (total > 0) {
            int bufsize = Math.Min(tmpdata.Length, total);
            if (s.Read(tmpdata, 0, bufsize) != bufsize) {
              throw new CBORException("Premature end of stream");
            }
            outputStream.Write(tmpdata, 0, bufsize);
            total -= bufsize;
          }
          return null;
        } else {
          using (var ms = new MemoryStream()) {
            while (total > 0) {
              int bufsize = Math.Min(tmpdata.Length, total);
              if (s.Read(tmpdata, 0, bufsize) != bufsize) {
                throw new CBORException("Premature end of stream");
              }
              ms.Write(tmpdata, 0, bufsize);
              total -= bufsize;
            }
            return ms.ToArray();
          }
        }
      }
    }

    /// <summary>Not documented yet.</summary>
    /// <param name='filter'>A CBORTypeFilter object.</param>
    /// <returns>A CBORObject object.</returns>
    public CBORObject Read(
      CBORTypeFilter filter) {
      if (this.depth > 1000) {
        throw new CBORException("Too deeply nested");
      }
      int firstbyte = this.stream.ReadByte();
      if (firstbyte < 0) {
        throw new CBORException("Premature end of data");
      }
      return this.ReadForFirstByte(firstbyte, filter);
    }

    /// <summary>Not documented yet.</summary>
    /// <param name='firstbyte'>A 32-bit signed integer.</param>
    /// <param name='filter'>A CBORTypeFilter object.</param>
    /// <returns>A CBORObject object.</returns>
    public CBORObject ReadForFirstByte(
      int firstbyte,
      CBORTypeFilter filter) {
      if (this.depth > 1000) {
        throw new CBORException("Too deeply nested");
      }
      if (firstbyte < 0) {
        throw new CBORException("Premature end of data");
      }
      if (firstbyte == 0xff) {
        throw new CBORException("Unexpected break code encountered");
      }
      int type = (firstbyte >> 5) & 0x07;
      int additional = firstbyte & 0x1f;
      int expectedLength = CBORObject.ExpectedLengths[firstbyte];
      // Data checks
      if (expectedLength == -1) {
        // if the head byte is invalid
        throw new CBORException("Unexpected data encountered");
      }
      if (filter != null) {
        // Check for valid major types if asked
        if (!filter.MajorTypeMatches(type)) {
          throw new CBORException("Unexpected data type encountered");
        }
        if (firstbyte >= 0xe0 && firstbyte <= 0xff && firstbyte != 0xf9 && firstbyte != 0xfa && firstbyte != 0xfb) {
          if (!filter.NonFPSimpleValueAllowed()) {
            throw new CBORException("Unexpected data type encountered");
          }
        }
      }
      // Check if this represents a fixed object
      CBORObject fixedObject = CBORObject.GetFixedObject(firstbyte);
      if (fixedObject != null) {
        return fixedObject;
      }
      // Read fixed-length data
      byte[] data = null;
      if (expectedLength != 0) {
        data = new byte[expectedLength];
        // include the first byte because GetFixedLengthObject
        // will assume it exists for some head bytes
        data[0] = unchecked((byte)firstbyte);
        if (expectedLength > 1 &&
            this.stream.Read(data, 1, expectedLength - 1) != expectedLength - 1) {
          throw new CBORException("Premature end of data");
        }
        CBORObject cbor = CBORObject.GetFixedLengthObject(firstbyte, data);
        if (this.stringRefs != null && (type == 2 || type == 3)) {
          this.stringRefs.AddStringIfNeeded(cbor, expectedLength - 1);
        }
        if (this.addSharedRef && (type == 4 || type == 5)) {
          this.sharedRefs.AddObject(cbor);
        }
        return cbor;
      }
      long uadditional = (long)additional;
      BigInteger bigintAdditional = BigInteger.Zero;
      bool hasBigAdditional = false;
      data = new byte[8];
      int lowAdditional = 0;
      switch (firstbyte & 0x1f) {
          case 24: {
            int tmp = this.stream.ReadByte();
            if (tmp < 0) {
              throw new CBORException("Premature end of data");
            }
            lowAdditional = tmp;
            uadditional = lowAdditional;
            break;
          }
          case 25: {
            if (this.stream.Read(data, 0, 2) != 2) {
              throw new CBORException("Premature end of data");
            }
            lowAdditional = ((int)(data[0] & (int)0xff)) << 8;
            lowAdditional |= (int)(data[1] & (int)0xff);
            uadditional = lowAdditional;
            break;
          }
          case 26: {
            if (this.stream.Read(data, 0, 4) != 4) {
              throw new CBORException("Premature end of data");
            }
            uadditional = ((long)(data[0] & (long)0xff)) << 24;
            uadditional |= ((long)(data[1] & (long)0xff)) << 16;
            uadditional |= ((long)(data[2] & (long)0xff)) << 8;
            uadditional |= (long)(data[3] & (long)0xff);
            break;
          }
          case 27: {
            if (this.stream.Read(data, 0, 8) != 8) {
              throw new CBORException("Premature end of data");
            }
            if ((((int)data[0]) & 0x80) != 0) {
              // Won't fit in a signed 64-bit number
              byte[] uabytes = new byte[9];
              uabytes[0] = data[7];
              uabytes[1] = data[6];
              uabytes[2] = data[5];
              uabytes[3] = data[4];
              uabytes[4] = data[3];
              uabytes[5] = data[2];
              uabytes[6] = data[1];
              uabytes[7] = data[0];
              uabytes[8] = 0;
              hasBigAdditional = true;
              bigintAdditional = new BigInteger((byte[])uabytes);
            } else {
              uadditional = ((long)(data[0] & (long)0xff)) << 56;
              uadditional |= ((long)(data[1] & (long)0xff)) << 48;
              uadditional |= ((long)(data[2] & (long)0xff)) << 40;
              uadditional |= ((long)(data[3] & (long)0xff)) << 32;
              uadditional |= ((long)(data[4] & (long)0xff)) << 24;
              uadditional |= ((long)(data[5] & (long)0xff)) << 16;
              uadditional |= ((long)(data[6] & (long)0xff)) << 8;
              uadditional |= (long)(data[7] & (long)0xff);
            }
            break;
          }
        default:
          break;
      }
      // The following doesn't check for major types 0 and 1,
      // since all of them are fixed-length types and are
      // handled in the call to GetFixedLengthObject.
      if (type == 2) {  // Byte string
        if (additional == 31) {
          // Streaming byte string
          using (MemoryStream ms = new MemoryStream()) {
            // Requires same type as this one
            while (true) {
              int nextByte = this.stream.ReadByte();
              if (nextByte == 0xff) {
                // break if the "break" code was read
                break;
              }
              long len = ReadDataLength(this.stream, nextByte, 2);
              if ((len >> 63) != 0 || len > Int32.MaxValue) {
                throw new CBORException("Length " + ToUnsignedBigInteger(len) + " is bigger than supported");
              }
              if (nextByte != 0x40) {  // NOTE: 0x40 means the empty byte string
                ReadByteData(this.stream, len, ms);
              }
            }
            if (ms.Position > Int32.MaxValue) {
              throw new CBORException("Length of bytes to be streamed is bigger than supported");
            }
            data = ms.ToArray();
            return new CBORObject(
              CBORObject.CBORObjectTypeByteString,
              data);
          }
        } else {
          if (hasBigAdditional) {
            throw new CBORException("Length of " +
                                    CBORUtilities.BigIntToString(bigintAdditional) +
                                    " is bigger than supported");
          } else if (uadditional > Int32.MaxValue) {
            throw new CBORException("Length of " +
                                    Convert.ToString((long)uadditional, CultureInfo.InvariantCulture) +
                                    " is bigger than supported");
          }
          data = ReadByteData(this.stream, uadditional, null);
          CBORObject cbor = new CBORObject(CBORObject.CBORObjectTypeByteString, data);
          if (this.stringRefs != null) {
            int hint = (uadditional > Int32.MaxValue || hasBigAdditional) ? Int32.MaxValue :
              (int)uadditional;
            this.stringRefs.AddStringIfNeeded(cbor, hint);
          }
          return cbor;
        }
      } else if (type == 3) {  // Text string
        if (additional == 31) {
          // Streaming text string
          StringBuilder builder = new StringBuilder();
          while (true) {
            int nextByte = this.stream.ReadByte();
            if (nextByte == 0xff) {
              // break if the "break" code was read
              break;
            }
            long len = ReadDataLength(this.stream, nextByte, 3);
            if ((len >> 63) != 0 || len > Int32.MaxValue) {
              throw new CBORException("Length " + ToUnsignedBigInteger(len) + " is bigger than supported");
            }
            if (nextByte != 0x60) {  // NOTE: 0x60 means the empty string
              switch (DataUtilities.ReadUtf8(this.stream, (int)len, builder, false)) {
                case -1:
                  throw new CBORException("Invalid UTF-8");
                case -2:
                  throw new CBORException("Premature end of data");
                default:
                  break;  // No error
              }
            }
          }
          return new CBORObject(
            CBORObject.CBORObjectTypeTextString,
            builder.ToString());
        } else {
          if (hasBigAdditional) {
            throw new CBORException("Length of " +
                                    CBORUtilities.BigIntToString(bigintAdditional) +
                                    " is bigger than supported");
          } else if (uadditional > Int32.MaxValue) {
            throw new CBORException("Length of " +
                                    Convert.ToString((long)uadditional, CultureInfo.InvariantCulture) +
                                    " is bigger than supported");
          }
          StringBuilder builder = new StringBuilder();
          switch (DataUtilities.ReadUtf8(this.stream, (int)uadditional, builder, false)) {
            case -1:
              throw new CBORException("Invalid UTF-8");
            case -2:
              throw new CBORException("Premature end of data");
            default:
              break;  // No error
          }
          CBORObject cbor = new CBORObject(CBORObject.CBORObjectTypeTextString, builder.ToString());
          if (this.stringRefs != null) {
            int hint = (uadditional > Int32.MaxValue || hasBigAdditional) ? Int32.MaxValue :
              (int)uadditional;
            this.stringRefs.AddStringIfNeeded(cbor, hint);
          }
          return cbor;
        }
      } else if (type == 4) {  // Array
        CBORObject cbor = CBORObject.NewArray();
        if (this.addSharedRef) {
          this.sharedRefs.AddObject(cbor);
          this.addSharedRef = false;
        }
        if (additional == 31) {
          int vtindex = 0;
          // Indefinite-length array
          while (true) {
            int headByte = this.stream.ReadByte();
            if (headByte < 0) {
              throw new CBORException("Premature end of data");
            } else if (headByte == 0xff) {
              // Break code was read
              break;
            }
            if (filter != null && !filter.ArrayIndexAllowed(vtindex)) {
              throw new CBORException("Array is too long");
            }
            ++this.depth;
            CBORObject o = this.ReadForFirstByte(
              headByte,
              filter == null ? null : filter.GetSubFilter(vtindex));
            --this.depth;
            // break if the "break" code was read
            if (o == null) {
              break;
            }
            cbor.Add(o);
            ++vtindex;
          }
          return cbor;
        } else {
          if (hasBigAdditional) {
            throw new CBORException("Length of " +
                                    CBORUtilities.BigIntToString(bigintAdditional) +
                                    " is bigger than supported");
          } else if (uadditional > Int32.MaxValue) {
            throw new CBORException("Length of " +
                                    Convert.ToString((long)uadditional, CultureInfo.InvariantCulture) +
                                    " is bigger than supported");
          }
          if (filter != null && !filter.ArrayLengthMatches(uadditional)) {
            throw new CBORException("Array is too long");
          }
          ++this.depth;
          for (long i = 0; i < uadditional; ++i) {
            cbor.Add(
              this.Read(filter == null ? null : filter.GetSubFilter(i)));
          }
          --this.depth;
          return cbor;
        }
      } else if (type == 5) {  // Map, type 5
        CBORObject cbor = CBORObject.NewMap();
        if (this.addSharedRef) {
          this.sharedRefs.AddObject(cbor);
          this.addSharedRef = false;
        }
        if (additional == 31) {
          // Indefinite-length map
          while (true) {
            int headByte = this.stream.ReadByte();
            if (headByte < 0) {
              throw new CBORException("Premature end of data");
            } else if (headByte == 0xff) {
              // Break code was read
              break;
            }
            ++this.depth;
            CBORObject key = this.ReadForFirstByte(headByte, null);
            --this.depth;
            if (key == null) {
              // break if the "break" code was read
              break;
            }
            ++this.depth;
            CBORObject value = this.Read(null);
            --this.depth;
            cbor[key] = value;
          }
          return cbor;
        } else {
          if (hasBigAdditional) {
            throw new CBORException("Length of " +
                                    CBORUtilities.BigIntToString(bigintAdditional) +
                                    " is bigger than supported");
          } else if (uadditional > Int32.MaxValue) {
            throw new CBORException("Length of " +
                                    Convert.ToString((long)uadditional, CultureInfo.InvariantCulture) +
                                    " is bigger than supported");
          }
          for (long i = 0; i < uadditional; ++i) {
            ++this.depth;
            CBORObject key = this.Read(null);
            CBORObject value = this.Read(null);
            --this.depth;
            cbor[key] = value;
          }
          return cbor;
        }
      } else if (type == 6) {  // Tagged item
        CBORObject o;
        ICBORTag taginfo = null;
        bool haveFirstByte = false;
        int newFirstByte = -1;
        bool unnestedObject = false;
        if (!hasBigAdditional) {
          if (filter != null && !filter.TagAllowed(uadditional)) {
            throw new CBORException("Unexpected tag encountered: " + uadditional);
          }
          // Tag 256: String namespace
          if (uadditional == 256) {
            if (this.stringRefs == null) {
              this.stringRefs = new StringRefs();
            } else {
              this.stringRefs.Push();
            }
          } else if (uadditional == 25) {
            // String reference
            if (this.stringRefs == null) {
              throw new CBORException("No stringref namespace");
            }
          } else if (uadditional == 28) {
            // Shareable object
            newFirstByte = this.stream.ReadByte();
            if (newFirstByte < 0) {
              throw new CBORException("Premature end of data");
            }
            if (newFirstByte >= 0x80 && newFirstByte < 0xc0) {
              // Major types 4 and 5 (array and map)
              this.addSharedRef = true;
              haveFirstByte = true;
            } else if ((newFirstByte & 0xe0) == 0xc0) {
              // Major type 6 (tagged object)
              throw new NotImplementedException();
            } else {
              // All other major types
              unnestedObject = true;
            }
          }
          taginfo = CBORObject.FindTagConverter(uadditional);
        } else {
          if (filter != null && !filter.TagAllowed(bigintAdditional)) {
            throw new CBORException("Unexpected tag encountered: " + uadditional);
          }
          taginfo = CBORObject.FindTagConverter(bigintAdditional);
        }
        ++this.depth;
        if (haveFirstByte) {
          o = this.ReadForFirstByte(newFirstByte, taginfo == null ? null : taginfo.GetTypeFilter());
        } else {
          o = this.Read(taginfo == null ? null : taginfo.GetTypeFilter());
        }
        --this.depth;
        if (hasBigAdditional) {
          return CBORObject.FromObjectAndTag(o, bigintAdditional);
        } else if (uadditional < 65536) {
          if (uadditional == 256) {
            // string tag
            this.stringRefs.Pop();
          } else if (uadditional == 25) {
            // stringref tag
            return this.stringRefs.GetString(o.AsBigInteger());
          } else if (uadditional == 28) {
            // shareable object
            this.addSharedRef = false;
            if (unnestedObject) {
              this.sharedRefs.AddObject(o);
            }
          } else if (uadditional == 29) {
            // shared object reference
            return this.sharedRefs.GetObject(o.AsBigInteger());
          }
          return CBORObject.FromObjectAndTag(
            o,
            (int)uadditional);
        } else {
          return CBORObject.FromObjectAndTag(
            o,
            (BigInteger)uadditional);
        }
      } else {
        throw new CBORException("Unexpected data encountered");
      }
    }
  }
}