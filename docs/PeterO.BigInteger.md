## PeterO.BigInteger

    public sealed class BigInteger :
        System.IComparable,
        System.IEquatable

This class is largely obsolete. It will be replaced by a new version of this class in a different namespace/package and library, called  `PeterO.Numbers.EInteger`  in the `PeterO.Numbers` library (in .NET), or  `com.upokecenter.numbers.EInteger`  in the `com.github.peteroupc/numbers` cartifact (in Java). This new class can be used in the `CBORObject.FromObject(object)`  method (by including the new library in your code, among other things), but this version of the CBOR library doesn't include any methods that explicitly take an `EInteger`  as a parameter or return value.

 An arbitrary-precision integer.Thread safety: Instances of this class are immutable, so they are inherently safe for use by multiple threads. Multiple instances of this object with the same value are interchangeable, but they should be compared using the "Equals" method rather than the "==" operator.

This class is largely obsolete. It will be replaced by a new version of this class in a different namespace/package and library, called  `PeterO.Numbers.EInteger`  in the `PeterO.Numbers` library (in .NET), or  `com.upokecenter.numbers.EInteger`  in the `com.github.peteroupc/numbers` artifact (in Java). This new class can be used in the `CBORObject.FromObject(object)`  method (by including the new library in your code, among other things), but this version of the CBOR library doesn't include any methods that explicitly take an `EInteger`  as a parameter or return value.

 An arbitrary-precision integer.Thread safety: Instances of this class are immutable, so they are inherently safe for use by multiple threads. Multiple instances of this object with the same value are interchangeable, but they should be compared using the "Equals" method rather than the "==" operator.

This class is largely obsolete. It will be replaced by a new version of this class in a different namespace/package and library, called  `PeterO.Numbers.EInteger`  in the `PeterO.Numbers` library (in .NET), or  `com.upokecenter.numbers.EInteger`  in the `com.github.peteroupc/numbers` artifact (in Java). This new class can be used in the `CBORObject.FromObject(object)`  method (by including the new library in your code, among other things), but this version of the CBOR library doesn't include any methods that explicitly take an `EInteger`  as a parameter or return value.

 An arbitrary-precision integer.Thread safety: Instances of this class are immutable, so they are inherently safe for use by multiple threads. Multiple instances of this object with the same value are interchangeable, but they should be compared using the "Equals" method rather than the "==" operator.

### ONE

    public static readonly PeterO.BigInteger ONE;

BigInteger for the number one.

### TEN

    public static readonly PeterO.BigInteger TEN;

BigInteger for the number ten.

### ZERO

    public static readonly PeterO.BigInteger ZERO;

BigInteger for the number zero.

### IsEven

    public bool IsEven { get; }

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Gets a value indicating whether this value is even.

<b>Returns:</b>

<c>true</c> if this value is even; otherwise, <c>false</c>.  `true`  if this value is even; otherwise,  `false` .

### IsPowerOfTwo

    public bool IsPowerOfTwo { get; }

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Gets a value indicating whether this object's value is a power of two. (NOTE: This version allows negative numbers to be powers of two. In the EInteger version, only positive numbers will be considered powers of two.).

<b>Returns:</b>

<c>true</c> if this object&#x27;s value is a power of two; otherwise, <c>false</c>.. (NOTE: This version allows negative numbers to be powers of two. In the EInteger version, only positive numbers will be considered powers of two.).  `true`  if this object's value is a power of two; otherwise,  `false` .

### IsZero

    public bool IsZero { get; }

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Gets a value indicating whether this value is 0.

<b>Returns:</b>

<c>true</c> if this value is 0; otherwise, <c>false</c>.  `true`  if this value is 0; otherwise,  `false` .

### One

    public static PeterO.BigInteger One { get; }

Gets the arbitrary-precision integer for one.

<b>Returns:</b>

The arbitrary-precision integer for one.

### Sign

    public int Sign { get; }

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Gets the sign of this object's value.

<b>Returns:</b>

0 if this value is zero; -1 if this value is negative, or 1 if this value is positive.

### Zero

    public static PeterO.BigInteger Zero { get; }

Gets the arbitrary-precision integer for zero.

<b>Returns:</b>

The arbitrary-precision integer for zero.

### abs

    public PeterO.BigInteger abs();

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Returns the absolute value of this object's value.

<b>Returns:</b>

This object's value with the sign removed.

