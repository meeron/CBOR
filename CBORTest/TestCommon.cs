/*
Written in 2013 by Peter O.
Any copyright is dedicated to the Public Domain.
http://creativecommons.org/publicdomain/zero/1.0/
If you like this, you should donate to Peter O.
at: http://upokecenter.dreamhosters.com/articles/donate-now-2/
 */
using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeterO;
using PeterO.Cbor;

namespace Test {
  internal static class TestCommon {
    public static void AssertBigIntegersEqual(string a, BigInteger b) {
      Assert.AreEqual(a, b.ToString());
      BigInteger a2 = BigInteger.fromString(a);
      Assert.AreEqual(a2, b);
      AssertEqualsHashCode(a2, b);
    }

    public static string ToByteArrayString(byte[] bytes) {
      if (bytes == null) {
 return "null";
}
      var sb = new System.Text.StringBuilder();
      const string ValueHex = "0123456789ABCDEF";
      sb.Append("new byte[] { ");
      for (var i = 0; i < bytes.Length; ++i) {
        if (i > 0) {
          sb.Append(","); }
        if ((bytes[i] & 0x80) != 0) {
          sb.Append("(byte)0x");
        } else {
          sb.Append("0x");
        }
        sb.Append(ValueHex[(bytes[i] >> 4) & 0xf]);
        sb.Append(ValueHex[bytes[i] & 0xf]);
      }
      sb.Append("}");
      return sb.ToString();
    }

    public static string ToByteArrayString(CBORObject obj) {
   return new System.Text.StringBuilder().Append("CBORObject.DecodeFromBytes(")
        .Append(ToByteArrayString(obj.EncodeToBytes()))
        .Append(")").ToString();
    }

    private static bool ByteArraysEqual(byte[] arr1, byte[] arr2) {
      if (arr1 == null) {
 return arr2 == null;
}
      if (arr2 == null) {
 return false;
}
      if (arr1.Length != arr2.Length) {
        return false;
      }
      for (var i = 0; i < arr1.Length; ++i) {
        if (arr1[i] != arr2[i]) {
 return false;
}
      }
      return true;
    }

    public static void AssertByteArraysEqual(byte[] arr1, byte[] arr2) {
      if (!ByteArraysEqual(arr1, arr2)) {
     Assert.Fail("Expected " + ToByteArrayString(arr1) + ", got " +
       ToByteArrayString(arr2));
      }
    }

    public static void DoTestDivide(
string dividend,
string divisor,
string result) {
      BigInteger bigintA = BigInteger.fromString(dividend);
      BigInteger bigintB = BigInteger.fromString(divisor);
      if (bigintB.IsZero) {
        try {
          bigintA.divide(bigintB); Assert.Fail("Expected divide by 0 error");
        } catch (ArithmeticException ex) {
          Console.WriteLine(ex.Message);
        }
      } else {
        AssertBigIntegersEqual(result, bigintA.divide(bigintB));
      }
    }

    public static void DoTestRemainder(
string dividend,
string divisor,
string result) {
      BigInteger bigintA = BigInteger.fromString(dividend);
      BigInteger bigintB = BigInteger.fromString(divisor);
      if (bigintB.IsZero) {
        try {
          bigintA.remainder(bigintB); Assert.Fail("Expected divide by 0 error");
        } catch (ArithmeticException ex) {
          Console.WriteLine(ex.Message);
        }
      } else {
        AssertBigIntegersEqual(result, bigintA.remainder(bigintB));
      }
    }

