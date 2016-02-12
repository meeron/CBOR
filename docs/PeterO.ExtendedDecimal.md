## PeterO.ExtendedDecimal

    public sealed class ExtendedDecimal :
        System.IComparable,
        System.IEquatable

This class is largely obsolete. It will be replaced by a new version of this class in a different namespace/package and library, called  `PeterO.Numbers.EDecimal`  in the `PeterO.Numbers` library (in .NET), or  `com.upokecenter.numbers.EDecimal`  in the `com.github.peteroupc/numbers` artifact (in Java). This new class can be used in the `CBORObject.FromObject(object)`  method (by including the new library in your code, among other things), but this version of the CBOR library doesn't include any methods that explicitly take an `EDecimal`  as a parameter or return value.

Represents an arbitrary-precision decimal floating-point number.About decimal arithmetic

Decimal (base-10) arithmetic, such as that provided by this class, is appropriate for calculations involving such real-world data as prices and other sums of money, tax rates, and measurements. These calculations often involve multiplying or dividing one decimal with another decimal, or performing other operations on decimal numbers. Many of these calculations also rely on rounding behavior in which the result after rounding is a decimal number (for example, multiplying a price by a premium rate, then rounding, should result in a decimal amount of money).

On the other hand, most implementations of  `float`  and `double` , including in C# and Java, store numbers in a binary (base-2) floating-point format and use binary floating-point arithmetic. Many decimal numbers can't be represented exactly in binary floating-point format (regardless of its length). Applying binary arithmetic to numbers intended to be decimals can sometimes lead to unintuitive results, as is shown in the description for the FromDouble() method of this class.

About ExtendedDecimal instances

Each instance of this class consists of an integer mantissa and an integer exponent, both arbitrary-precision. The value of the number equals mantissa * 10^exponent.

The mantissa is the value of the digits that make up a number, ignoring the decimal point and exponent. For example, in the number 2356.78, the mantissa is 235678. The exponent is where the "floating" decimal point of the number is located. A positive exponent means "move it to the right", and a negative exponent means "move it to the left." In the example 2, 356.78, the exponent is -2, since it has 2 decimal places and the decimal point is "moved to the left by 2." Therefore, in the arbitrary-precision decimal representation, this number would be stored as 235678 * 10^-2.

The mantissa and exponent format preserves trailing zeros in the number's value. This may give rise to multiple ways to store the same value. For example, 1.00 and 1 would be stored differently, even though they have the same value. In the first case, 100 * 10^-2 (100 with decimal point moved left by 2), and in the second case, 1 * 10^0 (1 with decimal point moved 0).

This class also supports values for negative zero, not-a-number (NaN) values, and infinity. Negative zero is generally used when a negative number is rounded to 0; it has the same mathematical value as positive zero. Infinity is generally used when a non-zero number is divided by zero, or when a very high number can't be represented in a given exponent range.Not-a-number is generally used to signal errors.

This class implements the General Decimal Arithmetic Specification version 1.70 (except part of chapter 6): `http://speleotrove.com/decimal/decarith.html`

Errors and Exceptions

Passing a signaling NaN to any arithmetic operation shown here will signal the flag FlagInvalid and return a quiet NaN, even if another operand to that operation is a quiet NaN, unless noted otherwise.

Passing a quiet NaN to any arithmetic operation shown here will return a quiet NaN, unless noted otherwise. Invalid operations will also return a quiet NaN, as stated in the individual methods.

Unless noted otherwise, passing a null arbitrary-precision decimal argument to any method here will throw an exception.

When an arithmetic operation signals the flag FlagInvalid, FlagOverflow, or FlagDivideByZero, it will not throw an exception too, unless the flag's trap is enabled in the precision context (see EContext's Traps property).

If an operation requires creating an intermediate value that might be too big to fit in memory (or might require more than 2 gigabytes of memory to store -- due to the current use of a 32-bit integer internally as a length), the operation may signal an invalid-operation flag and return not-a-number (NaN). In certain rare cases, the CompareTo method may throw OutOfMemoryException (called OutOfMemoryError in Java) in the same circumstances.

Serialization

An arbitrary-precision decimal value can be serialized (converted to a stable format) in one of the following ways:

 * By calling the toString() method, which will always return distinct strings for distinct arbitrary-precision decimal values.

 * By calling the UnsignedMantissa, Exponent, and IsNegative properties, and calling the IsInfinity, IsQuietNaN, and IsSignalingNaN methods. The return values combined will uniquely identify a particular arbitrary-precision decimal value.

Thread safety

Instances of this class are immutable, so they are inherently safe for use by multiple threads. Multiple instances of this object with the same properties are interchangeable, so they should not be compared using the "==" operator (which only checks if each side of the operator is the same instance).

Comparison considerations

This class's natural ordering (under the CompareTo method) is not consistent with the Equals method. This means that two values that compare as equal under the CompareTo method might not be equal under the Equals method. The CompareTo method compares the mathematical values of the two instances passed to it (and considers two different NaN values as equal), while two instances with the same mathematical value, but different exponents, will be considered unequal under the Equals method.

### NaN

    public static readonly PeterO.ExtendedDecimal NaN;

A not-a-number value.

### NegativeInfinity

    public static readonly PeterO.ExtendedDecimal NegativeInfinity;

Negative infinity, less than any other number.

### NegativeZero

    public static readonly PeterO.ExtendedDecimal NegativeZero;

Represents the number negative zero.

### One

    public static readonly PeterO.ExtendedDecimal One;

Represents the number 1.

### PositiveInfinity

    public static readonly PeterO.ExtendedDecimal PositiveInfinity;

Positive infinity, greater than any other number.

### SignalingNaN

    public static readonly PeterO.ExtendedDecimal SignalingNaN;

A not-a-number value that signals an invalid operation flag when it's passed as an argument to any arithmetic operation in arbitrary-precision decimal.

### Ten

    public static readonly PeterO.ExtendedDecimal Ten;

Represents the number 10.

### Zero

    public static readonly PeterO.ExtendedDecimal Zero;

Represents the number 0.

### Exponent

    public PeterO.BigInteger Exponent { get; }

Gets this object's exponent. This object's value will be an integer if the exponent is positive or zero.

<b>Returns:</b>

This object's exponent. This object's value will be an integer if the exponent is positive or zero.

### IsFinite

    public bool IsFinite { get; }

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Gets a value indicating whether this object is finite (not infinity or NaN).

<b>Returns:</b>

<c>true</c> if this object is finite (not infinity or NaN); otherwise, <c>false</c>.  `true` if this object is finite (not infinity or NaN); otherwise, `false` .

### IsNegative

    public bool IsNegative { get; }

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Gets a value indicating whether this object is negative, including negative zero.

<b>Returns:</b>

<c>true</c> if this object is negative, including negative zero; otherwise, <c>false</c>. `true`  if this object is negative, including negative zero; otherwise,  `false` .

### IsZero

    public bool IsZero { get; }

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Gets a value indicating whether this object's value equals 0.

<b>Returns:</b>

<c>true</c> if this object&#x27;s value equals 0; otherwise, <c>false</c>.  `true`  if this object's value equals 0; otherwise,  `false` .

### Mantissa

    public PeterO.BigInteger Mantissa { get; }

Gets this object's un-scaled value.

<b>Returns:</b>

This object's un-scaled value. Will be negative if this object's value is negative (including a negative NaN).

### Sign

    public int Sign { get; }

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Gets this value's sign: -1 if negative; 1 if positive; 0 if zero.

<b>Returns:</b>

This value's sign: -1 if negative; 1 if positive; 0 if zero.

### UnsignedMantissa

    public PeterO.BigInteger UnsignedMantissa { get; }

Gets the absolute value of this object's un-scaled value.

<b>Returns:</b>

The absolute value of this object's un-scaled value.