### Abs

    public static PeterO.BigInteger Abs(
        PeterO.BigInteger thisValue);

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Gets this integer's absolute value.

<b>Parameters:</b>

 * <i>thisValue</i>: Another arbitrary-precision integer.

<b>Returns:</b>

An arbitrary-precision integer.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>thisValue</i>
 is null.

### add

    public PeterO.BigInteger add(
        PeterO.BigInteger bigintAugend);

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Adds this object and another object.

<b>Parameters:</b>

 * <i>bigintAugend</i>: Another arbitrary-precision integer.

<b>Returns:</b>

The sum of the two objects.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>bigintAugend</i>
 is null.

### And

    public static PeterO.BigInteger And(
        PeterO.BigInteger a,
        PeterO.BigInteger b);

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Does an AND operation between two arbitrary-precision integer values.

Each arbitrary-precision integer is treated as a two's complement representation for the purposes of this operator.

<b>Parameters:</b>

 * <i>a</i>: The first arbitrary-precision integer.

 * <i>b</i>: The second arbitrary-precision integer.

<b>Returns:</b>

An arbitrary-precision integer.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>a</i>
 or  <i>b</i>
 is null.

### bitLength

    public int bitLength();

Finds the minimum number of bits needed to represent this object's value, except for its sign. If the value is negative, finds the number of bits in a value equal to this object's absolute value minus 1.

<b>Returns:</b>

The number of bits in this object's value. Returns 0 if this object's value is 0 or negative 1.

### canFitInInt

    public bool canFitInInt();

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Returns whether this object's value can fit in a 32-bit signed integer.

<b>Returns:</b>

 `true`  if this object's value is MinValue or greater, and MaxValue or less; otherwise,  `false` .

### CompareTo

    public sealed int CompareTo(
        PeterO.BigInteger other);

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Compares an arbitrary-precision integer with this instance.

<b>Parameters:</b>

 * <i>other</i>: The parameter  <i>other</i>
 is not documented yet.

<b>Returns:</b>

Zero if the values are equal; a negative number if this instance is less, or a positive number if this instance is greater.

### divide

    public PeterO.BigInteger divide(
        PeterO.BigInteger bigintDivisor);

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Divides this instance by the value of an arbitrary-precision integer. The result is rounded down (the fractional part is discarded). Except if the result is 0, it will be negative if this object is positive and the other is negative, or vice versa, and will be positive if both are positive or both are negative.

<b>Parameters:</b>

 * <i>bigintDivisor</i>: Another arbitrary-precision integer.

<b>Returns:</b>

The quotient of the two objects.

<b>Exceptions:</b>

 * System.DivideByZeroException:
The divisor is zero.

 * System.ArgumentNullException:
The parameter <i>bigintDivisor</i>
 is null.

 * System.DivideByZeroException:
Attempted to divide by zero.

### divideAndRemainder

    public PeterO.BigInteger[] divideAndRemainder(
        PeterO.BigInteger divisor);

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Divides this object by another big integer and returns the quotient and remainder.

<b>Parameters:</b>

 * <i>divisor</i>: An arbitrary-precision integer.

<b>Returns:</b>

An array with two big integers: the first is the quotient, and the second is the remainder.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>divisor</i>
 is null.

 * System.DivideByZeroException:
The parameter <i>divisor</i>
 is 0.

 * System.DivideByZeroException:
Attempted to divide by zero.

### Equals

    public override bool Equals(
        object obj);

Determines whether this object and another object are equal.

<b>Parameters:</b>

 * <i>obj</i>: An arbitrary object.

<b>Returns:</b>

 `true`  if this object and another object are equal; otherwise,  `false` .

### Equals

    public sealed bool Equals(
        PeterO.BigInteger other);

Returns whether this number's value equals another number's value.

<b>Parameters:</b>

 * <i>other</i>: An arbitrary-precision integer.

<b>Returns:</b>

 `true`  if this number's value equals another number's value; otherwise,  `false` .

### fromByteArray

    public static PeterO.BigInteger fromByteArray(
        byte[] bytes,
        bool littleEndian);

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Initializes an arbitrary-precision integer from an array of bytes.

<b>Parameters:</b>

 * <i>bytes</i>: A byte array.

 * <i>littleEndian</i>: A Boolean object.

<b>Returns:</b>

An arbitrary-precision integer.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>bytes</i>
 is null.

### fromBytes

    public static PeterO.BigInteger fromBytes(
        byte[] bytes,
        bool littleEndian);