    public static void DoTestDivideAndRemainder(
string dividend,
string divisor,
string result,
string rem) {
      BigInteger bigintA = BigInteger.fromString(dividend);
      BigInteger bigintB = BigInteger.fromString(divisor);
      BigInteger rembi;
      if (bigintB.IsZero) {
        try {
          BigInteger quo = BigInteger.DivRem(bigintA, bigintB, out rembi);
          if (((object)quo) == null) {
            Assert.Fail();
          }
          Assert.Fail("Expected divide by 0 error");
        } catch (ArithmeticException ex) {
          Console.WriteLine(ex.Message);
        }
      } else {
        BigInteger quo = BigInteger.DivRem(bigintA, bigintB, out rembi);
        AssertBigIntegersEqual(result, quo);
        AssertBigIntegersEqual(rem, rembi);
      }
    }

    public static void DoTestMultiply(string m1, string m2, string result) {
      BigInteger bigintA = BigInteger.fromString(m1);
      BigInteger bigintB = BigInteger.fromString(m2);
      AssertBigIntegersEqual(result, bigintA.multiply(bigintB));
    }

    public static void DoTestAdd(string m1, string m2, string result) {
      BigInteger bigintA = BigInteger.fromString(m1);
      BigInteger bigintB = BigInteger.fromString(m2);
      AssertBigIntegersEqual(result, bigintA.add(bigintB));
    }

    public static void DoTestSubtract(string m1, string m2, string result) {
      BigInteger bigintA = BigInteger.fromString(m1);
      BigInteger bigintB = BigInteger.fromString(m2);
      AssertBigIntegersEqual(result, bigintA.subtract(bigintB));
    }

    public static void DoTestPow(string m1, int m2, string result) {
      BigInteger bigintA = BigInteger.fromString(m1);
      AssertBigIntegersEqual(result, bigintA.pow(m2));
      AssertBigIntegersEqual(result, bigintA.PowBigIntVar((BigInteger)m2));
    }

    public static void DoTestShiftLeft(string m1, int m2, string result) {
      BigInteger bigintA = BigInteger.fromString(m1);
      AssertBigIntegersEqual(result, bigintA.shiftLeft(m2));
      AssertBigIntegersEqual(result, bigintA.shiftRight(-m2));
    }

    public static void DoTestShiftRight(string m1, int m2, string result) {
      BigInteger bigintA = BigInteger.fromString(m1);
      AssertBigIntegersEqual(result, bigintA.shiftRight(m2));
      AssertBigIntegersEqual(result, bigintA.shiftLeft(-m2));
    }

    public static void AssertDecFrac(
ExtendedDecimal d3,
string output,
string name) {
      if (output == null && d3 != null) {
        Assert.Fail(name + ": d3 must be null");
      }
      if (output != null && !d3.ToString().Equals(output)) {
        ExtendedDecimal d4 = ExtendedDecimal.FromString(output);
        Assert.AreEqual(
output,
          d3.ToString(),
          name + ": expected: [" + d4.UnsignedMantissa + " " + d4.Exponent +
            "]\\n" + "but was: [" + d3.UnsignedMantissa + " " + d3.Exponent +
            "]");
      }
    }

    public static void AssertFlags(int expected, int actual, string name) {
      if (expected == actual) {
        return;
      }
      Assert.AreEqual(
        (expected & PrecisionContext.FlagInexact) != 0,
        (actual & PrecisionContext.FlagInexact) != 0,
        name + ": Inexact");
      Assert.AreEqual(
        (expected & PrecisionContext.FlagRounded) != 0,
        (actual & PrecisionContext.FlagRounded) != 0,
        name + ": Rounded");
      Assert.AreEqual(
        (expected & PrecisionContext.FlagSubnormal) != 0,
        (actual & PrecisionContext.FlagSubnormal) != 0,
        name + ": Subnormal");
      Assert.AreEqual(
        (expected & PrecisionContext.FlagOverflow) != 0,
        (actual & PrecisionContext.FlagOverflow) != 0,
        name + ": Overflow");
      Assert.AreEqual(
        (expected & PrecisionContext.FlagUnderflow) != 0,
        (actual & PrecisionContext.FlagUnderflow) != 0,
        name + ": Underflow");
      Assert.AreEqual(
        (expected & PrecisionContext.FlagClamped) != 0,
        (actual & PrecisionContext.FlagClamped) != 0,
        name + ": Clamped");
      Assert.AreEqual(
        (expected & PrecisionContext.FlagInvalid) != 0,
        (actual & PrecisionContext.FlagInvalid) != 0,
        name + ": Invalid");
      Assert.AreEqual(
        (expected & PrecisionContext.FlagDivideByZero) != 0,
        (actual & PrecisionContext.FlagDivideByZero) != 0,
        name + ": DivideByZero");
      Assert.AreEqual(
        (expected & PrecisionContext.FlagLostDigits) != 0,
        (actual & PrecisionContext.FlagLostDigits) != 0,
        name + ": LostDigits");
    }

