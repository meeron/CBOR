## PeterO.Cbor.CBORObject

    public sealed class CBORObject :
        System.IComparable,
        System.IEquatable

Represents an object in Concise Binary Object Representation (CBOR) and contains methods for reading and writing CBOR data. CBOR is defined in RFC 7049.Converting CBOR objects

There are many ways to get a CBOR object, including from bytes, objects, streams and JSON, as described below.

To and from byte arrays: The CBORObject.DecodeToBytes method converts a byte array in CBOR format to a CBOR object. The EncodeToBytes method converts a CBOR object to its corresponding byte array in CBOR format.

To and from data streams: The CBORObject.Write methods write many kinds of objects to a data stream, including numbers, CBOR objects, strings, and arrays of numbers and strings. The CBORObject.Read method reads a CBOR object from a data stream.

To and from other objects: The CBORObject.FromObject method converts many kinds of objects to a CBOR object, including numbers, strings, and arrays and maps of numbers and strings. Methods like AsDouble, AsByte, and AsString convert a CBOR object to different types of object.

To and from JSON: This class also doubles as a reader and writer of JavaScript Object Notation (JSON). The CBORObject.FromJSONString method converts JSON to a CBOR object, and the ToJSONString method converts a CBOR object to a JSON string.

In addition, the CBORObject.WriteJSON method writes many kinds of objects as JSON to a data stream, including numbers, CBOR objects, strings, and arrays of numbers and strings. The CBORObject.Read method reads a CBOR object from a JSON data stream.

Comparison Considerations:

Instances of CBORObject should not be compared for equality using the "==" operator; it's possible to create two CBOR objects with the same value but not the same reference. (The "==" operator only checks if each side of the operator is the same instance.)

This class's natural ordering (under the CompareTo method) is not consistent with the Equals method. This means that two values that compare as equal under the CompareTo method might not be equal under the Equals method. This is important to consider especially if an application wants to compare numbers, since the CBOR number type supports numbers of different formats, such as big integers, rational numbers, and arbitrary-precision decimal numbers.

Another consideration is that two values that are otherwise equal may have different tags. To strip the tags from a CBOR object before comparing, use the  `Untag`  method.

To compare two numbers, the CompareToIgnoreTags or CompareTo method should be used. Which method to use depends on whether two equal values should still be considered equal if they have different tags.

Although this class is inconsistent with the Equals method, it is safe to use CBORObject instances as hash keys as long as all of the keys are untagged text strings (which means GetTags returns an empty array and the Type property, or "getType()" in Java, returns TextString). This is because the natural ordering of these instances is consistent with the Equals method.

Thread Safety:

CBOR objects that are numbers, "simple values", and text strings are immutable (their values can't be changed), so they are inherently safe for use by multiple threads.

CBOR objects that are arrays, maps, and byte strings are mutable, but this class doesn't attempt to synchronize reads and writes to those objects by multiple threads, so those objects are not thread safe without such synchronization.

One kind of CBOR object is called a map, or a list of key-value pairs. Keys can be any kind of CBOR object, including numbers, strings, arrays, and maps. However, text strings are the most suitable to use as keys; other kinds of CBOR object are much better used as map values instead, keeping in mind that some of them are not thread safe without synchronizing reads and writes to them.

To find the type of a CBOR object, call its Type property (or "getType()" in Java). The return value can be Number, Boolean, SimpleValue, or TextString for immutable CBOR objects, and Array, Map, or ByteString for mutable CBOR objects.

Nesting Depth:

The DecodeFromBytes and Read methods can only read objects with a limited maximum depth of arrays and maps nested within other arrays and maps. The code sets this maximum depth to 500 (allowing more than enough nesting for most purposes), but it's possible that stack overflows in some runtimes might lower the effective maximum nesting depth. When the nesting depth goes above 500, the DecodeFromBytes and Read methods throw a CBORException.

The ReadJSON and FromJSONString methods currently have nesting depths of 1000.

### False

    public static readonly PeterO.Cbor.CBORObject False;

Represents the value false.

### NaN

    public static readonly PeterO.Cbor.CBORObject NaN;

A not-a-number value.

### NegativeInfinity

    public static readonly PeterO.Cbor.CBORObject NegativeInfinity;

The value negative infinity.

### Null

    public static readonly PeterO.Cbor.CBORObject Null;

Represents the value null.

### PositiveInfinity

    public static readonly PeterO.Cbor.CBORObject PositiveInfinity;

The value positive infinity.

### True

    public static readonly PeterO.Cbor.CBORObject True;

Represents the value true.

### Undefined

    public static readonly PeterO.Cbor.CBORObject Undefined;

Represents the value undefined.

### Zero

    public static readonly PeterO.Cbor.CBORObject Zero;

Gets a CBOR object for the number zero.

### Count

    public int Count { get; }

Gets the number of keys in this map, or the number of items in this array, or 0 if this item is neither an array nor a map.

<b>Returns:</b>

The number of keys in this map, or the number of items in this array, or 0 if this item is neither an array nor a map.

### InnermostTag

    public PeterO.BigInteger InnermostTag { get; }

Gets the last defined tag for this CBOR data item, or -1 if the item is untagged.

<b>Returns:</b>

The last defined tag for this CBOR data item, or -1 if the item is untagged.

### IsFalse

    public bool IsFalse { get; }

Gets a value indicating whether this value is a CBOR false value.

<b>Returns:</b>

<c>true</c> if this value is a CBOR false value; otherwise, <c>false</c>.  `true`  if this value is a CBOR false value; otherwise,  `false` .

### IsFinite

    public bool IsFinite { get; }

Gets a value indicating whether this CBOR object represents a finite number.

<b>Returns:</b>

<c>true</c> if this CBOR object represents a finite number; otherwise, <c>false</c>.  `true`  if this CBOR object represents a finite number; otherwise, `false` .

### IsIntegral

    public bool IsIntegral { get; }

Gets a value indicating whether this object represents an integral number, that is, a number without a fractional part. Infinity and not-a-number are not considered integral.

<b>Returns:</b>

<c>true</c> if this object represents an integral number, that is, a number without a fractional part; otherwise, <c>false</c>.. Infinity and not-a-number are not considered integral.  `true`  if this object represents an integral number, that is, a number without a fractional part; otherwise,  `false` .

### IsNegative

    public bool IsNegative { get; }

Gets a value indicating whether this object is a negative number.

<b>Returns:</b>

<c>true</c> if this object is a negative number; otherwise, <c>false</c>.  `true`  if this object is a negative number; otherwise,  `false` .

### IsNull

    public bool IsNull { get; }

Gets a value indicating whether this value is a CBOR null value.

<b>Returns:</b>

<c>true</c> if this value is a CBOR null value; otherwise, <c>false</c>.  `true`  if this value is a CBOR null value; otherwise,  `false` .

### IsTagged

    public bool IsTagged { get; }

Gets a value indicating whether this data item has at least one tag.

<b>Returns:</b>

<c>true</c> if this data item has at least one tag; otherwise, <c>false</c>.  `true`  if this data item has at least one tag; otherwise,  `false` .

### IsTrue

    public bool IsTrue { get; }

Gets a value indicating whether this value is a CBOR true value.

<b>Returns:</b>

<c>true</c> if this value is a CBOR true value; otherwise, <c>false</c>.  `true`  if this value is a CBOR true value; otherwise,  `false` .

### IsUndefined

    public bool IsUndefined { get; }

Gets a value indicating whether this value is a CBOR undefined value.

<b>Returns:</b>

<c>true</c> if this value is a CBOR undefined value; otherwise, <c>false</c>.  `true`  if this value is a CBOR undefined value; otherwise,  `false` .

### IsZero

    public bool IsZero { get; }

Gets a value indicating whether this object's value equals 0.

<b>Returns:</b>

<c>true</c> if this object&#x27;s value equals 0; otherwise, <c>false</c>.  `true`  if this object's value equals 0; otherwise,  `false` .

### Keys

    public System.Collections.Generic.ICollection Keys { get; }

Gets a collection of the keys of this CBOR object in an undefined order.

<b>Returns:</b>

A collection of the keys of this CBOR object.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object is not a map.

### OutermostTag

    public PeterO.BigInteger OutermostTag { get; }

Gets the outermost tag for this CBOR data item, or -1 if the item is untagged.

<b>Returns:</b>

The outermost tag for this CBOR data item, or -1 if the item is untagged.

### Sign

    public int Sign { get; }

Gets this value's sign: -1 if negative; 1 if positive; 0 if zero.

<b>Returns:</b>

This value's sign: -1 if negative; 1 if positive; 0 if zero.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object's type is not a number type, including the special not-a-number value (NaN).

### SimpleValue

    public int SimpleValue { get; }

Gets the simple value ID of this object, or -1 if this object is not a simple value (including if the value is a floating-point number).

<b>Returns:</b>

The simple value ID of this object, or -1 if this object is not a simple value (including if the value is a floating-point number).

### Type

    public PeterO.Cbor.CBORType Type { get; }

Gets the general data type of this CBOR object.

<b>Returns:</b>

The general data type of this CBOR object.

### Values

    public System.Collections.Generic.ICollection Values { get; }

Gets a collection of the values of this CBOR object. If this object is a map, returns one value for each key in the map in an undefined order. If this is an array, returns all the values of the array in the order they are listed.

<b>Returns:</b>

A collection of the values of this CBOR object.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object is not a map or an array.

### Abs

    public PeterO.Cbor.CBORObject Abs();

Gets this object's absolute value.

<b>Returns:</b>

This object's absolute without its negative sign.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object's type is not a number type.

### Add

    public PeterO.Cbor.CBORObject Add(
        object key,
        object valueOb);

Adds a new key and its value to this CBOR map, or adds the value if the key doesn't exist.

<b>Parameters:</b>

 * <i>key</i>: An object representing the key, which will be converted to a CBORObject. Can be null, in which case this value is converted to CBORObject.Null.

 * <i>valueOb</i>: An object representing the value, which will be converted to a CBORObject. Can be null, in which case this value is converted to CBORObject.Null.

<b>Returns:</b>

This instance.

<b>Exceptions:</b>

 * System.ArgumentException:
The parameter <i>key</i>
 already exists in this map.

 * System.InvalidOperationException:
This object is not a map.

 * System.ArgumentException:
The parameter <i>key</i>
 or  <i>valueOb</i>
 has an unsupported type.

### Add

    public PeterO.Cbor.CBORObject Add(
        object obj);

Converts an object to a CBOR object and adds it to the end of this array.

<b>Parameters:</b>

 * <i>obj</i>: A CBOR object.

<b>Returns:</b>

This instance.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object is not an array.

 * System.ArgumentException:
The type of  <i>obj</i>
 is not supported.

### Add

    public PeterO.Cbor.CBORObject Add(
        PeterO.Cbor.CBORObject obj);

Adds a new object to the end of this array. (Used to throw ArgumentNullException on a null reference, but now converts the null reference to CBORObject.Null, for convenience with the Object overload of this method.).

<b>Parameters:</b>

 * <i>obj</i>: A CBOR object.

<b>Returns:</b>

This instance.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object is not an array.

### AddConverter

    public static void AddConverter<T>(
        System.Type type,
        PeterO.Cbor.ICBORConverter<T> converter);

Registers an object that converts objects of a given type to CBOR objects (called a CBOR converter).

<b>Parameters:</b>

 * <i>type</i>: A Type object specifying the type that the converter converts to CBOR objects.

 * <i>converter</i>: An ICBORConverter object.

 * &lt;T&gt;: Must be the same as the "type" parameter.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>type</i>
 or  <i>converter</i>
 is null.

### Addition

    public static PeterO.Cbor.CBORObject Addition(
        PeterO.Cbor.CBORObject first,
        PeterO.Cbor.CBORObject second);

Finds the sum of two CBOR numbers.

<b>Parameters:</b>

 * <i>first</i>: Another CBOR object.

 * <i>second</i>: A CBORObject object. (3).

<b>Returns:</b>

A CBORObject object.

<b>Exceptions:</b>

 * System.ArgumentException:
Either or both operands are not numbers (as opposed to Not-a-Number, NaN).

### AddTagHandler

    public static void AddTagHandler(
        PeterO.BigInteger bigintTag,
        PeterO.Cbor.ICBORTag handler);

Registers an object that validates CBOR objects with new tags.

<b>Parameters:</b>

 * <i>bigintTag</i>: An arbitrary-precision integer.

 * <i>handler</i>: An ICBORTag object.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>bigintTag</i>
 or  <i>handler</i>
 is null.

 * System.ArgumentNullException:
The parameter <i>bigintTag</i>
 is less than 0 or greater than (2^64-1).

### AsBigInteger

    public PeterO.BigInteger AsBigInteger();

Converts this object to an arbitrary-precision integer. Fractional values are truncated to an integer.

<b>Returns:</b>

The closest big integer to this object.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object's type is not a number type, including if this object is CBORObject.Null.

 * System.OverflowException:
This object's value is infinity or not-a-number (NaN).

### AsBoolean

    public bool AsBoolean();

Returns false if this object is False, Null, or Undefined; otherwise, true.

<b>Returns:</b>

False if this object is False, Null, or Undefined; otherwise, true.

### AsByte

    public byte AsByte();

Converts this object to a byte (0 to 255). Floating point values are truncated to an integer.

<b>Returns:</b>

The closest byte-sized integer to this object.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object's type is not a number type.

 * System.OverflowException:
This object's value exceeds the range of a byte (would be less than 0 or greater than 255 when truncated to an integer).

### AsDecimal

    public System.Decimal AsDecimal();

Converts this object to a .NET decimal.

<b>Returns:</b>

The closest big integer to this object.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object's type is not a number type.

 * System.OverflowException:
This object's value exceeds the range of a .NET decimal.

### AsDouble

    public double AsDouble();

Converts this object to a 64-bit floating point number.

<b>Returns:</b>

The closest 64-bit floating point number to this object. The return value can be positive infinity or negative infinity if this value exceeds the range of a 64-bit floating point number.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object's type is not a number type.

### AsExtendedDecimal

    public PeterO.ExtendedDecimal AsExtendedDecimal();

Converts this object to a decimal number.

<b>Returns:</b>

A decimal number for this object's value. If this object is a rational number with a nonterminating decimal expansion, returns a decimal number rounded to 34 digits.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object's type is not a number type, including if this object is CBORObject.Null.

### AsExtendedFloat

    public PeterO.ExtendedFloat AsExtendedFloat();

Converts this object to an arbitrary-precision binary floating point number.

<b>Returns:</b>

An arbitrary-precision binary floating point number for this object's value. Note that if this object is a decimal number with a fractional part, the conversion may lose information depending on the number. If this object is a rational number with a nonterminating binary expansion, returns a binary floating-point number rounded to 113 bits.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object's type is not a number type, including if this object is CBORObject.Null.

### AsExtendedRational

    public PeterO.ExtendedRational AsExtendedRational();

Converts this object to a rational number.

<b>Returns:</b>

A rational number for this object's value.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object's type is not a number type, including if this object is CBORObject.Null.

### AsInt16

    public short AsInt16();

Converts this object to a 16-bit signed integer. Floating point values are truncated to an integer.

<b>Returns:</b>

The closest 16-bit signed integer to this object.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object's type is not a number type.

 * System.OverflowException:
This object's value exceeds the range of a 16-bit signed integer.

### AsInt32

    public int AsInt32();

Converts this object to a 32-bit signed integer. Floating point values are truncated to an integer.

<b>Returns:</b>

The closest big integer to this object.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object's type is not a number type.

 * System.OverflowException:
This object's value exceeds the range of a 32-bit signed integer.

### AsInt64

    public long AsInt64();

Converts this object to a 64-bit signed integer. Floating point values are truncated to an integer.

<b>Returns:</b>

The closest 64-bit signed integer to this object.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object's type is not a number type.

 * System.OverflowException:
This object's value exceeds the range of a 64-bit signed integer.

### AsSByte

    public sbyte AsSByte();

Converts this object to an 8-bit signed integer.

<b>Returns:</b>

An 8-bit signed integer.

### AsSingle

    public float AsSingle();

Converts this object to a 32-bit floating point number.

<b>Returns:</b>

The closest 32-bit floating point number to this object. The return value can be positive infinity or negative infinity if this object's value exceeds the range of a 32-bit floating point number.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object's type is not a number type.

### AsString

    public string AsString();

Gets the value of this object as a text string.

<b>Returns:</b>

Gets this object's string.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object's type is not a string, including if this object is CBORObject.Null.

### AsUInt16

    public ushort AsUInt16();

Converts this object to a 16-bit unsigned integer. The return value will be truncated as necessary.

<b>Returns:</b>

A 16-bit unsigned integer.

<b>Exceptions:</b>

 * System.OverflowException:
This object's value is outside the range of a 16-bit unsigned integer.

### AsUInt32

    public uint AsUInt32();

Converts this object to a 32-bit unsigned integer. The return value will be truncated as necessary.

<b>Returns:</b>

A 32-bit unsigned integer.

<b>Exceptions:</b>

 * System.OverflowException:
This object's value is outside the range of a 32-bit unsigned integer.

### AsUInt64

    public ulong AsUInt64();

Converts this object to a 64-bit unsigned integer. Floating point values are truncated to an integer.

<b>Returns:</b>

The closest big integer to this object.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object's type is not a number type.

 * System.OverflowException:
This object's value exceeds the range of a 64-bit unsigned integer.

### CanFitInDouble

    public bool CanFitInDouble();

Returns whether this object's value can be converted to a 64-bit floating point number without loss of its numerical value.

<b>Returns:</b>

Whether this object's value can be converted to a 64-bit floating point number without loss of its numerical value. Returns true if this is a not-a-number value, even if the value's diagnostic information can' t fit in a 64-bit floating point number.

### CanFitInInt32

    public bool CanFitInInt32();

Returns whether this object's value is an integral value, is -(2^31) or greater, and is less than 2^31.

<b>Returns:</b>

 `true`  if this object's value is an integral value, is -(2^31) or greater, and is less than 2^31; otherwise, false .

### CanFitInInt64

    public bool CanFitInInt64();

Returns whether this object's value is an integral value, is -(2^63) or greater, and is less than 2^63.

<b>Returns:</b>

 `true`  if this object's value is an integral value, is -(2^63) or greater, and is less than 2^63; otherwise, false .

### CanFitInSingle

    public bool CanFitInSingle();

Returns whether this object's value can be converted to a 32-bit floating point number without loss of its numerical value.

<b>Returns:</b>

Whether this object's value can be converted to a 32-bit floating point number without loss of its numerical value. Returns true if this is a not-a-number value, even if the value's diagnostic information can' t fit in a 32-bit floating point number.

### CanTruncatedIntFitInInt32

    public bool CanTruncatedIntFitInInt32();

Returns whether this object's value, truncated to an integer, would be -(2^31) or greater, and less than 2^31.

<b>Returns:</b>

 `true`  if this object's value, truncated to an integer, would be -(2^31) or greater, and less than 2^31; otherwise, false .

### CanTruncatedIntFitInInt64

    public bool CanTruncatedIntFitInInt64();

Returns whether this object's value, truncated to an integer, would be -(2^63) or greater, and less than 2^63.

<b>Returns:</b>

 `true`  if this object's value, truncated to an integer, would be -(2^63) or greater, and less than 2^63; otherwise, false .

### CompareTo

    public sealed int CompareTo(
        PeterO.Cbor.CBORObject other);

Compares two CBOR objects.In this implementation:

 * The null pointer (null reference) is considered less than any other object.

 * If either object is true, false, CBORObject.Null, or the undefined value, it is treated as less than the other value. If both objects have one of these four values, then undefined is less than CBORObject.Null, which is less than false, which is less than true.

 * If both objects are numbers, their mathematical values are compared. Here, NaN (not-a-number) is considered greater than any number.

 * If both objects are simple values other than true, false, CBORObject.Null, and the undefined value, the objects are compared according to their ordinal numbers.

 * If both objects are arrays, each element is compared. If one array is shorter than the other and the other array begins with that array (for the purposes of comparison), the shorter array is considered less than the longer array.

 * If both objects are strings, compares each string code-point by code-point, as though by the DataUtilities.CodePointCompare method.

 * If both objects are maps, compares each map as though each were an array with the sorted keys of that map as the array's elements. If both maps have the same keys, their values are compared in the order of the sorted keys.

 * If each object is a different type, then they are sorted by their type number, in the order given for the CBORType enumeration.

 * If each object has different tags and both objects are otherwise equal under this method, each element is compared as though each were an array with that object's tags listed in order from outermost to innermost.

This method is not consistent with the Equals method.

<b>Parameters:</b>

 * <i>other</i>: A value to compare with.

<b>Returns:</b>

Less than 0, if this value is less than the other object; or 0, if both values are equal; or greater than 0, if this value is less than the other object or if the other object is null.

### CompareToIgnoreTags

    public int CompareToIgnoreTags(
        PeterO.Cbor.CBORObject other);

Compares this object and another CBOR object, ignoring the tags they have, if any. See the CompareTo method for more information on the comparison function.

<b>Parameters:</b>

 * <i>other</i>: A value to compare with.

<b>Returns:</b>

Less than 0, if this value is less than the other object; or 0, if both values are equal; or greater than 0, if this value is less than the other object or if the other object is null.

### ContainsKey

    public bool ContainsKey(
        PeterO.Cbor.CBORObject key);

Determines whether a value of the given key exists in this object.

<b>Parameters:</b>

 * <i>key</i>: An object that serves as the key.

<b>Returns:</b>

 `true`  if the given key is found, or false if the given key is not found or this object is not a map.

<b>Exceptions:</b>

 * System.ArgumentNullException:
Key is null (as opposed to CBORObject.Null).

### ContainsKey

    public bool ContainsKey(
        string key);

Determines whether a value of the given key exists in this object.

<b>Parameters:</b>

 * <i>key</i>: A string that serves as the key.

<b>Returns:</b>

 `true`  if the given key (as a CBOR object) is found, or false if the given key is not found or this object is not a map.

<b>Exceptions:</b>

 * System.ArgumentNullException:
Key is null.

### DecodeFromBytes

    public static PeterO.Cbor.CBORObject DecodeFromBytes(
        byte[] data);

Generates a CBOR object from an array of CBOR-encoded bytes.

<b>Parameters:</b>

 * <i>data</i>: A byte array.

<b>Returns:</b>

A CBOR object corresponding to the data.

<b>Exceptions:</b>

 * PeterO.Cbor.CBORException:
There was an error in reading or parsing the data. This includes cases where not all of the byte array represents a CBOR object. This exception is also thrown if the parameter  <i>data</i>
 is empty.

 * System.ArgumentNullException:
The parameter <i>data</i>
 is null.

### DecodeFromBytes

    public static PeterO.Cbor.CBORObject DecodeFromBytes(
        byte[] data,
        PeterO.Cbor.CBOREncodeOptions options);

Generates a CBOR object from an array of CBOR-encoded bytes.

<b>Parameters:</b>

 * <i>data</i>: A byte array.

 * <i>options</i>: A CBOREncodeOptions object.

<b>Returns:</b>

A CBOR object corresponding to the data.

<b>Exceptions:</b>

 * PeterO.Cbor.CBORException:
There was an error in reading or parsing the data. This includes cases where not all of the byte array represents a CBOR object. This exception is also thrown if the parameter  <i>data</i>
 is empty.

 * System.ArgumentNullException:
The parameter <i>data</i>
 is null.

### Divide

    public static PeterO.Cbor.CBORObject Divide(
        PeterO.Cbor.CBORObject first,
        PeterO.Cbor.CBORObject second);

Divides a CBORObject object by the value of a CBORObject object.

<b>Parameters:</b>

 * <i>first</i>: A CBORObject object.

 * <i>second</i>: Another CBOR object.

<b>Returns:</b>

The quotient of the two objects.

### EncodeToBytes

    public byte[] EncodeToBytes(
        PeterO.Cbor.CBOREncodeOptions options);

Gets the binary representation of this data item.

<b>Parameters:</b>

 * <i>options</i>: Options for encoding the data to CBOR.

<b>Returns:</b>

A byte array in CBOR format.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>options</i>
 is null.

### EncodeToBytes

    public byte[] EncodeToBytes();

Gets the binary representation of this data item.

<b>Returns:</b>

A byte array in CBOR format.

### Equals

    public override bool Equals(
        object obj);

Determines whether this object and another object are equal.

<b>Parameters:</b>

 * <i>obj</i>: An arbitrary object.

<b>Returns:</b>

 `true`  if the objects are equal; otherwise, false .

### Equals

    public sealed bool Equals(
        PeterO.Cbor.CBORObject other);

Compares the equality of two CBOR objects.

<b>Parameters:</b>

 * <i>other</i>: The object to compare.

<b>Returns:</b>

 `true`  if the objects are equal; otherwise, false .

### FromJSONString

    public static PeterO.Cbor.CBORObject FromJSONString(
        string str);

Generates a CBOR object from a text string in JavaScript Object Notation (JSON) format.If a JSON object has the same key, only the last given value will be used for each duplicated key.

<b>Parameters:</b>

 * <i>str</i>: A string in JSON format. The entire string must contain a single JSON object and not multiple objects. The string may not begin with a byte-order mark (U+FEFF).

<b>Returns:</b>

A CBORObject object.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>str</i>
 is null.

 * PeterO.Cbor.CBORException:
The string is not in JSON format.

### FromJSONString

    public static PeterO.Cbor.CBORObject FromJSONString(
        string str,
        PeterO.Cbor.CBOREncodeOptions options);

Generates a CBOR object from a text string in JavaScript Object Notation (JSON) format.By default, if a JSON object has the same key, only the last given value will be used for each duplicated key.

<b>Parameters:</b>

 * <i>str</i>: A string in JSON format. The entire string must contain a single JSON object and not multiple objects. The string may not begin with a byte-order mark (U+FEFF).

 * <i>options</i>: A CBOREncodeOptions object.

<b>Returns:</b>

A CBORObject object.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>str</i>
 is null.

 * PeterO.Cbor.CBORException:
The string is not in JSON format.

### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        bool value);

Returns the CBOR true value or false value, depending on "value".

<b>Parameters:</b>

 * <i>value</i>: Either True or False.

<b>Returns:</b>

CBORObject.True if value is true; otherwise CBORObject.False.

### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        byte value);

Generates a CBOR object from a byte (0 to 255).

<b>Parameters:</b>

 * <i>value</i>: A Byte object.

<b>Returns:</b>

A CBORObject object.

### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        byte[] bytes);

Generates a CBOR object from a byte array. The byte array is copied to a new byte array. (This method can't be used to decode CBOR data from a byte array; for that, use the DecodeFromBytes method instead.).

<b>Parameters:</b>

 * <i>bytes</i>: A byte array. Can be null.

<b>Returns:</b>

A CBOR byte string object where each byte of the given byte array is copied to a new array, or CBORObject.Null if the value is null.

### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        char value);

Generates a CBOR string object from a Unicode character.

<b>Parameters:</b>

 * <i>value</i>: A char object.

<b>Returns:</b>

A CBORObject object.

<b>Exceptions:</b>

 * System.ArgumentException:
The parameter <i>value</i>
 is a surrogate code point.

### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        double value);

Generates a CBOR object from a 64-bit floating-point number.

<b>Parameters:</b>

 * <i>value</i>: A 64-bit floating-point number.

<b>Returns:</b>

A CBORObject object.

### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        float value);

Generates a CBOR object from a 32-bit floating-point number.

<b>Parameters:</b>

 * <i>value</i>: A 32-bit floating-point number.

<b>Returns:</b>

A CBORObject object.

### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        int value);

Generates a CBOR object from a 32-bit signed integer.

<b>Parameters:</b>

 * <i>value</i>: A 32-bit signed integer.

<b>Returns:</b>

A CBORObject object.

### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        int[] array);

Generates a CBOR object from an array of 32-bit integers.

<b>Parameters:</b>

 * <i>array</i>: An array of 32-bit integers.

<b>Returns:</b>

A CBOR array object where each element of the given array is copied to a new array, or CBORObject.Null if the value is null.

### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        long value);

Generates a CBOR object from a 64-bit signed integer.

<b>Parameters:</b>

 * <i>value</i>: A 64-bit signed integer.

<b>Returns:</b>

A CBORObject object.

### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        long[] array);

Generates a CBOR object from an array of 64-bit integers.

<b>Parameters:</b>

 * <i>array</i>: An array of 64-bit integers.

<b>Returns:</b>

A CBOR array object where each element of the given array is copied to a new array, or CBORObject.Null if the value is null.

### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        object obj);

Generates a CBORObject from an arbitrary object. The following types are specially handled by this method: null; primitive types; string; CBORObject; the  `EDecimal` , `EFloat` ,  `EInteger` , and  `ERational`  classes in the new `PeterO.Numbers` library (in .NET) or the `com.github.peteroupc/numbers` artifact (in Java); the legacy  `ExtendedDecimal` , `ExtendedFloat` ,  `ExtendedInteger` , and `ExtendedRational`  classes in this library; arrays; enumerations (  `Enum`  objects); and maps.In the .NET version, if the object is a type not specially handled by this method, returns a CBOR map with the values of each of its read/write properties (or all properties in the case of an anonymous type). Properties are converted to their camel-case names (meaning if a name starts with A to Z, that letter is lower-cased). If the property name begins with the word "Is", that word is deleted from the name. Also, .NET  `Enum`  objects will be converted to their integer values, and a multidimensional array is converted to an array of arrays.

In the Java version, if the object is a type not specially handled by this method, this method checks the CBOR object for methods starting with the word "get" or "is" that take no parameters, and returns a CBOR map with one entry for each such method found. For each method found, the starting word "get" or "is" is deleted from its name, and the name is converted to camel case (meaning if a name starts with A to Z, that letter is lower-cased). Also, Java  `Enum`  objects will be converted to the result of their name method.

If the input is a byte array, the byte array is copied to a new byte array. (This method can't be used to decode CBOR data from a byte array; for that, use the DecodeFromBytes method instead.).

<b>Parameters:</b>

 * <i>obj</i>: An arbitrary object.

<b>Returns:</b>

A CBOR object corresponding to the given object. Returns CBORObject.Null if the object is null.

### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        PeterO.BigInteger bigintValue);

Generates a CBOR object from an arbitrary-precision integer.

<b>Parameters:</b>

 * <i>bigintValue</i>: An arbitrary-precision value.

<b>Returns:</b>

A CBOR number.

### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        PeterO.Cbor.CBORObject value);

Generates a CBOR object from a CBOR object.

<b>Parameters:</b>

 * <i>value</i>: A CBOR object.

<b>Returns:</b>

Same as.

### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        PeterO.Cbor.CBORObject[] array);

Generates a CBOR object from an array of CBOR objects.

<b>Parameters:</b>

 * <i>array</i>: An array of CBOR objects.

<b>Returns:</b>

A CBOR object where each element of the given array is copied to a new array, or CBORObject.Null if the value is null.

### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        PeterO.ExtendedDecimal otherValue);

Generates a CBOR object from a decimal number.

<b>Parameters:</b>

 * <i>otherValue</i>: An arbitrary-precision decimal number.

<b>Returns:</b>

A CBOR number.

### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        PeterO.ExtendedFloat bigValue);

Generates a CBOR object from an arbitrary-precision binary floating-point number.

<b>Parameters:</b>

 * <i>bigValue</i>: An arbitrary-precision binary floating-point number.

<b>Returns:</b>

A CBOR number.

### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        PeterO.ExtendedRational bigValue);

Generates a CBOR object from an arbitrary-precision binary floating-point number.

<b>Parameters:</b>

 * <i>bigValue</i>: An arbitrary-precision binary floating-point number.

<b>Returns:</b>

A CBOR number.

### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        sbyte value);

Converts a signed 8-bit integer to a CBOR object.

<b>Parameters:</b>

 * <i>value</i>: An 8-bit signed integer.

<b>Returns:</b>

A CBORObject object.

### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        short value);

Generates a CBOR object from a 16-bit signed integer.

<b>Parameters:</b>

 * <i>value</i>: A 16-bit signed integer.

<b>Returns:</b>

A CBORObject object.

### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        string strValue);

Generates a CBOR object from a text string.

<b>Parameters:</b>

 * <i>strValue</i>: A string value. Can be null.

<b>Returns:</b>

A CBOR object representing the string, or CBORObject.Null if stringValue is null.

<b>Exceptions:</b>

 * System.ArgumentException:
The string contains an unpaired surrogate code point.

### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        System.Decimal value);

Converts a .NET decimal to a CBOR object.

<b>Parameters:</b>

 * <i>value</i>: A Decimal object.

<b>Returns:</b>

A CBORObject object with the same value as the .NET decimal.

### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        uint value);

Converts a 32-bit unsigned integer to a CBOR object.

<b>Parameters:</b>

 * <i>value</i>: A 32-bit unsigned integer.

<b>Returns:</b>

A CBORObject object.

### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        ulong value);

Converts a 64-bit unsigned integer to a CBOR object.

<b>Parameters:</b>

 * <i>value</i>: A 64-bit unsigned integer.

<b>Returns:</b>

A CBORObject object.

### FromObject

    public static PeterO.Cbor.CBORObject FromObject(
        ushort value);

Converts a 16-bit unsigned integer to a CBOR object.

<b>Parameters:</b>

 * <i>value</i>: A 16-bit unsigned integer.

<b>Returns:</b>

A CBORObject object.

### FromObject

    public static PeterO.Cbor.CBORObject FromObject<T>(
        System.Collections.Generic.IEnumerable<T> value);

Generates a CBOR object from an enumerable set of objects.

<b>Parameters:</b>

 * <i>value</i>: An object that implements the IEnumerable interface. In the .NET version, this can be the return value of an iterator or the result of a LINQ query.

 * &lt;T&gt;: A type convertible to CBORObject.

<b>Returns:</b>

A CBOR object where each element of the given enumerable object is converted to a CBOR object and copied to a new array, or CBORObject.Null if the value is null.

### FromObject

    public static PeterO.Cbor.CBORObject FromObject<T>(
        System.Collections.Generic.IList<T> value);

Generates a CBOR object from a list of objects.

<b>Parameters:</b>

 * <i>value</i>: An array of CBOR objects. Can be null.

 * &lt;T&gt;: A type convertible to CBORObject.

<b>Returns:</b>

A CBOR object where each element of the given array is converted to a CBOR object and copied to a new array, or CBORObject.Null if the value is null.

### FromObject

    public static PeterO.Cbor.CBORObject FromObject<TKey, TValue>(
        System.Collections.Generic.IDictionary<TKey, TValue> dic);

Generates a CBOR object from a map of objects.

<b>Parameters:</b>

 * <i>dic</i>: A map of CBOR objects.

 * &lt;TKey&gt;: A type convertible to CBORObject; the type of the keys.

 * &lt;TValue&gt;: A type convertible to CBORObject; the type of the values.

<b>Returns:</b>

A CBOR object where each key and value of the given map is converted to a CBOR object and copied to a new map, or CBORObject.Null if  <i>dic</i>
 is null.

### FromObjectAndTag

    public static PeterO.Cbor.CBORObject FromObjectAndTag(
        object o,
        ulong tag);

Generates a CBOR object from an arbitrary object and gives the resulting object a tag.

<b>Parameters:</b>

 * <i>o</i>: An arbitrary object.

 * <i>tag</i>: A 64-bit unsigned integer.

<b>Returns:</b>

A CBOR object where the object  <i>o</i>
 is converted to a CBOR object and given the tag  <i>tag</i>
.

### FromObjectAndTag

    public static PeterO.Cbor.CBORObject FromObjectAndTag(
        object valueOb,
        PeterO.BigInteger bigintTag);

Generates a CBOR object from an arbitrary object and gives the resulting object a tag.

<b>Parameters:</b>

 * <i>valueOb</i>: An arbitrary object. If the tag number is 2 or 3, this must be a byte string whose bytes represent an integer in little-endian byte order, and the value of the number is 1 minus the integer's value for tag 3. If the tag number is 4 or 5, this must be an array with two elements: the first must be an integer representing the exponent, and the second must be an integer representing a mantissa.

 * <i>bigintTag</i>: Tag number. The tag number 55799 can be used to mark a "self-described CBOR" object.

<b>Returns:</b>

A CBOR object where the object  <i>valueOb</i>
is converted to a CBOR object and given the tag  <i>bigintTag</i>
.

<b>Exceptions:</b>

 * System.ArgumentException:
The parameter <i>bigintTag</i>
 is less than 0 or greater than 2^64-1, or  <i>valueOb</i>
 's type is unsupported.

 * System.ArgumentNullException:
The parameter <i>bigintTag</i>
 is null.

### FromObjectAndTag

    public static PeterO.Cbor.CBORObject FromObjectAndTag(
        object valueObValue,
        int smallTag);

Generates a CBOR object from an arbitrary object and gives the resulting object a tag.

<b>Parameters:</b>

 * <i>valueObValue</i>: An arbitrary object. If the tag number is 2 or 3, this must be a byte string whose bytes represent an integer in little-endian byte order, and the value of the number is 1 minus the integer's value for tag 3. If the tag number is 4 or 5, this must be an array with two elements: the first must be an integer representing the exponent, and the second must be an integer representing a mantissa.

 * <i>smallTag</i>: A 32-bit integer that specifies a tag number. The tag number 55799 can be used to mark a "self-described CBOR" object.

<b>Returns:</b>

A CBOR object where the object  <i>valueObValue</i>
 is converted to a CBOR object and given the tag  <i>smallTag</i>
.

<b>Exceptions:</b>

 * System.ArgumentException:
The parameter <i>smallTag</i>
 is less than 0 or  <i>valueObValue</i>
 's type is unsupported.

### FromSimpleValue

    public static PeterO.Cbor.CBORObject FromSimpleValue(
        int simpleValue);

Creates a CBOR object from a simple value number.

<b>Parameters:</b>

 * <i>simpleValue</i>: A 32-bit signed integer.

<b>Returns:</b>

A CBORObject object.

<b>Exceptions:</b>

 * System.ArgumentException:
The parameter <i>simpleValue</i>
 is less than 0, greater than 255, or from 24 through 31.

### GetByteString

    public byte[] GetByteString();

Gets the byte array used in this object, if this object is a byte string, without copying the data to a new one. This method's return value can be used to modify the array's contents. Note, though, that the array' s length can't be changed.

<b>Returns:</b>

A byte array.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object is not a byte string.

### GetHashCode

    public override int GetHashCode();

Calculates the hash code of this object.

<b>Returns:</b>

A 32-bit hash code.

### GetTags

    public PeterO.BigInteger[] GetTags();

Gets a list of all tags, from outermost to innermost.

<b>Returns:</b>

An array of tags, or the empty string if this object is untagged.

### HasTag

    public bool HasTag(
        int tagValue);

Returns whether this object has a tag of the given number.

<b>Parameters:</b>

 * <i>tagValue</i>: The tag value to search for.

<b>Returns:</b>

 `true`  if this object has a tag of the given number; otherwise,  `false` .

<b>Exceptions:</b>

 * System.ArgumentException:
TagValue is less than 0.

 * System.ArgumentNullException:
The parameter "obj" is null.

### HasTag

    public bool HasTag(
        PeterO.BigInteger bigTagValue);

Returns whether this object has a tag of the given number.

<b>Parameters:</b>

 * <i>bigTagValue</i>: The tag value to search for.

<b>Returns:</b>

 `true`  if this object has a tag of the given number; otherwise,  `false` .

<b>Exceptions:</b>

 * System.ArgumentNullException:
BigTagValue is null.

 * System.ArgumentException:
BigTagValue is less than 0.

### Insert

    public PeterO.Cbor.CBORObject Insert(
        int index,
        object valueOb);

Inserts an object at the specified position in this CBOR array.

<b>Parameters:</b>

 * <i>index</i>: Zero-based index to insert at.

 * <i>valueOb</i>: An object representing the value, which will be converted to a CBORObject. Can be null, in which case this value is converted to CBORObject.Null.

<b>Returns:</b>

This instance.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object is not an array.

 * System.ArgumentException:
The parameter <i>valueOb</i>
 has an unsupported type; or  <i>index</i>
 is not a valid index into this array.

### IsInfinity

    public bool IsInfinity();

Gets a value indicating whether this CBOR object represents infinity.

<b>Returns:</b>

 `true`  if this CBOR object represents infinity; otherwise, false .

### IsNaN

    public bool IsNaN();

Gets a value indicating whether this CBOR object represents a not-a-number value (as opposed to whether this object's type is not a number type).

<b>Returns:</b>

 `true`  if this CBOR object represents a not-a-number value (as opposed to whether this object's type is not a number type); otherwise,  `false` .

### IsNegativeInfinity

    public bool IsNegativeInfinity();

Gets a value indicating whether this CBOR object represents negative infinity.

<b>Returns:</b>

 `true`  if this CBOR object represents negative infinity; otherwise,  `false` .

### IsPositiveInfinity

    public bool IsPositiveInfinity();

Gets a value indicating whether this CBOR object represents positive infinity.

<b>Returns:</b>

 `true`  if this CBOR object represents positive infinity; otherwise,  `false` .

### Multiply

    public static PeterO.Cbor.CBORObject Multiply(
        PeterO.Cbor.CBORObject first,
        PeterO.Cbor.CBORObject second);

Multiplies two CBOR numbers.

<b>Parameters:</b>

 * <i>first</i>: A CBORObject object.

 * <i>second</i>: Another CBOR object.

<b>Returns:</b>

The product of the two numbers.

<b>Exceptions:</b>

 * System.ArgumentException:
Either or both operands are not numbers (as opposed to Not-a-Number, NaN).

### Negate

    public PeterO.Cbor.CBORObject Negate();

Gets this object's value with the sign reversed.

<b>Returns:</b>

The reversed-sign form of this number.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object's type is not a number type.

### NewArray

    public static PeterO.Cbor.CBORObject NewArray();

Creates a new empty CBOR array.

<b>Returns:</b>

A new CBOR array.

### NewMap

    public static PeterO.Cbor.CBORObject NewMap();

Creates a new empty CBOR map.

<b>Returns:</b>

A new CBOR map.

### Operator `+`

    public static PeterO.Cbor.CBORObject operator +(
        PeterO.Cbor.CBORObject a,
        PeterO.Cbor.CBORObject b);

Adds a CBORObject object and a CBORObject object.

<b>Parameters:</b>

 * <i>a</i>: A CBORObject object.

 * <i>b</i>: Another CBORObject object.

<b>Returns:</b>

The sum of the two objects.

### Operator `/`

    public static PeterO.Cbor.CBORObject operator /(
        PeterO.Cbor.CBORObject a,
        PeterO.Cbor.CBORObject b);

Divides a CBORObject object by the value of a CBORObject object.

<b>Parameters:</b>

 * <i>a</i>: A CBORObject object.

 * <i>b</i>: Another CBORObject object.

<b>Returns:</b>

The quotient of the two objects.

### Operator `%`

    public static PeterO.Cbor.CBORObject operator %(
        PeterO.Cbor.CBORObject a,
        PeterO.Cbor.CBORObject b);

Finds the remainder that results when a CBORObject object is divided by the value of a CBORObject object.

<b>Parameters:</b>

 * <i>a</i>: A CBORObject object.

 * <i>b</i>: Another CBORObject object.

<b>Returns:</b>

The remainder of the two numbers.

### Operator `*`

    public static PeterO.Cbor.CBORObject operator *(
        PeterO.Cbor.CBORObject a,
        PeterO.Cbor.CBORObject b);

Multiplies a CBORObject object by the value of a CBORObject object.

<b>Parameters:</b>

 * <i>a</i>: A CBORObject object.

 * <i>b</i>: Another CBORObject object.

<b>Returns:</b>

The product of the two numbers.

### Operator `-`

    public static PeterO.Cbor.CBORObject operator -(
        PeterO.Cbor.CBORObject a,
        PeterO.Cbor.CBORObject b);

Subtracts a CBORObject object from a CBORObject object.

<b>Parameters:</b>

 * <i>a</i>: A CBORObject object.

 * <i>b</i>: Another CBORObject object.

<b>Returns:</b>

The difference of the two objects.

### Read

    public static PeterO.Cbor.CBORObject Read(
        System.IO.Stream stream);

Reads an object in CBOR format from a data stream. This method will read from the stream until the end of the CBOR object is reached or an error occurs, whichever happens first.

<b>Parameters:</b>

 * <i>stream</i>: A readable data stream.

<b>Returns:</b>

A CBOR object that was read.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

 * PeterO.Cbor.CBORException:
There was an error in reading or parsing the data.

### Read

    public static PeterO.Cbor.CBORObject Read(
        System.IO.Stream stream,
        PeterO.Cbor.CBOREncodeOptions options);

Reads an object in CBOR format from a data stream. This method will read from the stream until the end of the CBOR object is reached or an error occurs, whichever happens first.

<b>Parameters:</b>

 * <i>stream</i>: A readable data stream.

 * <i>options</i>: A CBOREncodeOptions object.

<b>Returns:</b>

A CBOR object that was read.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

 * PeterO.Cbor.CBORException:
There was an error in reading or parsing the data.

### ReadJSON

    public static PeterO.Cbor.CBORObject ReadJSON(
        System.IO.Stream stream);

Generates a CBOR object from a data stream in JavaScript Object Notation (JSON) format. The JSON stream may begin with a byte-order mark (U+FEFF). Since version 2.0, the JSON stream can be in UTF-8, UTF-16, or UTF-32 encoding; the encoding is detected by assuming that the first character read must be a byte-order mark or a nonzero basic character (U+0001 to U+007F). (In previous versions, only UTF-8 was allowed.)If a JSON object has the same key, only the last given value will be used for each duplicated key.

<b>Parameters:</b>

 * <i>stream</i>: A readable data stream. The sequence of bytes read from the data stream must contain a single JSON object and not multiple objects.

<b>Returns:</b>

A CBORObject object.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

 * System.IO.IOException:
An I/O error occurred.

 * PeterO.Cbor.CBORException:
The data stream contains invalid encoding or is not in JSON format.

### ReadJSON

    public static PeterO.Cbor.CBORObject ReadJSON(
        System.IO.Stream stream,
        PeterO.Cbor.CBOREncodeOptions options);

Generates a CBOR object from a data stream in JavaScript Object Notation (JSON) format. The JSON stream may begin with a byte-order mark (U+FEFF). Since version 2.0, the JSON stream can be in UTF-8, UTF-16, or UTF-32 encoding; the encoding is detected by assuming that the first character read must be a byte-order mark or a nonzero basic character (U+0001 to U+007F). (In previous versions, only UTF-8 was allowed.)By default, if a JSON object has the same key, only the last given value will be used for each duplicated key.

<b>Parameters:</b>

 * <i>stream</i>: A readable data stream. The sequence of bytes read from the data stream must contain a single JSON object and not multiple objects.

 * <i>options</i>: A CBOREncodeOptions object.

<b>Returns:</b>

A CBORObject object.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

 * System.IO.IOException:
An I/O error occurred.

 * PeterO.Cbor.CBORException:
The data stream contains invalid encoding or is not in JSON format.

### Remainder

    public static PeterO.Cbor.CBORObject Remainder(
        PeterO.Cbor.CBORObject first,
        PeterO.Cbor.CBORObject second);

Finds the remainder that results when a CBORObject object is divided by the value of a CBORObject object.

<b>Parameters:</b>

 * <i>first</i>: A CBORObject object.

 * <i>second</i>: Another CBOR object.

<b>Returns:</b>

The remainder of the two numbers.

### Remove

    public bool Remove(
        PeterO.Cbor.CBORObject obj);

If this object is an array, removes the first instance of the specified item from the array. If this object is a map, removes the item with the given key from the map.

<b>Parameters:</b>

 * <i>obj</i>: The item or key to remove.

<b>Returns:</b>

 `true`  if the item was removed; otherwise,  `false` .

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>obj</i>
 is null (as opposed to CBORObject.Null).

 * System.InvalidOperationException:
The object is not an array or map.

### Set

    public PeterO.Cbor.CBORObject Set(
        object key,
        object valueOb);

Maps an object to a key in this CBOR map, or adds the value if the key doesn't exist.

<b>Parameters:</b>

 * <i>key</i>: An object representing the key, which will be converted to a CBORObject. Can be null, in which case this value is converted to CBORObject.Null.

 * <i>valueOb</i>: An object representing the value, which will be converted to a CBORObject. Can be null, in which case this value is converted to CBORObject.Null.

<b>Returns:</b>

This instance.

<b>Exceptions:</b>

 * System.InvalidOperationException:
This object is not a map.

 * System.ArgumentException:
The parameter <i>key</i>
 or  <i>valueOb</i>
 has an unsupported type.

### Subtract

    public static PeterO.Cbor.CBORObject Subtract(
        PeterO.Cbor.CBORObject first,
        PeterO.Cbor.CBORObject second);

Finds the difference between two CBOR number objects.

<b>Parameters:</b>

 * <i>first</i>: A CBORObject object.

 * <i>second</i>: Another CBOR object.

<b>Returns:</b>

The difference of the two objects.

<b>Exceptions:</b>

 * System.ArgumentException:
Either or both operands are not numbers (as opposed to Not-a-Number, NaN).

### ToJSONString

    public string ToJSONString();

Converts this object to a string in JavaScript Object Notation (JSON) format. This function works not only with arrays and maps, but also integers, strings, byte arrays, and other JSON data types. Notes:

 * If this object contains maps with non-string keys, the keys are converted to JSON strings before writing the map as a JSON string.

 * If a number in the form of an arbitrary-precision binary float has a very high binary exponent, it will be converted to a double before being converted to a JSON string. (The resulting double could overflow to infinity, in which case the arbitrary-precision binary float is converted to null.)

 * The string will not begin with a byte-order mark (U+FEFF); RFC 7159 (the JSON specification) forbids placing a byte-order mark at the beginning of a JSON string.

 * Byte strings are converted to Base64 URL by default.

 * Rational numbers will be converted to their exact form, if possible, otherwise to a high-precision approximation. (The resulting approximation could overflow to infinity, in which case the rational number is converted to null.)

 * Simple values other than true and false will be converted to null. (This doesn't include floating-point numbers.)

 * Infinity and not-a-number will be converted to null.

<b>Returns:</b>

A text string containing the converted object.

### ToString

    public override string ToString();

Returns this CBOR object in string form. The format is intended to be human-readable, not machine-readable, and the format may change at any time.

<b>Returns:</b>

A text representation of this object.

### Untag

    public PeterO.Cbor.CBORObject Untag();

Gets an object with the same value as this one but without the tags it has, if any. If this object is an array, map, or byte string, the data will not be copied to the returned object, so changes to the returned object will be reflected in this one.

<b>Returns:</b>

A CBORObject object.

### UntagOne

    public PeterO.Cbor.CBORObject UntagOne();

Gets an object with the same value as this one but without this object's outermost tag, if any. If this object is an array, map, or byte string, the data will not be copied to the returned object, so changes to the returned object will be reflected in this one.

<b>Returns:</b>

A CBORObject object.

### Write

    public static void Write(
        bool value,
        System.IO.Stream stream);

Writes a Boolean value in CBOR format to a data stream.

<b>Parameters:</b>

 * <i>value</i>: The value to write.

 * <i>stream</i>: A writable data stream.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

 * System.IO.IOException:
An I/O error occurred.

### Write

    public static void Write(
        byte value,
        System.IO.Stream stream);

Writes a byte (0 to 255) in CBOR format to a data stream. If the value is less than 24, writes that byte. If the value is 25 to 255, writes the byte 24, then this byte's value.

<b>Parameters:</b>

 * <i>value</i>: The value to write.

 * <i>stream</i>: A writable data stream.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

 * System.IO.IOException:
An I/O error occurred.

### Write

    public static void Write(
        char value,
        System.IO.Stream stream);

Writes a Unicode character as a string in CBOR format to a data stream.

<b>Parameters:</b>

 * <i>value</i>: The value to write.

 * <i>stream</i>: A writable data stream.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

 * System.ArgumentException:
The parameter <i>value</i>
 is a surrogate code point.

 * System.IO.IOException:
An I/O error occurred.

### Write

    public static void Write(
        double value,
        System.IO.Stream stream);

Writes a 64-bit floating-point number in CBOR format to a data stream.

<b>Parameters:</b>

 * <i>value</i>: The value to write.

 * <i>stream</i>: A writable data stream.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

 * System.IO.IOException:
An I/O error occurred.

### Write

    public static void Write(
        float value,
        System.IO.Stream s);

Writes a 32-bit floating-point number in CBOR format to a data stream.

<b>Parameters:</b>

 * <i>value</i>: The value to write.

 * <i>s</i>: A writable data stream.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>s</i>
 is null.

 * System.IO.IOException:
An I/O error occurred.

### Write

    public static void Write(
        int value,
        System.IO.Stream stream);

Writes a 32-bit signed integer in CBOR format to a data stream.

<b>Parameters:</b>

 * <i>value</i>: The value to write.

 * <i>stream</i>: A writable data stream.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

 * System.IO.IOException:
An I/O error occurred.

### Write

    public static void Write(
        long value,
        System.IO.Stream stream);

Writes a 64-bit signed integer in CBOR format to a data stream.

<b>Parameters:</b>

 * <i>value</i>: The value to write.

 * <i>stream</i>: A writable data stream.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

 * System.IO.IOException:
An I/O error occurred.

### Write

    public static void Write(
        object objValue,
        System.IO.Stream output,
        PeterO.Cbor.CBOREncodeOptions options);

Writes an arbitrary object to a CBOR data stream. Currently, the following objects are supported:

 * Lists of CBORObject.

 * Maps of CBORObject.

 * Null.

 * Byte arrays, which will always be written as definite-length byte strings.

 * String objects, which will be written as indefinite-length text strings if their size exceeds a certain threshold (this behavior may change in future versions of this library).

 * Any object accepted by the FromObject static methods.

<b>Parameters:</b>

 * <i>objValue</i>: The arbitrary object to be serialized. Can be null.

 * <i>output</i>: A writable data stream.

 * <i>options</i>: CBOR options for encoding the CBOR object to bytes.

<b>Exceptions:</b>

 * System.ArgumentException:
The object's type is not supported.

 * System.ArgumentNullException:
The parameter <i>options</i>
 or  <i>output</i>
 is null.

### Write

    public static void Write(
        object objValue,
        System.IO.Stream stream);

Writes a CBOR object to a CBOR data stream. See the three-parameter Write method that takes a CBOREncodeOptions.

<b>Parameters:</b>

 * <i>objValue</i>: An arbitrary object.

 * <i>stream</i>: A writable data stream.

### Write

    public static void Write(
        PeterO.BigInteger bigint,
        System.IO.Stream stream);

Writes a big integer in CBOR format to a data stream.

<b>Parameters:</b>

 * <i>bigint</i>: Big integer to write. Can be null.

 * <i>stream</i>: A writable data stream.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

 * System.IO.IOException:
An I/O error occurred.

### Write

    public static void Write(
        PeterO.Cbor.CBORObject value,
        System.IO.Stream stream);

Writes a CBOR object to a CBOR data stream.

<b>Parameters:</b>

 * <i>value</i>: The value to write. Can be null.

 * <i>stream</i>: A writable data stream.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

### Write

    public static void Write(
        PeterO.ExtendedDecimal bignum,
        System.IO.Stream stream);

Writes a decimal floating-point number in CBOR format to a data stream, as follows:

 * If the value is null, writes the byte 0xF6.

 * If the value is negative zero, infinity, or NaN, converts the number to a  `double`  and writes that  `double` . If negative zero should not be written this way, use the Plus method to convert the value beforehand.

 * If the value has an exponent of zero, writes the value as an unsigned integer or signed integer if the number can fit either type or as a big integer otherwise.

 * In all other cases, writes the value as a decimal number.

<b>Parameters:</b>

 * <i>bignum</i>: The arbitrary-precision decimal number to write. Can be null.

 * <i>stream</i>: Stream to write to.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

 * System.IO.IOException:
An I/O error occurred.

### Write

    public static void Write(
        PeterO.ExtendedFloat bignum,
        System.IO.Stream stream);

Writes a binary floating-point number in CBOR format to a data stream as follows:

 * If the value is null, writes the byte 0xF6.

 * If the value is negative zero, infinity, or NaN, converts the number to a  `double`  and writes that  `double` . If negative zero should not be written this way, use the Plus method to convert the value beforehand.

 * If the value has an exponent of zero, writes the value as an unsigned integer or signed integer if the number can fit either type or as a big integer otherwise.

 * In all other cases, writes the value as a big float.

<b>Parameters:</b>

 * <i>bignum</i>: An arbitrary-precision binary float.

 * <i>stream</i>: A writable data stream.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

 * System.IO.IOException:
An I/O error occurred.

### Write

    public static void Write(
        PeterO.ExtendedRational rational,
        System.IO.Stream stream);

Writes a rational number in CBOR format to a data stream.

<b>Parameters:</b>

 * <i>rational</i>: An arbitrary-precision rational number.

 * <i>stream</i>: A writable data stream.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

 * System.IO.IOException:
An I/O error occurred.

### Write

    public static void Write(
        sbyte value,
        System.IO.Stream stream);

Writes an 8-bit signed integer in CBOR format to a data stream.

<b>Parameters:</b>

 * <i>value</i>: An 8-bit signed integer.

 * <i>stream</i>: A writable data stream.

### Write

    public static void Write(
        short value,
        System.IO.Stream stream);

Writes a 16-bit signed integer in CBOR format to a data stream.

<b>Parameters:</b>

 * <i>value</i>: The value to write.

 * <i>stream</i>: A writable data stream.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

 * System.IO.IOException:
An I/O error occurred.

### Write

    public static void Write(
        string str,
        System.IO.Stream stream);

Writes a string in CBOR format to a data stream. The string will be encoded using indefinite-length encoding if its length exceeds a certain threshold (this behavior may change in future versions of this library).

<b>Parameters:</b>

 * <i>str</i>: The string to write. Can be null.

 * <i>stream</i>: A writable data stream.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

 * System.IO.IOException:
An I/O error occurred.

### Write

    public static void Write(
        string str,
        System.IO.Stream stream,
        PeterO.Cbor.CBOREncodeOptions options);

Writes a string in CBOR format to a data stream.

<b>Parameters:</b>

 * <i>str</i>: The string to write. Can be null.

 * <i>stream</i>: A writable data stream.

 * <i>options</i>: Options for encoding the data to CBOR.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

 * System.IO.IOException:
An I/O error occurred.

### Write

    public static void Write(
        uint value,
        System.IO.Stream stream);

Writes a 32-bit unsigned integer in CBOR format to a data stream.

<b>Parameters:</b>

 * <i>value</i>: A 32-bit unsigned integer.

 * <i>stream</i>: A writable data stream.

### Write

    public static void Write(
        ulong value,
        System.IO.Stream stream);

Writes a 64-bit unsigned integer in CBOR format to a data stream.

<b>Parameters:</b>

 * <i>value</i>: A 64-bit unsigned integer.

 * <i>stream</i>: A writable data stream.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

### Write

    public static void Write(
        ushort value,
        System.IO.Stream stream);

Writes a 16-bit unsigned integer in CBOR format to a data stream.

<b>Parameters:</b>

 * <i>value</i>: A 16-bit unsigned integer.

 * <i>stream</i>: A writable data stream.

### WriteJSON

    public static void WriteJSON(
        object obj,
        System.IO.Stream outputStream);

Converts an arbitrary object to a string in JavaScript Object Notation (JSON) format, as in the ToJSONString method, and writes that string to a data stream in UTF-8.

<b>Parameters:</b>

 * <i>obj</i>: An arbitrary object.

 * <i>outputStream</i>: A writable data stream.

### WriteJSONTo

    public void WriteJSONTo(
        System.IO.Stream outputStream);

Converts this object to a string in JavaScript Object Notation (JSON) format, as in the ToJSONString method, and writes that string to a data stream in UTF-8.

<b>Parameters:</b>

 * <i>outputStream</i>: A writable data stream.

<b>Exceptions:</b>

 * System.IO.IOException:
An I/O error occurred.

 * System.ArgumentNullException:
The parameter <i>outputStream</i>
 is null.

### WriteTo

    public void WriteTo(
        System.IO.Stream stream);

Writes this CBOR object to a data stream.

<b>Parameters:</b>

 * <i>stream</i>: A writable data stream.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

 * System.IO.IOException:
An I/O error occurred.

### WriteTo

    public void WriteTo(
        System.IO.Stream stream,
        PeterO.Cbor.CBOREncodeOptions options);

Writes this CBOR object to a data stream.

<b>Parameters:</b>

 * <i>stream</i>: A writable data stream.

 * <i>options</i>: Options for encoding the data to CBOR.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>stream</i>
 is null.

 * System.IO.IOException:
An I/O error occurred.