Initializes an arbitrary-precision integer from an array of bytes.

<b>Parameters:</b>

 * <i>bytes</i>: A byte array consisting of the two's-complement integer representation of the arbitrary-precision integer to create. The last byte contains the lowest 8-bits, the next-to-last contains the next lowest 8 bits, and so on. To encode negative numbers, take the absolute value of the number, subtract by 1, encode the number into bytes, XOR each byte, and if the most-significant bit of the first byte isn't set, add an additional byte at the start with the value 255. For little-endian, the byte order is reversed from the byte order just discussed.

 * <i>littleEndian</i>: If true, the byte order is little-endian, or least-significant-byte first. If false, the byte order is big-endian, or most-significant-byte first.

<b>Returns:</b>

An arbitrary-precision integer. Returns 0 if the byte array's length is 0.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>bytes</i>
 is null.

### fromRadixString

    public static PeterO.BigInteger fromRadixString(
        string str,
        int radix);

Converts a string to an arbitrary-precision integer.

The following example (C#) converts a number in the orm of a hex string to a big integer.    public static arbitrary-precision integer HexToBigInteger(string
    hexString) {  // Parse the hexadecimal string as a big integer. Will  //
    throw a FormatException if the parsing fails var bigInteger =
    arbitrary-precision integer.fromRadixString(hexString, 16);  // Optional:
    Check if the parsed integer is negative if (bigInteger.Sign < 0) {
    throw new FormatException("negative hex string"); } return bigInteger; }

<b>Parameters:</b>

 * <i>str</i>: A text string. The string must contain only characters allowed by the given radix, except that it may start with a minus sign ("-", U+002D) to indicate a negative number. The string is not allowed to contain white space characters, including spaces.

 * <i>radix</i>: A base from 2 to 36. Depending on the radix, the string can use the basic digits 0 to 9 (U+0030 to U+0039) and then the basic letters A to Z (U+0041 to U+005A). For example, 0-9 in radix 10, and 0-9, then A-F in radix 16.

<b>Returns:</b>

An arbitrary-precision integer with the same value as given in the string.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>str</i>
 is null.

 * System.ArgumentException:
The parameter <i>radix</i>
 is less than 2 or greater than 36.

 * System.FormatException:
The string is empty or in an invalid format.

### fromRadixSubstring

    public static PeterO.BigInteger fromRadixSubstring(
        string str,
        int radix,
        int index,
        int endIndex);

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Converts a portion of a string to an arbitrary-precision integer in a given radix.

<b>Parameters:</b>

 * <i>str</i>: A text string. The desired portion of the string must contain only characters allowed by the given radix, except that it may start with a minus sign ("-", U+002D) to indicate a negative number. The desired portion is not allowed to contain white space characters, including spaces.

 * <i>radix</i>: A base from 2 to 36. Depending on the radix, the string can use the basic digits 0 to 9 (U+0030 to U+0039) and then the basic letters A to Z (U+0041 to U+005A). For example, 0-9 in radix 10, and 0-9, then A-F in radix 16.

 * <i>index</i>: The index of the string that starts the string portion.

 * <i>endIndex</i>: The index of the string that ends the string portion. The length will be index + endIndex - 1.

<b>Returns:</b>

An arbitrary-precision integer with the same value as given in the string portion.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>str</i>
 is null.

 * System.ArgumentException:
The parameter <i>index</i>
 is less than 0,  <i>endIndex</i>
 is less than 0, or either is greater than the string's length, or  <i>endIndex</i>
 is less than <i>index</i>
.

 * System.FormatException:
The string portion is empty or in an invalid format.

### fromString

    public static PeterO.BigInteger fromString(
        string str);

Converts a string to an arbitrary-precision integer.

<b>Parameters:</b>

 * <i>str</i>: A text string. The string must contain only basic digits 0 to 9 (U+0030 to U+0039), except that it may start with a minus sign ("-", U+002D) to indicate a negative number. The string is not allowed to contain white space characters, including spaces.

<b>Returns:</b>

An arbitrary-precision integer with the same value as given in the string.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>str</i>
 is null.

 * System.FormatException:
The parameter  <i>str</i>
 is in an invalid format.

### fromSubstring

    public static PeterO.BigInteger fromSubstring(
        string str,
        int index,
        int endIndex);

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Converts a portion of a string to an arbitrary-precision integer.