    private static CBORObject FromBytesA(byte[] b) {
      return CBORObject.DecodeFromBytes(b);
    }

    private static CBORObject FromBytesB(byte[] b) {
      using (var ms = new System.IO.MemoryStream(b)) {
        CBORObject o = CBORObject.Read(ms);
        if (ms.Position != ms.Length) {
          throw new CBORException("not at EOF");
        }
        return o;
      }
    }
    // Tests the equivalence of the FromBytes and Read methods.
    public static CBORObject FromBytesTestAB(byte[] b) {
      CBORObject oa = FromBytesA(b);
      CBORObject ob = FromBytesB(b);
      if (!oa.Equals(ob)) {
        Assert.AreEqual(oa, ob);
      }
      return oa;
    }

    private static void ReverseChars(char[] chars, int offset, int length) {
      int half = length >> 1;
      int right = offset + length - 1;
      for (var i = 0; i < half; i++, right--) {
        char value = chars[offset + i];
        chars[offset + i] = chars[right];
        chars[right] = value;
      }
    }

    private static string valueDigits = "0123456789";

    public static string LongToString(long longValue) {
      if (longValue == Int64.MinValue) {
 return "-9223372036854775808";
}
      if (longValue == 0L) {
 return "0";
}
      bool neg = longValue < 0;
      var chars = new char[24];
      var count = 0;
      if (neg) {
        chars[0] = '-';
        ++count;
        longValue = -longValue;
      }
      while (longValue != 0) {
        char digit = valueDigits[(int)(longValue % 10)];
        chars[count++] = digit;
        longValue /= 10;
      }
      if (neg) {
        ReverseChars(chars, 1, count - 1);
      } else {
        ReverseChars(chars, 0, count);
      }
      return new String(chars, 0, count);
    }

    public static string IntToString(int value) {
      if (value == Int32.MinValue) {
 return "-2147483648";
}
      if (value == 0) {
 return "0";
}
      bool neg = value < 0;
      var chars = new char[24];
      var count = 0;
      if (neg) {
        chars[0] = '-';
        ++count;
        value = -value;
      }
      while (value != 0) {
        char digit = valueDigits[(int)(value % 10)];
        chars[count++] = digit;
        value /= 10;
      }
      if (neg) {
        ReverseChars(chars, 1, count - 1);
      } else {
        ReverseChars(chars, 0, count);
      }
      return new String(chars, 0, count);
    }

    public static void AssertEqualsHashCode(Object o, Object o2) {
      if (o.Equals(o2)) {
        if (!o2.Equals(o)) {
          Assert.Fail(
String.Format(
CultureInfo.InvariantCulture,
"{0} equals {1} but not vice versa",
o,
o2));
        }
        // Test for the guarantee that equal objects
        // must have equal hash codes
        if (o2.GetHashCode() != o.GetHashCode()) {
          // Don't use Assert.AreEqual directly because it has
          // quite a lot of overhead
          Assert.Fail(
String.Format(
CultureInfo.InvariantCulture,
"{0} and {1} don't have equal hash codes",
o,
o2));
        }
      } else {
        if (o2.Equals(o)) {
          Assert.Fail(String.Format(
CultureInfo.InvariantCulture,
"{0} does not equal {1} but not vice versa",
o,
o2));
        }
        // At least check that GetHashCode doesn't throw
        try {
 o.GetHashCode();
} catch (Exception ex) {
Assert.Fail(ex.ToString());
throw new InvalidOperationException(String.Empty, ex);
}
        try {
 o2.GetHashCode();
} catch (Exception ex) {
Assert.Fail(ex.ToString());
throw new InvalidOperationException(String.Empty, ex);
}
      }
    }