### Abs

    public PeterO.ExtendedDecimal Abs(
        PeterO.PrecisionContext context);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Finds the absolute value of this object (if it's negative, it becomes positive).

<b>Parameters:</b>

 * <i>context</i>: A precision context to control precision, rounding, and exponent range of the result. If HasFlags of the context is true, will also store the flags resulting from the operation (the flags are in addition to the pre-existing flags). Can be null.

<b>Returns:</b>

The absolute value of this object.

### Abs

    public PeterO.ExtendedDecimal Abs();

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Gets the absolute value of this object.

<b>Returns:</b>

An arbitrary-precision decimal number.

### Add

    public PeterO.ExtendedDecimal Add(
        PeterO.ExtendedDecimal otherValue);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Adds this object and another decimal number and returns the result.

<b>Parameters:</b>

 * <i>otherValue</i>: An arbitrary-precision decimal number.

<b>Returns:</b>

The sum of the two objects.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>otherValue</i>
 is null.

### Add

    public PeterO.ExtendedDecimal Add(
        PeterO.ExtendedDecimal otherValue,
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Finds the sum of this object and another object. The result's exponent is set to the lower of the exponents of the two operands.

<b>Parameters:</b>

 * <i>otherValue</i>: The number to add to.

 * <i>ctx</i>: A precision context to control precision, rounding, and exponent range of the result. If HasFlags of the context is true, will also store the flags resulting from the operation (the flags are in addition to the pre-existing flags). Can be null.

<b>Returns:</b>

The sum of thisValue and the other object.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>otherValue</i>
 is null.

### CompareTo

    public sealed int CompareTo(
        PeterO.ExtendedDecimal other);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Compares the mathematical values of this object and another object, accepting NaN values.This method is not consistent with the Equals method because two different numbers with the same mathematical value, but different exponents, will compare as equal.

In this method, negative zero and positive zero are considered equal.

If this object or the other object is a quiet NaN or signaling NaN, this method will not trigger an error. Instead, NaN will compare greater than any other number, including infinity. Two different NaN values will be considered equal.

<b>Parameters:</b>

 * <i>other</i>: An arbitrary-precision decimal number.

<b>Returns:</b>

Less than 0 if this object's value is less than the other value, or greater than 0 if this object's value is greater than the other value or if  <i>other</i>
 is null, or 0 if both values are equal.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>other</i>
 is null.

### CompareToBinary

    public int CompareToBinary(
        PeterO.ExtendedFloat other);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Compares an arbitrary-precision binary float with this instance.

<b>Parameters:</b>

 * <i>other</i>: The other object to compare. Can be null.

<b>Returns:</b>

Zero if the values are equal; a negative number if this instance is less, or a positive number if this instance is greater. Returns 0 if both values are NaN (even signaling NaN) and 1 if this value is NaN (even signaling NaN) and the other isn't, or if the other value is null.

### CompareToSignal

    public PeterO.ExtendedDecimal CompareToSignal(
        PeterO.ExtendedDecimal other,
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Compares the mathematical values of this object and another object, treating quiet NaN as signaling.In this method, negative zero and positive zero are considered equal.

If this object or the other object is a quiet NaN or signaling NaN, this method will return a quiet NaN and will signal a FlagInvalid flag.

<b>Parameters:</b>

 * <i>other</i>: An arbitrary-precision decimal number.

 * <i>ctx</i>: A precision context. The precision, rounding, and exponent range are ignored. If HasFlags of the context is true, will store the flags resulting from the operation (the flags are in addition to the pre-existing flags). Can be null.

<b>Returns:</b>

Quiet NaN if this object or the other object is NaN, or 0 if both objects have the same value, or -1 if this object is less than the other value, or 1 if this object is greater.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>other</i>
 is null.

### CompareToWithContext

    public PeterO.ExtendedDecimal CompareToWithContext(
        PeterO.ExtendedDecimal other,
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Compares the mathematical values of this object and another object.In this method, negative zero and positive zero are considered equal.

If this object or the other object is a quiet NaN or signaling NaN, this method returns a quiet NaN, and will signal a FlagInvalid flag if either is a signaling NaN.

<b>Parameters:</b>

 * <i>other</i>: An arbitrary-precision decimal number.

 * <i>ctx</i>: A precision context. The precision, rounding, and exponent range are ignored. If HasFlags of the context is true, will store the flags resulting from the operation (the flags are in addition to the pre-existing flags). Can be null.

<b>Returns:</b>

Quiet NaN if this object or the other object is NaN, or 0 if both objects have the same value, or -1 if this object is less than the other value, or 1 if this object is greater.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>other</i>
 is null.

### Create

    public static PeterO.ExtendedDecimal Create(
        int mantissaSmall,
        int exponentSmall);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Creates a number with the value exponent*10^mantissa.

<b>Parameters:</b>

 * <i>mantissaSmall</i>: The un-scaled value.

 * <i>exponentSmall</i>: The decimal exponent.

<b>Returns:</b>

An arbitrary-precision decimal number.

### Create

    public static PeterO.ExtendedDecimal Create(
        PeterO.BigInteger mantissa,
        PeterO.BigInteger exponent);

Creates a number with the value exponent*10^mantissa.

<b>Parameters:</b>

 * <i>mantissa</i>: The un-scaled value.

 * <i>exponent</i>: The decimal exponent.

<b>Returns:</b>

An arbitrary-precision decimal number.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>mantissa</i>
 or  <i>exponent</i>
 is null.

### CreateNaN

    public static PeterO.ExtendedDecimal CreateNaN(
        PeterO.BigInteger diag);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Creates a not-a-number arbitrary-precision decimal number.

<b>Parameters:</b>

 * <i>diag</i>: A number to use as diagnostic information associated with this object. If none is needed, should be zero.

<b>Returns:</b>

A quiet not-a-number.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>diag</i>
 is null or is less than 0.

### CreateNaN

    public static PeterO.ExtendedDecimal CreateNaN(
        PeterO.BigInteger diag,
        bool signaling,
        bool negative,
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Creates a not-a-number arbitrary-precision decimal number.

<b>Parameters:</b>

 * <i>diag</i>: A number to use as diagnostic information associated with this object. If none is needed, should be zero.

 * <i>signaling</i>: Whether the return value will be signaling (true) or quiet (false).

 * <i>negative</i>: Whether the return value is negative.

 * <i>ctx</i>: A context object for arbitrary-precision arithmetic settings.

<b>Returns:</b>

An arbitrary-precision decimal number.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>diag</i>
 is null or is less than 0.

### Divide

    public PeterO.ExtendedDecimal Divide(
        PeterO.ExtendedDecimal divisor);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Divides this object by another decimal number and returns the result. When possible, the result will be exact.

<b>Parameters:</b>

 * <i>divisor</i>: The number to divide by.

<b>Returns:</b>

The quotient of the two numbers. Signals FlagDivideByZero and returns infinity if the divisor is 0 and the dividend is nonzero. Returns not-a-number (NaN) if the divisor and the dividend are 0. Returns NaN if the result can't be exact because it would have a nonterminating decimal expansion.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>divisor</i>
 is null.

### Divide

    public PeterO.ExtendedDecimal Divide(
        PeterO.ExtendedDecimal divisor,
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Divides this arbitrary-precision decimal number by another arbitrary-precision decimal number. The preferred exponent for the result is this object's exponent minus the divisor's exponent.

<b>Parameters:</b>

 * <i>divisor</i>: The number to divide by.

 * <i>ctx</i>: A precision context to control precision, rounding, and exponent range of the result. If HasFlags of the context is true, will also store the flags resulting from the operation (the flags are in addition to the pre-existing flags). Can be null.

<b>Returns:</b>

The quotient of the two objects. Signals FlagDivideByZero and returns infinity if the divisor is 0 and the dividend is nonzero. Signals FlagInvalid and returns not-a-number (NaN) if the divisor and the dividend are 0; or, either  <i>ctx</i>
is null or  <i>ctx</i>
 's precision is 0, and the result would have a nonterminating decimal expansion; or, the rounding mode is Rounding.Unnecessary and the result is not exact.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>divisor</i>
 is null.

### DivideAndRemainderNaturalScale

    public PeterO.ExtendedDecimal[] DivideAndRemainderNaturalScale(
        PeterO.ExtendedDecimal divisor);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Calculates the quotient and remainder using the DivideToIntegerNaturalScale and the formula in RemainderNaturalScale.

<b>Parameters:</b>

 * <i>divisor</i>: The number to divide by.

<b>Returns:</b>

A 2 element array consisting of the quotient and remainder in that order.

### DivideAndRemainderNaturalScale

    public PeterO.ExtendedDecimal[] DivideAndRemainderNaturalScale(
        PeterO.ExtendedDecimal divisor,
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Calculates the quotient and remainder using the DivideToIntegerNaturalScale and the formula in RemainderNaturalScale.

<b>Parameters:</b>

 * <i>divisor</i>: The number to divide by.

 * <i>ctx</i>: A precision context object to control the precision, rounding, and exponent range of the result. This context will be used only in the division portion of the remainder calculation; as a result, it's possible for the remainder to have a higher precision than given in this context. Flags will be set on the given context only if the context's HasFlags is true and the integer part of the division result doesn't fit the precision and exponent range without rounding.

<b>Returns:</b>

A 2 element array consisting of the quotient and remainder in that order.

### DivideToExponent

    public PeterO.ExtendedDecimal DivideToExponent(
        PeterO.ExtendedDecimal divisor,
        long desiredExponentSmall,
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Divides two arbitrary-precision decimal numbers, and gives a particular exponent to the result.

<b>Parameters:</b>

 * <i>divisor</i>: An arbitrary-precision decimal number.

 * <i>desiredExponentSmall</i>: The desired exponent. A negative number places the cutoff point to the right of the usual decimal point. A positive number places the cutoff point to the left of the usual decimal point.

 * <i>ctx</i>: A precision context object to control the rounding mode to use if the result must be scaled down to have the same exponent as this value. If the precision given in the context is other than 0, calls the Quantize method with both arguments equal to the result of the operation (and can signal FlagInvalid and return NaN if the result doesn't fit the given precision). If HasFlags of the context is true, will also store the flags resulting from the operation (the flags are in addition to the pre-existing flags). Can be null, in which case the default rounding mode is HalfEven.

<b>Returns:</b>

The quotient of the two objects. Signals FlagDivideByZero and returns infinity if the divisor is 0 and the dividend is nonzero. Signals FlagInvalid and returns not-a-number (NaN) if the divisor and the dividend are 0. Signals FlagInvalid and returns not-a-number (NaN) if the context defines an exponent range and the desired exponent is outside that range. Signals FlagInvalid and returns not-a-number (NaN) if the rounding mode is Rounding.Unnecessary and the result is not exact.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>divisor</i>
 is null.

### DivideToExponent

    public PeterO.ExtendedDecimal DivideToExponent(
        PeterO.ExtendedDecimal divisor,
        long desiredExponentSmall,
        PeterO.Rounding rounding);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Divides two arbitrary-precision decimal numbers, and gives a particular exponent to the result.

<b>Parameters:</b>

 * <i>divisor</i>: An arbitrary-precision decimal number.

 * <i>desiredExponentSmall</i>: The desired exponent. A negative number places the cutoff point to the right of the usual decimal point. A positive number places the cutoff point to the left of the usual decimal point.

 * <i>rounding</i>: The rounding mode to use if the result must be scaled down to have the same exponent as this value.

<b>Returns:</b>

The quotient of the two objects. Signals FlagDivideByZero and returns infinity if the divisor is 0 and the dividend is nonzero. Signals FlagInvalid and returns not-a-number (NaN) if the divisor and the dividend are 0. Signals FlagInvalid and returns not-a-number (NaN) if the rounding mode is Rounding.Unnecessary and the result is not exact.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>divisor</i>
 is null.

### DivideToExponent

    public PeterO.ExtendedDecimal DivideToExponent(
        PeterO.ExtendedDecimal divisor,
        PeterO.BigInteger desiredExponent,
        PeterO.Rounding rounding);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Divides two arbitrary-precision decimal numbers, and gives a particular exponent to the result.

<b>Parameters:</b>

 * <i>divisor</i>: An arbitrary-precision decimal number.

 * <i>desiredExponent</i>: The desired exponent. A negative number places the cutoff point to the right of the usual decimal point. A positive number places the cutoff point to the left of the usual decimal point.

 * <i>rounding</i>: The rounding mode to use if the result must be scaled down to have the same exponent as this value.

<b>Returns:</b>

The quotient of the two objects. Signals FlagDivideByZero and returns infinity if the divisor is 0 and the dividend is nonzero. Returns not-a-number (NaN) if the divisor and the dividend are 0. Returns NaN if the rounding mode is Rounding.Unnecessary and the result is not exact.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>divisor</i>
 or  <i>desiredExponent</i>
 is null.

### DivideToExponent

    public PeterO.ExtendedDecimal DivideToExponent(
        PeterO.ExtendedDecimal divisor,
        PeterO.BigInteger exponent,
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Divides two arbitrary-precision decimal numbers, and gives a particular exponent to the result.

<b>Parameters:</b>

 * <i>divisor</i>: An arbitrary-precision decimal number.

 * <i>exponent</i>: The desired exponent. A negative number places the cutoff point to the right of the usual decimal point. A positive number places the cutoff point to the left of the usual decimal point.

 * <i>ctx</i>: A precision context object to control the rounding mode to use if the result must be scaled down to have the same exponent as this value. If the precision given in the context is other than 0, calls the Quantize method with both arguments equal to the result of the operation (and can signal FlagInvalid and return NaN if the result doesn't fit the given precision). If HasFlags of the context is true, will also store the flags resulting from the operation (the flags are in addition to the pre-existing flags). Can be null, in which case the default rounding mode is HalfEven.

<b>Returns:</b>

The quotient of the two objects. Signals FlagDivideByZero and returns infinity if the divisor is 0 and the dividend is nonzero. Signals FlagInvalid and returns not-a-number (NaN) if the divisor and the dividend are 0. Signals FlagInvalid and returns not-a-number (NaN) if the context defines an exponent range and the desired exponent is outside that range. Signals FlagInvalid and returns not-a-number (NaN) if the rounding mode is Rounding.Unnecessary and the result is not exact.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>divisor</i>
 or  <i>exponent</i>
 is null.

### DivideToIntegerNaturalScale

    public PeterO.ExtendedDecimal DivideToIntegerNaturalScale(
        PeterO.ExtendedDecimal divisor);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Divides two arbitrary-precision decimal numbers, and returns the integer part of the result, rounded down, with the preferred exponent set to this value's exponent minus the divisor's exponent.

<b>Parameters:</b>

 * <i>divisor</i>: The number to divide by.

<b>Returns:</b>

The integer part of the quotient of the two objects. Signals FlagDivideByZero and returns infinity if the divisor is 0 and the dividend is nonzero. Signals FlagInvalid and returns not-a-number (NaN) if the divisor and the dividend are 0.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>divisor</i>
 is null.

### DivideToIntegerNaturalScale

    public PeterO.ExtendedDecimal DivideToIntegerNaturalScale(
        PeterO.ExtendedDecimal divisor,
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Divides this object by another object, and returns the integer part of the result, with the preferred exponent set to this value's exponent minus the divisor's exponent.

<b>Parameters:</b>

 * <i>divisor</i>: The number to divide by.

 * <i>ctx</i>: A precision context object to control the precision, rounding, and exponent range of the integer part of the result. Flags will be set on the given context only if the context's HasFlags is true and the integer part of the result doesn't fit the precision and exponent range without rounding.

<b>Returns:</b>

The integer part of the quotient of the two objects. Signals FlagInvalid and returns not-a-number (NaN) if the return value would overflow the exponent range. Signals FlagDivideByZero and returns infinity if the divisor is 0 and the dividend is nonzero. Signals FlagInvalid and returns not-a-number (NaN) if the divisor and the dividend are 0. Signals FlagInvalid and returns not-a-number (NaN) if the rounding mode is Rounding.Unnecessary and the result is not exact.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>divisor</i>
 is null.

### DivideToIntegerZeroScale

    public PeterO.ExtendedDecimal DivideToIntegerZeroScale(
        PeterO.ExtendedDecimal divisor,
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Divides this object by another object, and returns the integer part of the result, with the exponent set to 0.

<b>Parameters:</b>

 * <i>divisor</i>: The number to divide by.

 * <i>ctx</i>: A precision context object to control the precision. The rounding and exponent range settings of this context are ignored. If HasFlags of the context is true, will also store the flags resulting from the operation (the flags are in addition to the pre-existing flags). Can be null.

<b>Returns:</b>

The integer part of the quotient of the two objects. The exponent will be set to 0. Signals FlagDivideByZero and returns infinity if the divisor is 0 and the dividend is nonzero. Signals FlagInvalid and returns not-a-number (NaN) if the divisor and the dividend are 0, or if the result doesn't fit the given precision.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>divisor</i>
 is null.

### DivideToSameExponent

    public PeterO.ExtendedDecimal DivideToSameExponent(
        PeterO.ExtendedDecimal divisor,
        PeterO.Rounding rounding);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Divides this object by another decimal number and returns a result with the same exponent as this object (the dividend).

<b>Parameters:</b>

 * <i>divisor</i>: The number to divide by.

 * <i>rounding</i>: The rounding mode to use if the result must be scaled down to have the same exponent as this value.

<b>Returns:</b>

The quotient of the two numbers. Signals FlagDivideByZero and returns infinity if the divisor is 0 and the dividend is nonzero. Signals FlagInvalid and returns not-a-number (NaN) if the divisor and the dividend are 0. Signals FlagInvalid and returns not-a-number (NaN) if the rounding mode is Rounding.Unnecessary and the result is not exact.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>divisor</i>
 is null.

### Equals

    public override bool Equals(
        object obj);

Determines whether this object's mantissa and exponent are equal to those of another object and that other object is an arbitrary-precision decimal number.

<b>Parameters:</b>

 * <i>obj</i>: An arbitrary object.

<b>Returns:</b>

 `true`  if the objects are equal; otherwise, false .

### Equals

    public sealed bool Equals(
        PeterO.ExtendedDecimal other);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Determines whether this object's mantissa and exponent are equal to those of another object.

<b>Parameters:</b>

 * <i>other</i>: An arbitrary-precision decimal number.

<b>Returns:</b>

 `true`  if this object's mantissa and exponent are equal to those of another object; otherwise,  `false` .

### Exp

    public PeterO.ExtendedDecimal Exp(
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Finds e (the base of natural logarithms) raised to the power of this object's value.

<b>Parameters:</b>

 * <i>ctx</i>: A precision context to control precision, rounding, and exponent range of the result. If HasFlags of the context is true, will also store the flags resulting from the operation (the flags are in addition to the pre-existing flags).This parameter cannot be null, as the exponential function's results are generally not exact..

<b>Returns:</b>

Exponential of this object. If this object's value is 1, returns an approximation to " e" within the given precision. Signals FlagInvalid and returns not-a-number (NaN) if the parameter <i>ctx</i>
 is null or the precision is unlimited (the context's Precision property is 0).

### FromBigInteger

    public static PeterO.ExtendedDecimal FromBigInteger(
        PeterO.BigInteger bigint);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Converts a big integer to an arbitrary precision decimal.

<b>Parameters:</b>

 * <i>bigint</i>: An arbitrary-precision integer.

<b>Returns:</b>

An arbitrary-precision decimal number with the exponent set to 0.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>bigint</i>
 is null.

### FromDouble

    public static PeterO.ExtendedDecimal FromDouble(
        double dbl);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Creates a decimal number from a 64-bit binary floating-point number. This method computes the exact value of the floating point number, not an approximation, as is often the case by converting the floating point number to a string first. Remember, though, that the exact value of a 64-bit binary floating-point number is not always the value that results when passing a literal decimal number (for example, calling `ExtendedDecimal.FromDouble(0.1f)`  ), since not all decimal numbers can be converted to exact binary numbers (in the example given, the resulting arbitrary-precision decimal will be the value of the closest "double" to 0.1, not 0.1 exactly). To create an arbitrary-precision decimal number from a decimal number, use FromString instead in most cases (for example: `ExtendedDecimal.FromString("0.1")`  ).

<b>Parameters:</b>

 * <i>dbl</i>: A 64-bit floating-point number.

<b>Returns:</b>

A decimal number with the same value as  <i>dbl</i>
.

### FromExtendedFloat

    public static PeterO.ExtendedDecimal FromExtendedFloat(
        PeterO.ExtendedFloat bigfloat);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Creates a decimal number from an arbitrary-precision binary floating-point number.

<b>Parameters:</b>

 * <i>bigfloat</i>: An arbitrary-precision binary floating-point number.

<b>Returns:</b>

An arbitrary-precision decimal number.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>bigfloat</i>
 is null.

### FromInt32

    public static PeterO.ExtendedDecimal FromInt32(
        int valueSmaller);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Creates a decimal number from a 32-bit signed integer.

<b>Parameters:</b>

 * <i>valueSmaller</i>: A 32-bit signed integer.

<b>Returns:</b>

An arbitrary-precision decimal number with the exponent set to 0.

### FromInt64

    public static PeterO.ExtendedDecimal FromInt64(
        long valueSmall);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Creates a decimal number from a 64-bit signed integer.

<b>Parameters:</b>

 * <i>valueSmall</i>: A 64-bit signed integer.

<b>Returns:</b>

An arbitrary-precision decimal number with the exponent set to 0.

### FromSingle

    public static PeterO.ExtendedDecimal FromSingle(
        float flt);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Creates a decimal number from a 32-bit binary floating-point number. This method computes the exact value of the floating point number, not an approximation, as is often the case by converting the floating point number to a string first. Remember, though, that the exact value of a 32-bit binary floating-point number is not always the value that results when passing a literal decimal number (for example, calling `ExtendedDecimal.FromSingle(0.1f)`  ), since not all decimal numbers can be converted to exact binary numbers (in the example given, the resulting arbitrary-precision decimal will be the the value of the closest "float" to 0.1, not 0.1 exactly). To create an arbitrary-precision decimal number from a decimal number, use FromString instead in most cases (for example: `ExtendedDecimal.FromString("0.1")`  ).

<b>Parameters:</b>

 * <i>flt</i>: A 32-bit floating-point number.

<b>Returns:</b>

A decimal number with the same value as  <i>flt</i>
.

### FromString

    public static PeterO.ExtendedDecimal FromString(
        string str);

Creates a decimal number from a text string that represents a number. See  `FromString(String, int, int,
            EContext)`  for more information.

<b>Parameters:</b>

 * <i>str</i>: A string that represents a number.

<b>Returns:</b>

An arbitrary-precision decimal number with the same value as the given string.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>str</i>
 is null.

 * System.FormatException:
The parameter  <i>str</i>
 is not a correctly formatted number string.

### FromString

    public static PeterO.ExtendedDecimal FromString(
        string str,
        int offset,
        int length);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Creates a decimal number from a text string that represents a number. See  `FromString(String, int, int,
            EContext)`  for more information.

<b>Parameters:</b>

 * <i>str</i>: A string that represents a number.

 * <i>offset</i>: A zero-based index showing where the desired portion of  <i>str</i>
 begins.

 * <i>length</i>: The length, in code units, of the desired portion of  <i>str</i>
 (but not more than  <i>str</i>
 's length).

<b>Returns:</b>

An arbitrary-precision decimal number with the same value as the given string.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>str</i>
 is null.

 * System.FormatException:
The parameter  <i>str</i>
 is not a correctly formatted number string.

### FromString

    public static PeterO.ExtendedDecimal FromString(
        string str,
        int offset,
        int length,
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Creates a decimal number from a text string that represents a number.

The format of the string generally consists of:

 * An optional plus sign ("+" , U+002B) or minus sign ("-", U+002D) (if '-' , the value is negative.)

 * One or more digits, with a single optional decimal point after the first digit and before the last digit.

 * Optionally, "E+"/"e+" (positive exponent) or "E-"/"e-" (negative exponent) plus one or more digits specifying the exponent.

The string can also be "-INF", "-Infinity", "Infinity", "INF", quiet NaN ("NaN" /"-NaN") followed by any number of digits, or signaling NaN ("sNaN" /"-sNaN") followed by any number of digits, all in any combination of upper and lower case.

All characters mentioned above are the corresponding characters in the Basic Latin range. In particular, the digits must be the basic digits 0 to 9 (U+0030 to U+0039). The string portion is not allowed to contain white space characters, including spaces.

<b>Parameters:</b>

 * <i>str</i>: A text string, a portion of which represents a number.

 * <i>offset</i>: A zero-based index that identifies the start of the number.

 * <i>length</i>: The length of the number within the string.

 * <i>ctx</i>: A precision context to control precision, rounding, and exponent range of the result. If HasFlags of the context is true, will also store the flags resulting from the operation (the flags are in addition to the pre-existing flags). Can be null.

<b>Returns:</b>

An arbitrary-precision decimal number with the same value as the given string.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>str</i>
 is null.

 * System.FormatException:
The parameter  <i>str</i>
 is not a correctly formatted number string.

### FromString

    public static PeterO.ExtendedDecimal FromString(
        string str,
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Creates a decimal number from a text string that represents a number. See  `FromString(String, int, int,
            EContext)`  for more information.

<b>Parameters:</b>

 * <i>str</i>: A string that represents a number.

 * <i>ctx</i>: A precision context to control precision, rounding, and exponent range of the result. If HasFlags of the context is true, will also store the flags resulting from the operation (the flags are in addition to the pre-existing flags). Can be null.

<b>Returns:</b>

An arbitrary-precision decimal number with the same value as the given string.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>str</i>
 is null.

 * System.FormatException:
The parameter  <i>str</i>
 is not a correctly formatted number string.

### GetHashCode

    public override int GetHashCode();

Calculates this object's hash code.

<b>Returns:</b>

This object's hash code.

### IsInfinity

    public bool IsInfinity();

Gets a value indicating whether this object is positive or negative infinity.

<b>Returns:</b>

 `true`  if this object is positive or negative infinity; otherwise,  `false` .

### IsNaN

    public bool IsNaN();

Gets a value indicating whether this object is not a number (NaN).

<b>Returns:</b>

 `true`  if this object is not a number (NaN); otherwise, false .

### IsNegativeInfinity

    public bool IsNegativeInfinity();

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Returns whether this object is negative infinity.

<b>Returns:</b>

 `true`  if this object is negative infinity; otherwise, false .

### IsPositiveInfinity

    public bool IsPositiveInfinity();

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Returns whether this object is positive infinity.

<b>Returns:</b>

 `true`  if this object is positive infinity; otherwise, false .

### IsQuietNaN

    public bool IsQuietNaN();

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Gets a value indicating whether this object is a quiet not-a-number value.

<b>Returns:</b>

 `true`  if this object is a quiet not-a-number value; otherwise,  `false` .

### IsSignalingNaN

    public bool IsSignalingNaN();

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Gets a value indicating whether this object is a signaling not-a-number value.

<b>Returns:</b>

 `true`  if this object is a signaling not-a-number value; otherwise,  `false` .

### Log

    public PeterO.ExtendedDecimal Log(
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Finds the natural logarithm of this object, that is, the power (exponent) that e (the base of natural logarithms) must be raised to in order to equal this object's value.

<b>Parameters:</b>

 * <i>ctx</i>: A precision context to control precision, rounding, and exponent range of the result. If HasFlags of the context is true, will also store the flags resulting from the operation (the flags are in addition to the pre-existing flags).This parameter cannot be null, as the ln function's results are generally not exact..

<b>Returns:</b>

Ln(this object). Signals the flag FlagInvalid and returns NaN if this object is less than 0 (the result would be a complex number with a real part equal to Ln of this object's absolute value and an imaginary part equal to pi, but the return value is still NaN.). Signals FlagInvalid and returns not-a-number (NaN) if the parameter  <i>ctx</i>
 is null or the precision is unlimited (the context's Precision property is 0). Signals no flags and returns negative infinity if this object's value is 0.

### Log10

    public PeterO.ExtendedDecimal Log10(
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Finds the base-10 logarithm of this object, that is, the power (exponent) that the number 10 must be raised to in order to equal this object's value.

<b>Parameters:</b>

 * <i>ctx</i>: A precision context to control precision, rounding, and exponent range of the result. If HasFlags of the context is true, will also store the flags resulting from the operation (the flags are in addition to the pre-existing flags).This parameter cannot be null, as the ln function's results are generally not exact..

<b>Returns:</b>

Ln(this object)/Ln(10). Signals the flag FlagInvalid and returns not-a-number (NaN) if this object is less than 0. Signals FlagInvalid and returns not-a-number (NaN) if the parameter <i>ctx</i>
 is null or the precision is unlimited (the context's Precision property is 0).

### Max

    public static PeterO.ExtendedDecimal Max(
        PeterO.ExtendedDecimal first,
        PeterO.ExtendedDecimal second);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Gets the greater value between two decimal numbers.

<b>Parameters:</b>

 * <i>first</i>: An arbitrary-precision decimal number.

 * <i>second</i>: Another arbitrary-precision decimal number.

<b>Returns:</b>

The larger value of the two numbers.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>first</i>
 or  <i>second</i>
 is null.

### Max

    public static PeterO.ExtendedDecimal Max(
        PeterO.ExtendedDecimal first,
        PeterO.ExtendedDecimal second,
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Gets the greater value between two decimal numbers.

<b>Parameters:</b>

 * <i>first</i>: The first value to compare.

 * <i>second</i>: The second value to compare.

 * <i>ctx</i>: A precision context to control precision, rounding, and exponent range of the result. If HasFlags of the context is true, will also store the flags resulting from the operation (the flags are in addition to the pre-existing flags). Can be null.

<b>Returns:</b>

The larger value of the two numbers.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>first</i>
 or  <i>second</i>
 is null.

### MaxMagnitude

    public static PeterO.ExtendedDecimal MaxMagnitude(
        PeterO.ExtendedDecimal first,
        PeterO.ExtendedDecimal second);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Gets the greater value between two values, ignoring their signs. If the absolute values are equal, has the same effect as Max.

<b>Parameters:</b>

 * <i>first</i>: The first value to compare.

 * <i>second</i>: The second value to compare.

<b>Returns:</b>

An arbitrary-precision decimal number.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>first</i>
 or  <i>second</i>
 is null.

### MaxMagnitude

    public static PeterO.ExtendedDecimal MaxMagnitude(
        PeterO.ExtendedDecimal first,
        PeterO.ExtendedDecimal second,
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Gets the greater value between two values, ignoring their signs. If the absolute values are equal, has the same effect as Max.

<b>Parameters:</b>

 * <i>first</i>: The first value to compare.

 * <i>second</i>: The second value to compare.

 * <i>ctx</i>: A precision context to control precision, rounding, and exponent range of the result. If HasFlags of the context is true, will also store the flags resulting from the operation (the flags are in addition to the pre-existing flags). Can be null.

<b>Returns:</b>

An arbitrary-precision decimal number.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>first</i>
 or  <i>second</i>
 is null.

### Min

    public static PeterO.ExtendedDecimal Min(
        PeterO.ExtendedDecimal first,
        PeterO.ExtendedDecimal second);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Gets the lesser value between two decimal numbers.

<b>Parameters:</b>

 * <i>first</i>: The first value to compare.

 * <i>second</i>: The second value to compare.

<b>Returns:</b>

The smaller value of the two numbers.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>first</i>
 or  <i>second</i>
 is null.

### Min

    public static PeterO.ExtendedDecimal Min(
        PeterO.ExtendedDecimal first,
        PeterO.ExtendedDecimal second,
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Gets the lesser value between two decimal numbers.

<b>Parameters:</b>

 * <i>first</i>: The first value to compare.

 * <i>second</i>: The second value to compare.

 * <i>ctx</i>: A precision context to control precision, rounding, and exponent range of the result. If HasFlags of the context is true, will also store the flags resulting from the operation (the flags are in addition to the pre-existing flags). Can be null.

<b>Returns:</b>

The smaller value of the two numbers.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>first</i>
 or  <i>second</i>
 is null.

### MinMagnitude

    public static PeterO.ExtendedDecimal MinMagnitude(
        PeterO.ExtendedDecimal first,
        PeterO.ExtendedDecimal second);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Gets the lesser value between two values, ignoring their signs. If the absolute values are equal, has the same effect as Min.

<b>Parameters:</b>

 * <i>first</i>: The first value to compare.

 * <i>second</i>: The second value to compare.

<b>Returns:</b>

An arbitrary-precision decimal number.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>first</i>
 or  <i>second</i>
 is null.

### MinMagnitude

    public static PeterO.ExtendedDecimal MinMagnitude(
        PeterO.ExtendedDecimal first,
        PeterO.ExtendedDecimal second,
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Gets the lesser value between two values, ignoring their signs. If the absolute values are equal, has the same effect as Min.

<b>Parameters:</b>

 * <i>first</i>: The first value to compare.

 * <i>second</i>: The second value to compare.

 * <i>ctx</i>: A precision context to control precision, rounding, and exponent range of the result. If HasFlags of the context is true, will also store the flags resulting from the operation (the flags are in addition to the pre-existing flags). Can be null.

<b>Returns:</b>

An arbitrary-precision decimal number.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>first</i>
 or  <i>second</i>
 is null.

### MovePointLeft

    public PeterO.ExtendedDecimal MovePointLeft(
        int places);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Returns a number similar to this number but with the decimal point moved to the left.

<b>Parameters:</b>

 * <i>places</i>: A 32-bit signed integer.

<b>Returns:</b>

An arbitrary-precision decimal number.

### MovePointLeft

    public PeterO.ExtendedDecimal MovePointLeft(
        int places,
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Returns a number similar to this number but with the decimal point moved to the left.

<b>Parameters:</b>

 * <i>places</i>: A 32-bit signed integer.

 * <i>ctx</i>: A precision context to control precision, rounding, and exponent range of the result. If HasFlags of the context is true, will also store the flags resulting from the operation (the flags are in addition to the pre-existing flags). Can be null.

<b>Returns:</b>

An arbitrary-precision decimal number.

### MovePointLeft

    public PeterO.ExtendedDecimal MovePointLeft(
        PeterO.BigInteger bigPlaces);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Returns a number similar to this number but with the decimal point moved to the left.

<b>Parameters:</b>

 * <i>bigPlaces</i>: An arbitrary-precision integer.

<b>Returns:</b>

An arbitrary-precision decimal number.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>bigPlaces</i>
 is null.

### MovePointLeft

    public PeterO.ExtendedDecimal MovePointLeft(
        PeterO.BigInteger bigPlaces,
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Returns a number similar to this number but with the decimal point moved to the left.

<b>Parameters:</b>

 * <i>bigPlaces</i>: An arbitrary-precision integer.

 * <i>ctx</i>: A precision context to control precision, rounding, and exponent range of the result. If HasFlags of the context is true, will also store the flags resulting from the operation (the flags are in addition to the pre-existing flags). Can be null.

<b>Returns:</b>

An arbitrary-precision decimal number.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>bigPlaces</i>
 is null.

### MovePointRight

    public PeterO.ExtendedDecimal MovePointRight(
        int places);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Returns a number similar to this number but with the decimal point moved to the right.

<b>Parameters:</b>

 * <i>places</i>: A 32-bit signed integer.

<b>Returns:</b>

An arbitrary-precision decimal number.

### MovePointRight

    public PeterO.ExtendedDecimal MovePointRight(
        int places,
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Returns a number similar to this number but with the decimal point moved to the right.

<b>Parameters:</b>

 * <i>places</i>: A 32-bit signed integer.

 * <i>ctx</i>: A precision context to control precision, rounding, and exponent range of the result. If HasFlags of the context is true, will also store the flags resulting from the operation (the flags are in addition to the pre-existing flags). Can be null.

<b>Returns:</b>

An arbitrary-precision decimal number.

### MovePointRight

    public PeterO.ExtendedDecimal MovePointRight(
        PeterO.BigInteger bigPlaces);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Returns a number similar to this number but with the decimal point moved to the right.

<b>Parameters:</b>

 * <i>bigPlaces</i>: An arbitrary-precision integer.

<b>Returns:</b>

An arbitrary-precision decimal number.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>bigPlaces</i>
 is null.

### MovePointRight

    public PeterO.ExtendedDecimal MovePointRight(
        PeterO.BigInteger bigPlaces,
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Returns a number similar to this number but with the decimal point moved to the right.

<b>Parameters:</b>

 * <i>bigPlaces</i>: An arbitrary-precision integer.

 * <i>ctx</i>: A precision context to control precision, rounding, and exponent range of the result. If HasFlags of the context is true, will also store the flags resulting from the operation (the flags are in addition to the pre-existing flags). Can be null.

<b>Returns:</b>

A number whose scale is increased by  <i>bigPlaces</i>
, but not to more than 0.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>bigPlaces</i>
 is null.

### Multiply

    public PeterO.ExtendedDecimal Multiply(
        PeterO.ExtendedDecimal op,
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Multiplies two decimal numbers. The resulting scale will be the sum of the scales of the two decimal numbers. The result's sign is positive if both operands have the same sign, and negative if they have different signs.

<b>Parameters:</b>

 * <i>op</i>: Another decimal number.

 * <i>ctx</i>: A precision context to control precision, rounding, and exponent range of the result. If HasFlags of the context is true, will also store the flags resulting from the operation (the flags are in addition to the pre-existing flags). Can be null.

<b>Returns:</b>

The product of the two decimal numbers.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>op</i>
 is null.

### Multiply

    public PeterO.ExtendedDecimal Multiply(
        PeterO.ExtendedDecimal otherValue);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Multiplies two decimal numbers. The resulting exponent will be the sum of the exponents of the two decimal numbers.

<b>Parameters:</b>

 * <i>otherValue</i>: Another decimal number.

<b>Returns:</b>

The product of the two decimal numbers.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>otherValue</i>
 is null.

### MultiplyAndAdd

    public PeterO.ExtendedDecimal MultiplyAndAdd(
        PeterO.ExtendedDecimal multiplicand,
        PeterO.ExtendedDecimal augend);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Multiplies by one decimal number, and then adds another decimal number.

<b>Parameters:</b>

 * <i>multiplicand</i>: The value to multiply.

 * <i>augend</i>: The value to add.

<b>Returns:</b>

The result this *  <i>multiplicand</i>
 + <i>augend</i>
.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>multiplicand</i>
 or  <i>augend</i>
 is null.

### MultiplyAndAdd

    public PeterO.ExtendedDecimal MultiplyAndAdd(
        PeterO.ExtendedDecimal op,
        PeterO.ExtendedDecimal augend,
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Multiplies by one value, and then adds another value.

<b>Parameters:</b>

 * <i>op</i>: The value to multiply.

 * <i>augend</i>: The value to add.

 * <i>ctx</i>: A precision context to control precision, rounding, and exponent range of the result. If HasFlags of the context is true, will also store the flags resulting from the operation (the flags are in addition to the pre-existing flags). Can be null.

<b>Returns:</b>

The result thisValue * multiplicand + augend.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>op</i>
 or  <i>augend</i>
 is null.

### MultiplyAndSubtract

    public PeterO.ExtendedDecimal MultiplyAndSubtract(
        PeterO.ExtendedDecimal op,
        PeterO.ExtendedDecimal subtrahend,
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Multiplies by one value, and then subtracts another value.

<b>Parameters:</b>

 * <i>op</i>: The value to multiply.

 * <i>subtrahend</i>: The value to subtract.

 * <i>ctx</i>: A precision context to control precision, rounding, and exponent range of the result. If HasFlags of the context is true, will also store the flags resulting from the operation (the flags are in addition to the pre-existing flags). Can be null.

<b>Returns:</b>

The result thisValue * multiplicand - subtrahend.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>op</i>
 or  <i>subtrahend</i>
 is null.

### Negate

    public PeterO.ExtendedDecimal Negate(
        PeterO.PrecisionContext context);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Returns a decimal number with the same value as this object but with the sign reversed.

<b>Parameters:</b>

 * <i>context</i>: A precision context to control precision, rounding, and exponent range of the result. If HasFlags of the context is true, will also store the flags resulting from the operation (the flags are in addition to the pre-existing flags). Can be null.

<b>Returns:</b>

An arbitrary-precision decimal number. If this value is positive zero, returns positive zero.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>context</i>
 is null.

### Negate

    public PeterO.ExtendedDecimal Negate();

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Gets an object with the same value as this one, but with the sign reversed.

<b>Returns:</b>

An arbitrary-precision decimal number. If this value is positive zero, returns positive zero.

### NextMinus

    public PeterO.ExtendedDecimal NextMinus(
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Finds the largest value that's smaller than the given value.

<b>Parameters:</b>

 * <i>ctx</i>: A precision context object to control the precision and exponent range of the result. The rounding mode from this context is ignored. If HasFlags of the context is true, will also store the flags resulting from the operation (the flags are in addition to the pre-existing flags).

<b>Returns:</b>

Returns the largest value that's less than the given value. Returns negative infinity if the result is negative infinity. Signals FlagInvalid and returns not-a-number (NaN) if the parameter  <i>ctx</i>
 is null, the precision is 0, or <i>ctx</i>
 has an unlimited exponent range.

### NextPlus

    public PeterO.ExtendedDecimal NextPlus(
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Finds the smallest value that's greater than the given value.

<b>Parameters:</b>

 * <i>ctx</i>: A precision context object to control the precision and exponent range of the result. The rounding mode from this context is ignored. If HasFlags of the context is true, will also store the flags resulting from the operation (the flags are in addition to the pre-existing flags).

<b>Returns:</b>

Returns the smallest value that's greater than the given value.Signals FlagInvalid and returns not-a-number (NaN) if the parameter  <i>ctx</i>
 is null, the precision is 0, or <i>ctx</i>
 has an unlimited exponent range.

### NextToward

    public PeterO.ExtendedDecimal NextToward(
        PeterO.ExtendedDecimal otherValue,
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Finds the next value that is closer to the other object's value than this object's value. Returns a copy of this value with the same sign as the other value if both values are equal.

<b>Parameters:</b>

 * <i>otherValue</i>: An arbitrary-precision decimal number.

 * <i>ctx</i>: A precision context object to control the precision and exponent range of the result. The rounding mode from this context is ignored. If HasFlags of the context is true, will also store the flags resulting from the operation (the flags are in addition to the pre-existing flags).

<b>Returns:</b>

Returns the next value that is closer to the other object' s value than this object's value. Signals FlagInvalid and returns NaN if the parameter  <i>ctx</i>
 is null, the precision is 0, or  <i>ctx</i>
 has an unlimited exponent range.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>otherValue</i>
 is null.

### PI

    public static PeterO.ExtendedDecimal PI(
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Finds the constant π, the circumference of a circle divided by its diameter.

<b>Parameters:</b>

 * <i>ctx</i>: A precision context to control precision, rounding, and exponent range of the result. If HasFlags of the context is true, will also store the flags resulting from the operation (the flags are in addition to the pre-existing flags).This parameter cannot be null, as π can never be represented exactly..

<b>Returns:</b>

The constant π rounded to the given precision. Signals FlagInvalid and returns not-a-number (NaN) if the parameter <i>ctx</i>
 is null or the precision is unlimited (the context's Precision property is 0).

### Plus

    public PeterO.ExtendedDecimal Plus(
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Rounds this object's value to a given precision, using the given rounding mode and range of exponent, and also converts negative zero to positive zero.

<b>Parameters:</b>

 * <i>ctx</i>: A context for controlling the precision, rounding mode, and exponent range. Can be null.

<b>Returns:</b>

The closest value to this object's value, rounded to the specified precision. Returns the same value as this object if <i>ctx</i>
 is null or the precision and exponent range are unlimited.

### Pow

    public PeterO.ExtendedDecimal Pow(
        int exponentSmall);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Raises this object's value to the given exponent.

<b>Parameters:</b>

 * <i>exponentSmall</i>: A 32-bit signed integer.

<b>Returns:</b>

This^exponent. Returns not-a-number (NaN) if this object and exponent are both 0.

### Pow

    public PeterO.ExtendedDecimal Pow(
        int exponentSmall,
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Raises this object's value to the given exponent.

<b>Parameters:</b>

 * <i>exponentSmall</i>: A 32-bit signed integer.

 * <i>ctx</i>: A precision context to control precision, rounding, and exponent range of the result. If HasFlags of the context is true, will also store the flags resulting from the operation (the flags are in addition to the pre-existing flags).

<b>Returns:</b>

This^exponent. Signals the flag FlagInvalid and returns NaN if this object and exponent are both 0.

### Pow

    public PeterO.ExtendedDecimal Pow(
        PeterO.ExtendedDecimal exponent,
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Raises this object's value to the given exponent.

<b>Parameters:</b>

 * <i>exponent</i>: An arbitrary-precision decimal number.

 * <i>ctx</i>: A precision context to control precision, rounding, and exponent range of the result. If HasFlags of the context is true, will also store the flags resulting from the operation (the flags are in addition to the pre-existing flags).

<b>Returns:</b>

This^exponent. Signals the flag FlagInvalid and returns NaN if this object and exponent are both 0; or if this value is less than 0 and the exponent either has a fractional part or is infinity. Signals FlagInvalid and returns not-a-number (NaN) if the parameter  <i>ctx</i>
 is null or the precision is unlimited (the context's Precision property is 0), and the exponent has a fractional part.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>exponent</i>
 is null.

### Precision

    public PeterO.BigInteger Precision();

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Finds the number of digits in this number's mantissa. Returns 1 if this value is 0, and 0 if this value is infinity or NaN.

<b>Returns:</b>

An arbitrary-precision integer.

### Quantize

    public PeterO.ExtendedDecimal Quantize(
        int desiredExponentSmall,
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Returns a decimal number with the same value but a new exponent.Note that this is not always the same as rounding to a given number of decimal places, since it can fail if the difference between this value's exponent and the desired exponent is too big, depending on the maximum precision. If rounding to a number of decimal places is desired, it's better to use the RoundToExponent and RoundToIntegral methods instead.

<b>Parameters:</b>

 * <i>desiredExponentSmall</i>: The desired exponent for the result. The exponent is the number of fractional digits in the result, expressed as a negative number. Can also be positive, which eliminates lower-order places from the number. For example, -3 means round to the thousandth (10^-3, 0.0001), and 3 means round to the thousand (10^3, 1000). A value of 0 rounds the number to an integer.

 * <i>ctx</i>: A precision context to control precision and rounding of the result. If HasFlags of the context is true, will also store the flags resulting from the operation (the flags are in addition to the pre-existing flags). Can be null, in which case the default rounding mode is HalfEven.

<b>Returns:</b>

A decimal number with the same value as this object but with the exponent changed. Signals FlagInvalid and returns not-a-number (NaN) if the rounded result can't fit the given precision, or if the context defines an exponent range and the given exponent is outside that range.

### Quantize

    public PeterO.ExtendedDecimal Quantize(
        int desiredExponentSmall,
        PeterO.Rounding rounding);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Returns a decimal number with the same value as this one but a new exponent.

<b>Parameters:</b>

 * <i>desiredExponentSmall</i>: The desired exponent for the result. The exponent is the number of fractional digits in the result, expressed as a negative number. Can also be positive, which eliminates lower-order places from the number. For example, -3 means round to the thousandth (10^-3, 0.0001), and 3 means round to the thousand (10^3, 1000). A value of 0 rounds the number to an integer.

 * <i>rounding</i>: The mode to use when the result needs to be rounded in order to have the given exponent.

<b>Returns:</b>

A decimal number with the same value as this object but with the exponent changed. Returns not-a-number (NaN) if the rounding mode is Rounding.Unnecessary and the result is not exact.

### Quantize

    public PeterO.ExtendedDecimal Quantize(
        PeterO.BigInteger desiredExponent,
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Returns a decimal number with the same value but a new exponent.Note that this is not always the same as rounding to a given number of decimal places, since it can fail if the difference between this value's exponent and the desired exponent is too big, depending on the maximum precision. If rounding to a number of decimal places is desired, it's better to use the RoundToExponent and RoundToIntegral methods instead.

<b>Parameters:</b>

 * <i>desiredExponent</i>: An arbitrary-precision integer.

 * <i>ctx</i>: A precision context to control precision and rounding of the result. If HasFlags of the context is true, will also store the flags resulting from the operation (the flags are in addition to the pre-existing flags). Can be null, in which case the default rounding mode is HalfEven.

<b>Returns:</b>

A decimal number with the same value as this object but with the exponent changed. Signals FlagInvalid and returns not-a-number (NaN) if the rounded result can't fit the given precision, or if the context defines an exponent range and the given exponent is outside that range.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>desiredExponent</i>
 is null.

### Quantize

    public PeterO.ExtendedDecimal Quantize(
        PeterO.ExtendedDecimal otherValue,
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Returns a decimal number with the same value as this object but with the same exponent as another decimal number.Note that this is not always the same as rounding to a given number of decimal places, since it can fail if the difference between this value's exponent and the desired exponent is too big, depending on the maximum precision. If rounding to a number of decimal places is desired, it's better to use the RoundToExponent and RoundToIntegral methods instead.

<b>Parameters:</b>

 * <i>otherValue</i>: A decimal number containing the desired exponent of the result. The mantissa is ignored. The exponent is the number of fractional digits in the result, expressed as a negative number. Can also be positive, which eliminates lower-order places from the number. For example, -3 means round to the thousandth (10^-3, 0.0001), and 3 means round to the thousand (10^3, 1000). A value of 0 rounds the number to an integer.

 * <i>ctx</i>: A precision context to control precision and rounding of the result. If HasFlags of the context is true, will also store the flags resulting from the operation (the flags are in addition to the pre-existing flags). Can be null, in which case the default rounding mode is HalfEven.

<b>Returns:</b>

A decimal number with the same value as this object but with the exponent changed. Signals FlagInvalid and returns not-a-number (NaN) if the result can't fit the given precision without rounding, or if the precision context defines an exponent range and the given exponent is outside that range.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>otherValue</i>
 is null.

### Reduce

    public PeterO.ExtendedDecimal Reduce(
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Removes trailing zeros from this object's mantissa. For example, 1.00 becomes 1.If this object's value is 0, changes the exponent to 0.

<b>Parameters:</b>

 * <i>ctx</i>: A precision context to control precision, rounding, and exponent range of the result. If HasFlags of the context is true, will also store the flags resulting from the operation (the flags are in addition to the pre-existing flags). Can be null.

<b>Returns:</b>

This value with trailing zeros removed. Note that if the result has a very high exponent and the context says to clamp high exponents, there may still be some trailing zeros in the mantissa.

### Remainder

    public PeterO.ExtendedDecimal Remainder(
        PeterO.ExtendedDecimal divisor,
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Finds the remainder that results when dividing two arbitrary-precision decimal numbers.

<b>Parameters:</b>

 * <i>divisor</i>: An arbitrary-precision decimal number.

 * <i>ctx</i>: The parameter  <i>ctx</i>
 is not documented yet.

<b>Returns:</b>

The remainder of the two numbers.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>divisor</i>
 is null.

### RemainderNaturalScale

    public PeterO.ExtendedDecimal RemainderNaturalScale(
        PeterO.ExtendedDecimal divisor);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Calculates the remainder of a number by the formula "this" - (("this" / "divisor") * "divisor").

<b>Parameters:</b>

 * <i>divisor</i>: The number to divide by.

<b>Returns:</b>

An arbitrary-precision decimal number.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>divisor</i>
 is null.

### RemainderNaturalScale

    public PeterO.ExtendedDecimal RemainderNaturalScale(
        PeterO.ExtendedDecimal divisor,
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Calculates the remainder of a number by the formula "this" - (("this" / "divisor") * "divisor").

<b>Parameters:</b>

 * <i>divisor</i>: The number to divide by.

 * <i>ctx</i>: A precision context object to control the precision, rounding, and exponent range of the result. This context will be used only in the division portion of the remainder calculation; as a result, it's possible for the return value to have a higher precision than given in this context. Flags will be set on the given context only if the context's HasFlags is true and the integer part of the division result doesn't fit the precision and exponent range without rounding.

<b>Returns:</b>

An arbitrary-precision decimal number.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>divisor</i>
 is null.

### RemainderNear

    public PeterO.ExtendedDecimal RemainderNear(
        PeterO.ExtendedDecimal divisor,
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Finds the distance to the closest multiple of the given divisor, based on the result of dividing this object's value by another object's value.

 * If this and the other object divide evenly, the result is 0.

 * If the remainder's absolute value is less than half of the divisor's absolute value, the result has the same sign as this object and will be the distance to the closest multiple.

 * If the remainder's absolute value is more than half of the divisor' s absolute value, the result has the opposite sign of this object and will be the distance to the closest multiple.

 * If the remainder's absolute value is exactly half of the divisor's absolute value, the result has the opposite sign of this object if the quotient, rounded down, is odd, and has the same sign as this object if the quotient, rounded down, is even, and the result's absolute value is half of the divisor's absolute value.

 This function is also known as the "IEEE Remainder" function.

<b>Parameters:</b>

 * <i>divisor</i>: The number to divide by.

 * <i>ctx</i>: A precision context object to control the precision. The rounding and exponent range settings of this context are ignored (the rounding mode is always treated as HalfEven). If HasFlags of the context is true, will also store the flags resulting from the operation (the flags are in addition to the pre-existing flags). Can be null.

<b>Returns:</b>

The distance of the closest multiple. Signals FlagInvalid and returns not-a-number (NaN) if the divisor is 0, or either the result of integer division (the quotient) or the remainder wouldn't fit the given precision.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>divisor</i>
 is null.

### RoundToBinaryPrecision

    public PeterO.ExtendedDecimal RoundToBinaryPrecision(
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Rounds this object's value to a given maximum bit length, using the given rounding mode and range of exponent.

<b>Parameters:</b>

 * <i>ctx</i>: A context for controlling the precision, rounding mode, and exponent range. The precision is interpreted as the maximum bit length of the mantissa. Can be null.

<b>Returns:</b>

The closest value to this object's value, rounded to the specified precision. Returns the same value as this object if <i>ctx</i>
 is null or the precision and exponent range are unlimited.

### RoundToExponent

    public PeterO.ExtendedDecimal RoundToExponent(
        int exponentSmall,
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Returns a decimal number with the same value as this object but rounded to a new exponent if necessary.

<b>Parameters:</b>

 * <i>exponentSmall</i>: The minimum exponent the result can have. This is the maximum number of fractional digits in the result, expressed as a negative number. Can also be positive, which eliminates lower-order places from the number. For example, -3 means round to the thousandth (10^-3, 0.0001), and 3 means round to the thousand (10^3, 1000). A value of 0 rounds the number to an integer.

 * <i>ctx</i>: A precision context to control precision, rounding, and exponent range of the result. If HasFlags of the context is true, will also store the flags resulting from the operation (the flags are in addition to the pre-existing flags). Can be null, in which case the default rounding mode is HalfEven.

<b>Returns:</b>

A decimal number rounded to the closest value representable in the given precision, meaning if the result can't fit the precision, additional digits are discarded to make it fit. Signals FlagInvalid and returns not-a-number (NaN) if the precision context defines an exponent range, the new exponent must be changed to the given exponent when rounding, and the given exponent is outside of the valid range of the precision context.

### RoundToExponent

    public PeterO.ExtendedDecimal RoundToExponent(
        PeterO.BigInteger exponent,
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Returns a decimal number with the same value as this object but rounded to a new exponent if necessary.

<b>Parameters:</b>

 * <i>exponent</i>: The minimum exponent the result can have. This is the maximum number of fractional digits in the result, expressed as a negative number. Can also be positive, which eliminates lower-order places from the number. For example, -3 means round to the thousandth (10^-3, 0.0001), and 3 means round to the thousand (10^3, 1000). A value of 0 rounds the number to an integer.

 * <i>ctx</i>: A precision context to control precision, rounding, and exponent range of the result. If HasFlags of the context is true, will also store the flags resulting from the operation (the flags are in addition to the pre-existing flags). Can be null, in which case the default rounding mode is HalfEven.

<b>Returns:</b>

A decimal number rounded to the closest value representable in the given precision, meaning if the result can't fit the precision, additional digits are discarded to make it fit. Signals FlagInvalid and returns not-a-number (NaN) if the precision context defines an exponent range, the new exponent must be changed to the given exponent when rounding, and the given exponent is outside of the valid range of the precision context.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>exponent</i>
 is null.

### RoundToExponentExact

    public PeterO.ExtendedDecimal RoundToExponentExact(
        int exponentSmall,
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Returns a decimal number with the same value as this object but rounded to an integer, and signals an inexact flag if the result would be inexact.

<b>Parameters:</b>

 * <i>exponentSmall</i>: The minimum exponent the result can have. This is the maximum number of fractional digits in the result, expressed as a negative number. Can also be positive, which eliminates lower-order places from the number. For example, -3 means round to the thousandth (10^-3, 0.0001), and 3 means round to the thousand (10^3, 1000). A value of 0 rounds the number to an integer.

 * <i>ctx</i>: A context object for arbitrary-precision arithmetic settings.

<b>Returns:</b>

A decimal number rounded to the closest value representable in the given precision. Signals FlagInvalid and returns not-a-number (NaN) if the result can't fit the given precision without rounding. Signals FlagInvalid and returns not-a-number (NaN) if the precision context defines an exponent range, the new exponent must be changed to the given exponent when rounding, and the given exponent is outside of the valid range of the precision context.

### RoundToExponentExact

    public PeterO.ExtendedDecimal RoundToExponentExact(
        PeterO.BigInteger exponent,
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Returns a decimal number with the same value as this object but rounded to an integer, and signals an inexact flag if the result would be inexact.

<b>Parameters:</b>

 * <i>exponent</i>: The minimum exponent the result can have. This is the maximum number of fractional digits in the result, expressed as a negative number. Can also be positive, which eliminates lower-order places from the number. For example, -3 means round to the thousandth (10^-3, 0.0001), and 3 means round to the thousand (10^3, 1000). A value of 0 rounds the number to an integer.

 * <i>ctx</i>: A context object for arbitrary-precision arithmetic settings.

<b>Returns:</b>

A decimal number rounded to the closest value representable in the given precision. Signals FlagInvalid and returns not-a-number (NaN) if the result can't fit the given precision without rounding. Signals FlagInvalid and returns not-a-number (NaN) if the precision context defines an exponent range, the new exponent must be changed to the given exponent when rounding, and the given exponent is outside of the valid range of the precision context.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>exponent</i>
 is null.

### RoundToIntegralExact

    public PeterO.ExtendedDecimal RoundToIntegralExact(
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Returns a decimal number with the same value as this object but rounded to an integer, and signals an inexact flag if the result would be inexact.

<b>Parameters:</b>

 * <i>ctx</i>: A precision context to control precision and rounding of the result. If HasFlags of the context is true, will also store the flags resulting from the operation (the flags are in addition to the pre-existing flags). Can be null, in which case the default rounding mode is HalfEven.

<b>Returns:</b>

A decimal number rounded to the closest integer representable in the given precision. Signals FlagInvalid and returns not-a-number (NaN) if the result can't fit the given precision without rounding. Signals FlagInvalid and returns not-a-number (NaN) if the precision context defines an exponent range, the new exponent must be changed to 0 when rounding, and 0 is outside of the valid range of the precision context.

### RoundToIntegralNoRoundedFlag

    public PeterO.ExtendedDecimal RoundToIntegralNoRoundedFlag(
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Returns a decimal number with the same value as this object but rounded to an integer, without adding the FlagInexact or FlagRounded flags.

<b>Parameters:</b>

 * <i>ctx</i>: A precision context to control precision and rounding of the result. If HasFlags of the context is true, will also store the flags resulting from the operation (the flags are in addition to the pre-existing flags), except that this function will never add the FlagRounded and FlagInexact flags (the only difference between this and RoundToExponentExact). Can be null, in which case the default rounding mode is HalfEven.

<b>Returns:</b>

A decimal number rounded to the closest integer representable in the given precision, meaning if the result can't fit the precision, additional digits are discarded to make it fit. Signals FlagInvalid and returns not-a-number (NaN) if the precision context defines an exponent range, the new exponent must be changed to 0 when rounding, and 0 is outside of the valid range of the precision context.

### RoundToPrecision

    public PeterO.ExtendedDecimal RoundToPrecision(
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Rounds this object's value to a given precision, using the given rounding mode and range of exponent.

<b>Parameters:</b>

 * <i>ctx</i>: A context for controlling the precision, rounding mode, and exponent range. Can be null.

<b>Returns:</b>

The closest value to this object's value, rounded to the specified precision. Returns the same value as this object if <i>ctx</i>
 is null or the precision and exponent range are unlimited.

### ScaleByPowerOfTen

    public PeterO.ExtendedDecimal ScaleByPowerOfTen(
        int places);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Returns a number similar to this number but with the scale adjusted.

<b>Parameters:</b>

 * <i>places</i>: A 32-bit signed integer.

<b>Returns:</b>

An arbitrary-precision decimal number.

### ScaleByPowerOfTen

    public PeterO.ExtendedDecimal ScaleByPowerOfTen(
        int places,
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Returns a number similar to this number but with the scale adjusted.

<b>Parameters:</b>

 * <i>places</i>: A 32-bit signed integer.

 * <i>ctx</i>: A precision context to control precision, rounding, and exponent range of the result. If HasFlags of the context is true, will also store the flags resulting from the operation (the flags are in addition to the pre-existing flags). Can be null.

<b>Returns:</b>

An arbitrary-precision decimal number.

### ScaleByPowerOfTen

    public PeterO.ExtendedDecimal ScaleByPowerOfTen(
        PeterO.BigInteger bigPlaces);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Returns a number similar to this number but with the scale adjusted.

<b>Parameters:</b>

 * <i>bigPlaces</i>: An arbitrary-precision integer.

<b>Returns:</b>

An arbitrary-precision decimal number.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>bigPlaces</i>
 is null.

### ScaleByPowerOfTen

    public PeterO.ExtendedDecimal ScaleByPowerOfTen(
        PeterO.BigInteger bigPlaces,
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Returns a number similar to this number but with its scale adjusted.

<b>Parameters:</b>

 * <i>bigPlaces</i>: An arbitrary-precision integer.

 * <i>ctx</i>: A precision context to control precision, rounding, and exponent range of the result. If HasFlags of the context is true, will also store the flags resulting from the operation (the flags are in addition to the pre-existing flags). Can be null.

<b>Returns:</b>

A number whose scale is increased by  <i>bigPlaces</i>
.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>bigPlaces</i>
 is null.

### SquareRoot

    public PeterO.ExtendedDecimal SquareRoot(
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Finds the square root of this object's value.

<b>Parameters:</b>

 * <i>ctx</i>: A precision context to control precision, rounding, and exponent range of the result. If HasFlags of the context is true, will also store the flags resulting from the operation (the flags are in addition to the pre-existing flags).This parameter cannot be null, as the square root function's results are generally not exact for many inputs..

<b>Returns:</b>

The square root. Signals the flag FlagInvalid and returns NaN if this object is less than 0 (the square root would be a complex number, but the return value is still NaN). Signals FlagInvalid and returns not-a-number (NaN) if the parameter <i>ctx</i>
 is null or the precision is unlimited (the context's Precision property is 0).

### Subtract

    public PeterO.ExtendedDecimal Subtract(
        PeterO.ExtendedDecimal otherValue);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Subtracts an arbitrary-precision decimal number from this instance and returns the result.

<b>Parameters:</b>

 * <i>otherValue</i>: An arbitrary-precision decimal number.

<b>Returns:</b>

The difference of the two objects.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>otherValue</i>
 is null.

### Subtract

    public PeterO.ExtendedDecimal Subtract(
        PeterO.ExtendedDecimal otherValue,
        PeterO.PrecisionContext ctx);

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Subtracts an arbitrary-precision decimal number from this instance.

<b>Parameters:</b>

 * <i>otherValue</i>: An arbitrary-precision decimal number.

 * <i>ctx</i>: A precision context to control precision, rounding, and exponent range of the result. If HasFlags of the context is true, will also store the flags resulting from the operation (the flags are in addition to the pre-existing flags). Can be null.

<b>Returns:</b>

The difference of the two objects.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>otherValue</i>
 is null.

### ToBigInteger

    public PeterO.BigInteger ToBigInteger();

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Converts this value to an arbitrary-precision integer. Any fractional part in this value will be discarded when converting to a big integer.

<b>Returns:</b>

An arbitrary-precision integer.

<b>Exceptions:</b>

 * System.OverflowException:
This object's value is infinity or NaN.

### ToBigIntegerExact

    public PeterO.BigInteger ToBigIntegerExact();

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Converts this value to an arbitrary-precision integer, checking whether the fractional part of the integer would be lost.

<b>Returns:</b>

An arbitrary-precision integer.

<b>Exceptions:</b>

 * System.OverflowException:
This object's value is infinity or NaN.

 * System.ArithmeticException:
This object's value is not an exact integer.

### ToDouble

    public double ToDouble();

Converts this value to a 64-bit floating-point number. The half-even rounding mode is used.If this value is a NaN, sets the high bit of the 64-bit floating point number's mantissa for a quiet NaN, and clears it for a signaling NaN. Then the next highest bit of the mantissa is cleared for a quiet NaN, and set for a signaling NaN. Then the other bits of the mantissa are set to the lowest bits of this object's unsigned mantissa.

<b>Returns:</b>

The closest 64-bit floating-point number to this value. The return value can be positive infinity or negative infinity if this value exceeds the range of a 64-bit floating point number.

### ToEngineeringString

    public string ToEngineeringString();

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Same as toString(), except that when an exponent is used it will be a multiple of 3.

<b>Returns:</b>

A text string.

### ToExtendedFloat

    public PeterO.ExtendedFloat ToExtendedFloat();

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Creates a binary floating-point number from this object's value. Note that if the binary floating-point number contains a negative exponent, the resulting value might not be exact, in which case the resulting binary float will be an approximation of this decimal number's value. (NOTE: This documentation previously said the binary float will contain enough precision to accurately convert it to a 32-bit or 64-bit floating point number. Due to double rounding, this will generally not be the case for certain numbers converted from decimal to ExtendedFloat via this method and in turn converted to `double`  or  `float` .).

<b>Returns:</b>

An arbitrary-precision binary float.

### ToPlainString

    public string ToPlainString();

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Converts this value to a string, but without using exponential notation.

<b>Returns:</b>

A text string.

### ToSingle

    public float ToSingle();

Converts this value to a 32-bit floating-point number. The half-even rounding mode is used.If this value is a NaN, sets the high bit of the 32-bit floating point number's mantissa for a quiet NaN, and clears it for a signaling NaN. Then the next highest bit of the mantissa is cleared for a quiet NaN, and set for a signaling NaN. Then the other bits of the mantissa are set to the lowest bits of this object's unsigned mantissa.

<b>Returns:</b>

The closest 32-bit floating-point number to this value. The return value can be positive infinity or negative infinity if this value exceeds the range of a 32-bit floating point number.

### ToString

    public override string ToString();

Converts this value to a string. Returns a value compatible with this class's FromString method.

<b>Returns:</b>

A string representation of this object.

### Ulp

    public PeterO.ExtendedDecimal Ulp();

<b>Deprecated.</b> Use EDecimal from PeterO.Numbers/com.upokecenter.numbers.

Returns the unit in the last place. The mantissa will be 1 and the exponent will be this number's exponent. Returns 1 with an exponent of 0 if this number is infinity or NaN.

<b>Returns:</b>

An arbitrary-precision decimal number.