<b>Parameters:</b>

 * <i>str</i>: A text string. The desired portion of the string must contain only basic digits 0 to 9 (U+0030 to U+0039), except that it may start with a minus sign ("-", U+002D) to indicate a negative number. The desired portion is not allowed to contain white space characters, including spaces.

 * <i>index</i>: The index of the string that starts the string portion.

 * <i>endIndex</i>: The index of the string that ends the string portion. The length will be index + endIndex - 1.

<b>Returns:</b>

An arbitrary-precision integer with the same value as given in the string portion.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>str</i>
 is null.

 * System.ArgumentException:
The parameter <i>index</i>
 is less than 0,  <i>endIndex</i>
 is less than 0, or either is greater than the string's length, or  <i>endIndex</i>
 is less than <i>index</i>
.

 * System.FormatException:
The string portion is empty or in an invalid format.

### gcd

    public PeterO.BigInteger gcd(
        PeterO.BigInteger bigintSecond);

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Returns the greatest common divisor of two integers. The greatest common divisor (GCD) is also known as the greatest common factor (GCF).

<b>Parameters:</b>

 * <i>bigintSecond</i>: Another arbitrary-precision integer.

<b>Returns:</b>

An arbitrary-precision integer.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>bigintSecond</i>
 is null.

### GetBits

    public long GetBits(
        int index,
        int numberBits);

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Gets a series of bits from the two's complement representation of this number's value.

<b>Parameters:</b>

 * <i>index</i>: Zero-based index of the first bit to retrieve.

 * <i>numberBits</i>: The number of bits to retrieve, from 0 to 64.

<b>Returns:</b>

A 64-bit signed integer containing the bits retrieved. The least significant bit is first.

<b>Exceptions:</b>

 * System.ArgumentException:
The parameter <i>numberBits</i>
 is less than 0 or greater than 64.

### getDigitCount

    public int getDigitCount();

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Finds the number of decimal digits this number has.

<b>Returns:</b>

The number of decimal digits. Returns 1 if this object' s value is 0.

### GetHashCode

    public override int GetHashCode();

Returns the hash code for this instance.

<b>Returns:</b>

A 32-bit signed integer.

### getLowBit

    public int getLowBit();

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Gets the lowest set bit in this number's absolute value.

<b>Returns:</b>

The lowest bit set in the number, starting at 0. Returns 0 if this value is 0 or odd. (NOTE: In future versions, may return -1 instead if this value is 0.).

### getLowestSetBit

    public int getLowestSetBit();

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

See  `getLowBit()`

<b>Returns:</b>

See getLowBit().

### getUnsignedBitLength

    public int getUnsignedBitLength();

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Finds the minimum number of bits needed to represent this object's absolute value.

<b>Returns:</b>

The number of bits in this object's value. Returns 0 if this object's value is 0, and returns 1 if the value is negative 1.

### GreatestCommonDivisor

    public static PeterO.BigInteger GreatestCommonDivisor(
        PeterO.BigInteger bigintFirst,
        PeterO.BigInteger bigintSecond);

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Finds the greatest common divisor/greatest common factor (GCD/GCF) of two big integers.

<b>Parameters:</b>

 * <i>bigintFirst</i>: The first operand.

 * <i>bigintSecond</i>: The second operand.

<b>Returns:</b>

The greatest common divisor.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>bigintFirst</i>
 is null.

### intValue

    public int intValue();

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Converts this object's value to a 32-bit signed integer.

<b>Returns:</b>

A 32-bit signed integer.

<b>Exceptions:</b>

 * System.OverflowException:
This object's value is too big to fit a 32-bit signed integer.

### intValueChecked

    public int intValueChecked();

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Converts this object's value to a 32-bit signed integer.

<b>Returns:</b>

A 32-bit signed integer.

<b>Exceptions:</b>

 * System.OverflowException:
This object's value is too big to fit a 32-bit signed integer.