    public static void TestNumber(CBORObject o) {
      if (o.Type != CBORType.Number) {
        return;
      }
      if (o.IsPositiveInfinity() || o.IsNegativeInfinity() ||
          o.IsNaN()) {
        try {
          o.AsByte();
          Assert.Fail("Should have failed");
        } catch (OverflowException) {
Console.Write(String.Empty);
} catch (Exception ex) {
          Assert.Fail("Object: " + o + ", " + ex); throw new
            InvalidOperationException(String.Empty, ex);
        }
        try {
          o.AsInt16();
          Assert.Fail("Should have failed");
        } catch (OverflowException) {
Console.Write(String.Empty);
} catch (Exception ex) {
          Assert.Fail("Object: " + o + ", " + ex); throw new
            InvalidOperationException(String.Empty, ex);
        }
        try {
          o.AsInt32();
          Assert.Fail("Should have failed");
        } catch (OverflowException) {
Console.Write(String.Empty);
} catch (Exception ex) {
          Assert.Fail("Object: " + o + ", " + ex); throw new
            InvalidOperationException(String.Empty, ex);
        }
        try {
          o.AsInt64();
          Assert.Fail("Should have failed");
        } catch (OverflowException) {
Console.Write(String.Empty);
} catch (Exception ex) {
          Assert.Fail("Object: " + o + ", " + ex); throw new
            InvalidOperationException(String.Empty, ex);
        }
        try {
          o.AsSingle();
        } catch (Exception ex) {
          Assert.Fail(ex.ToString());
          throw new InvalidOperationException(String.Empty, ex);
        }
        try {
          o.AsDouble();
        } catch (Exception ex) {
          Assert.Fail(ex.ToString());
          throw new InvalidOperationException(String.Empty, ex);
        }
        try {
          o.AsBigInteger();
          Assert.Fail("Should have failed");
        } catch (OverflowException) {
Console.Write(String.Empty);
} catch (Exception ex) {
          Assert.Fail("Object: " + o + ", " + ex); throw new
            InvalidOperationException(String.Empty, ex);
        }
        return;
      }
      try {
        o.AsSingle();
      } catch (Exception ex) {
        Assert.Fail("Object: " + o + ", " + ex); throw new
          InvalidOperationException(String.Empty, ex);
      }
      try {
        o.AsDouble();
      } catch (Exception ex) {
        Assert.Fail("Object: " + o + ", " + ex); throw new
          InvalidOperationException(String.Empty, ex);
      }
    }

    public static void AssertRoundTrip(CBORObject o) {
      CBORObject o2 = FromBytesTestAB(o.EncodeToBytes());
      int cmp = o.CompareTo(o2);
      if (cmp != 0) {
        Assert.AreEqual(0, cmp, o + "\nvs.\n" + o2);
      }
      TestNumber(o);
      AssertEqualsHashCode(o, o2);
    }

    public static void AssertSer(CBORObject o, String s) {
      if (!s.Equals(o.ToString())) {
        Assert.AreEqual(s, o.ToString(), "o is not equal to s");
      }
      // Test round-tripping
      CBORObject o2 = FromBytesTestAB(o.EncodeToBytes());
      if (!s.Equals(o2.ToString())) {
        Assert.AreEqual(s, o2.ToString(), "o2 is not equal to s");
      }
      TestNumber(o);
      AssertEqualsHashCode(o, o2);
    }
  }
}