### intValueUnchecked

    public int intValueUnchecked();

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Converts this object's value to a 32-bit signed integer. If the value can't fit in a 32-bit integer, returns the lower 32 bits of this object's two's complement representation (in which case the return value might have a different sign than this object's value).

<b>Returns:</b>

A 32-bit signed integer.

### longValue

    public long longValue();

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Converts this object's value to a 64-bit signed integer.

<b>Returns:</b>

A 64-bit signed integer.

<b>Exceptions:</b>

 * System.OverflowException:
This object's value is too big to fit a 64-bit signed integer.

### longValueChecked

    public long longValueChecked();

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Converts this object's value to a 64-bit signed integer, throwing an exception if it can't fit.

<b>Returns:</b>

A 64-bit signed integer.

<b>Exceptions:</b>

 * System.OverflowException:
This object's value is too big to fit a 64-bit signed integer.

### longValueUnchecked

    public long longValueUnchecked();

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Converts this object's value to a 64-bit signed integer. If the value can't fit in a 64-bit integer, returns the lower 64 bits of this object's two's complement representation (in which case the return value might have a different sign than this object's value).

<b>Returns:</b>

A 64-bit signed integer.

### mod

    public PeterO.BigInteger mod(
        PeterO.BigInteger divisor);

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Finds the modulus remainder that results when this instance is divided by the value of an arbitrary-precision integer. The modulus remainder is the same as the normal remainder if the normal remainder is positive, and equals divisor plus normal remainder if the normal remainder is negative.

<b>Parameters:</b>

 * <i>divisor</i>: A divisor greater than 0 (the modulus).

<b>Returns:</b>

An arbitrary-precision integer.

<b>Exceptions:</b>

 * System.ArithmeticException:
The parameter <i>divisor</i>
 is negative.

 * System.ArgumentNullException:
The parameter <i>divisor</i>
 is null.

### ModPow

    public PeterO.BigInteger ModPow(
        PeterO.BigInteger pow,
        PeterO.BigInteger mod);

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Calculates the remainder when an arbitrary-precision integer raised to a certain power is divided by another arbitrary-precision integer.

<b>Parameters:</b>

 * <i>pow</i>: Another arbitrary-precision integer.

 * <i>mod</i>: An arbitrary-precision integer. (3).

<b>Returns:</b>

An arbitrary-precision integer.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>pow</i>
 or  <i>mod</i>
 is null.

### ModPow

    public static PeterO.BigInteger ModPow(
        PeterO.BigInteger bigintValue,
        PeterO.BigInteger pow,
        PeterO.BigInteger mod);

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Calculates the remainder when an arbitrary-precision integer raised to a certain power is divided by another arbitrary-precision integer.

<b>Parameters:</b>

 * <i>bigintValue</i>: The number to raise to a power.

 * <i>pow</i>: The exponent to raise the number to.

 * <i>mod</i>: The modulus.

<b>Returns:</b>

The value (  <i>bigintValue</i>
 ^  <i>pow</i>
 )%  <i>mod</i>
.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>bigintValue</i>
 is null.

### multiply

    public PeterO.BigInteger multiply(
        PeterO.BigInteger bigintMult);

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Multiplies this instance by the value of an arbitrary-precision integer object.

<b>Parameters:</b>

 * <i>bigintMult</i>: Another arbitrary-precision integer.

<b>Returns:</b>

The product of the two numbers.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>bigintMult</i>
 is null.

### negate

    public PeterO.BigInteger negate();

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Gets the value of this object with the sign reversed.

<b>Returns:</b>

This object's value with the sign reversed.

### Not

    public static PeterO.BigInteger Not(
        PeterO.BigInteger valueA);

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Returns an arbitrary-precision integer with every bit flipped.

<b>Parameters:</b>

 * <i>valueA</i>: Another arbitrary-precision integer.

<b>Returns:</b>

An arbitrary-precision integer.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>valueA</i>
 is null.

### Operator `+`

    public static PeterO.BigInteger operator +(
        PeterO.BigInteger bthis,
        PeterO.BigInteger augend);

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Adds an arbitrary-precision integer and an arbitrary-precision integer object.

<b>Parameters:</b>

 * <i>bthis</i>: The parameter  <i>bthis</i>
 is not documented yet.

 * <i>augend</i>: The parameter  <i>augend</i>
 is not documented yet.

<b>Returns:</b>

The sum of the two objects.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>bthis</i>
 is null.

### Operator `/`

    public static PeterO.BigInteger operator /(
        PeterO.BigInteger dividend,
        PeterO.BigInteger divisor);

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Divides an arbitrary-precision integer by the value of an arbitrary-precision integer object.

<b>Parameters:</b>

 * <i>dividend</i>: The number that will be divided by the divisor.

 * <i>divisor</i>: The number to divide by.

<b>Returns:</b>

The quotient of the two objects.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>dividend</i>
 is null.

### Operator `>`

    public static bool operator >(
        PeterO.BigInteger thisValue,
        PeterO.BigInteger otherValue);

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Determines whether an arbitrary-precision integer is greater than another arbitrary-precision integer.

<b>Parameters:</b>

 * <i>thisValue</i>: The first arbitrary-precision integer.

 * <i>otherValue</i>: The second arbitrary-precision integer.

<b>Returns:</b>

 `true`  if  <i>thisValue</i>
 is greater than <i>otherValue</i>
 ; otherwise,  `false` .

### Operator `>=`

    public static bool operator >=(
        PeterO.BigInteger thisValue,
        PeterO.BigInteger otherValue);

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Determines whether an arbitrary-precision integer value is greater than another arbitrary-precision integer.

<b>Parameters:</b>

 * <i>thisValue</i>: The first arbitrary-precision integer.

 * <i>otherValue</i>: The second arbitrary-precision integer.

<b>Returns:</b>

 `true`  if  <i>thisValue</i>
 is at least  <i>otherValue</i>
 ; otherwise,  `false` .

### Operator `<<`

    public static PeterO.BigInteger operator <<(
        PeterO.BigInteger bthis,
        int bitCount);

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Returns an arbitrary-precision integer with the bits shifted to the left.

<b>Parameters:</b>

 * <i>bthis</i>: An arbitrary-precision integer whose value will be shifted.

 * <i>bitCount</i>: The number of bits to shift left. If this number is negative, shifts right instead.

<b>Returns:</b>

An arbitrary-precision integer.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>bthis</i>
 is null.

### Operator `<`

    public static bool operator <(
        PeterO.BigInteger thisValue,
        PeterO.BigInteger otherValue);

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Determines whether an arbitrary-precision integer is less than another arbitrary-precision integer.

<b>Parameters:</b>

 * <i>thisValue</i>: The first arbitrary-precision integer.

 * <i>otherValue</i>: The second arbitrary-precision integer.

<b>Returns:</b>

 `true`  if  <i>thisValue</i>
 is less than <i>otherValue</i>
 ; otherwise,  `false` .

### Operator `<=`

    public static bool operator <=(
        PeterO.BigInteger thisValue,
        PeterO.BigInteger otherValue);

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Determines whether an arbitrary-precision integer is less than or equal to another arbitrary-precision integer.

<b>Parameters:</b>

 * <i>thisValue</i>: The first arbitrary-precision integer.

 * <i>otherValue</i>: The second arbitrary-precision integer.

<b>Returns:</b>

 `true`  if  <i>thisValue</i>
 is up to  <i>otherValue</i>
 ; otherwise,  `false` .

### Operator `%`

    public static PeterO.BigInteger operator %(
        PeterO.BigInteger dividend,
        PeterO.BigInteger divisor);

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Finds the remainder that results when an arbitrary-precision integer is divided by the value of an arbitrary-precision integer.

<b>Parameters:</b>

 * <i>dividend</i>: The number that will be divided by the divisor.

 * <i>divisor</i>: The number to divide by.

<b>Returns:</b>

The remainder of the two numbers.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>dividend</i>
 is null.

### Operator `*`

    public static PeterO.BigInteger operator *(
        PeterO.BigInteger operand1,
        PeterO.BigInteger operand2);

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Multiplies an arbitrary-precision integer by the value of an arbitrary-precision integer.

<b>Parameters:</b>

 * <i>operand1</i>: The first operand.

 * <i>operand2</i>: The second operand.

<b>Returns:</b>

The product of the two numbers.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>operand1</i>
 is null.

### Operator `>>`

    public static PeterO.BigInteger operator >>(
        PeterO.BigInteger bthis,
        int smallValue);

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Shifts the bits of an arbitrary-precision integer to the right.

For this operation, the arbitrary-precision integer is treated as a two's complement representation. Thus, for negative values, the arbitrary-precision integer is sign-extended.

<b>Parameters:</b>

 * <i>bthis</i>: Another arbitrary-precision integer.

 * <i>smallValue</i>: A 32-bit signed integer.

<b>Returns:</b>

An arbitrary-precision integer.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>bthis</i>
 is null.

### Operator `-`

    public static PeterO.BigInteger operator -(
        PeterO.BigInteger bthis,
        PeterO.BigInteger subtrahend);

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Subtracts two arbitrary-precision integer values.

<b>Parameters:</b>

 * <i>bthis</i>: An arbitrary-precision integer.

 * <i>subtrahend</i>: Another arbitrary-precision integer.

<b>Returns:</b>

The difference of the two objects.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>bthis</i>
 is null.

### Operator `-`

    public static PeterO.BigInteger operator -(
        PeterO.BigInteger bigValue);

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Negates an arbitrary-precision integer.

<b>Parameters:</b>

 * <i>bigValue</i>: Another arbitrary-precision integer.

<b>Returns:</b>

An arbitrary-precision integer.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>bigValue</i>
 is null.

### Or

    public static PeterO.BigInteger Or(
        PeterO.BigInteger first,
        PeterO.BigInteger second);

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Does an OR operation between two arbitrary-precision integer instances.

Each arbitrary-precision integer is treated as a two's complement representation for the purposes of this operator.

<b>Parameters:</b>

 * <i>first</i>: Another arbitrary-precision integer.

 * <i>second</i>: An arbitrary-precision integer. (3).

<b>Returns:</b>

An arbitrary-precision integer.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>first</i>
 or  <i>second</i>
 is null.

### pow

    public PeterO.BigInteger pow(
        int powerSmall);

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Raises a big integer to a power.

<b>Parameters:</b>

 * <i>powerSmall</i>: The exponent to raise to.

<b>Returns:</b>

The result. Returns 1 if  <i>powerSmall</i>
 is 0.

<b>Exceptions:</b>

 * System.ArgumentException:
The parameter <i>powerSmall</i>
 is less than 0.

### Pow

    public static PeterO.BigInteger Pow(
        PeterO.BigInteger bigValue,
        int power);

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Returns this number raised to a power.

<b>Parameters:</b>

 * <i>bigValue</i>: The value to raise to an exponent.

 * <i>power</i>: The exponent.

<b>Returns:</b>

The result. Returns 1 if  <i>power</i>
 is 0.

### Pow

    public static PeterO.BigInteger Pow(
        PeterO.BigInteger bigValue,
        PeterO.BigInteger power);

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Returns this number raised to a power.

<b>Parameters:</b>

 * <i>bigValue</i>: The value to raise to an exponent.

 * <i>power</i>: The exponent.

<b>Returns:</b>

The result. Returns 1 if  <i>power</i>
 is 0.

### PowBigIntVar

    public PeterO.BigInteger PowBigIntVar(
        PeterO.BigInteger power);

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Raises a big integer to a power, which is given as another big integer.

<b>Parameters:</b>

 * <i>power</i>: The exponent to raise to.

<b>Returns:</b>

The result. Returns 1 if  <i>power</i>
 is 0.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>power</i>
 is null.

 * System.ArgumentException:
The parameter <i>power</i>
 is less than 0.

### remainder

    public PeterO.BigInteger remainder(
        PeterO.BigInteger divisor);

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Finds the remainder that results when this instance is divided by the value of an arbitrary-precision integer. The remainder is the value that remains when the absolute value of this object is divided by the absolute value of the other object; the remainder has the same sign (positive or negative) as this object.

<b>Parameters:</b>

 * <i>divisor</i>: Another arbitrary-precision integer.

<b>Returns:</b>

The remainder of the two numbers.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>divisor</i>
 is null.

 * System.DivideByZeroException:
Attempted to divide by zero.

### shiftLeft

    public PeterO.BigInteger shiftLeft(
        int numberBits);

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Returns a big integer with the bits shifted to the left by a number of bits. A value of 1 doubles this value, a value of 2 multiplies it by 4, a value of 3 by 8, a value of 4 by 16, and so on.

<b>Parameters:</b>

 * <i>numberBits</i>: The number of bits to shift. Can be negative, in which case this is the same as shiftRight with the absolute value of numberBits.

<b>Returns:</b>

An arbitrary-precision integer.

### shiftRight

    public PeterO.BigInteger shiftRight(
        int numberBits);

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Returns a big integer with the bits shifted to the right. For this operation, the arbitrary-precision integer is treated as a two's complement representation. Thus, for negative values, the arbitrary-precision integer is sign-extended.

<b>Parameters:</b>

 * <i>numberBits</i>: Number of bits to shift right.

<b>Returns:</b>

An arbitrary-precision integer.

### sqrt

    public PeterO.BigInteger sqrt();

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Finds the square root of this instance's value, rounded down.

<b>Returns:</b>

The square root of this object's value. Returns 0 if this value is 0 or less.

### sqrtWithRemainder

    public PeterO.BigInteger[] sqrtWithRemainder();

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Calculates the square root and the remainder.

<b>Returns:</b>

An array of two big integers: the first integer is the square root, and the second is the difference between this value and the square of the first integer. Returns two zeros if this value is 0 or less, or one and zero if this value equals 1.

### subtract

    public PeterO.BigInteger subtract(
        PeterO.BigInteger subtrahend);

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Subtracts an arbitrary-precision integer from this arbitrary-precision integer.

<b>Parameters:</b>

 * <i>subtrahend</i>: Another arbitrary-precision integer.

<b>Returns:</b>

The difference of the two objects.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>subtrahend</i>
 is null.

### testBit

    public bool testBit(
        int index);

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Returns whether a bit is set in the two's-complement representation of this object's value.

<b>Parameters:</b>

 * <i>index</i>: Zero based index of the bit to test. 0 means the least significant bit.

<b>Returns:</b>

 `true`  if a bit is set in the two's-complement representation of this object's value; otherwise,  `false` .

### toByteArray

    public byte[] toByteArray(
        bool littleEndian);

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Returns a byte array of this object's value.

<b>Parameters:</b>

 * <i>littleEndian</i>: A Boolean object.

<b>Returns:</b>

A byte array.

### ToByteArray

    public byte[] ToByteArray();

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Returns a byte array of this integer's value. The byte array will take the form of the number's two's-complement representation, using the fewest bytes necessary to store its value unambiguously. If this value is negative, the bits that appear beyond the most significant bit of the number will be all ones. The resulting byte array can be passed to the  `FromBytes()`  method (with the same byte order) to reconstruct this integer's value. The byte order used will be little-endian.

<b>Returns:</b>

A byte array. If this value is 0, returns a byte array with the single element 0.

### toBytes

    public byte[] toBytes(
        bool littleEndian);

Returns a byte array of this object's value. The byte array will take the form of the number's two' s-complement representation, using the fewest bytes necessary to represent its value unambiguously. If this value is negative, the bits that appear "before" the most significant bit of the number will be all ones.

<b>Parameters:</b>

 * <i>littleEndian</i>: If true, the least significant bits will appear first.

<b>Returns:</b>

A byte array. If this value is 0, returns a byte array with the single element 0.

### toRadixString

    public string toRadixString(
        int radix);

Generates a string representing the value of this object, in the given radix.

<b>Parameters:</b>

 * <i>radix</i>: A radix from 2 through 36. For example, to generate a hexadecimal (base-16) string, specify 16. To generate a decimal (base-10) string, specify 10.

<b>Returns:</b>

A string representing the value of this object. If this value is 0, returns "0". If negative, the string will begin with a hyphen/minus ("-"). Depending on the radix, the string will use the basic digits 0 to 9 (U+0030 to U+0039) and then the basic letters A to Z (U+0041 to U+005A). For example, 0-9 in radix 10, and 0-9, then A-F in radix 16.

<b>Exceptions:</b>

 * System.ArgumentException:
The parameter "index" is less than 0, "endIndex" is less than 0, or either is greater than the string's length, or "endIndex" is less than "index" ; or radix is less than 2 or greater than 36.

### ToString

    public override string ToString();

Converts this object to a text string in base 10.

<b>Returns:</b>

A string representation of this object. If negative, the string will begin with a minus sign ("-", U+002D). The string will use the basic digits 0 to 9 (U+0030 to U+0039).

### valueOf

    public static PeterO.BigInteger valueOf(
        long longerValue);

Converts a 64-bit signed integer to a big integer.

<b>Parameters:</b>

 * <i>longerValue</i>: A 64-bit signed integer.

<b>Returns:</b>

An arbitrary-precision integer with the same value as the 64-bit number.

### Xor

    public static PeterO.BigInteger Xor(
        PeterO.BigInteger a,
        PeterO.BigInteger b);

<b>Deprecated.</b> Use EInteger from PeterO.Numbers/com.upokecenter.numbers.

Finds the exclusive "or" of two arbitrary-precision integer objects.Each arbitrary-precision integer is treated as a two's complement representation for the purposes of this operator.

<b>Parameters:</b>

 * <i>a</i>: The first arbitrary-precision integer.

 * <i>b</i>: The second arbitrary-precision integer.

<b>Returns:</b>

An arbitrary-precision integer in which each bit is set if it's set in one input integer but not the other.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>a</i>
 or  <i>b</i>
 is null.
