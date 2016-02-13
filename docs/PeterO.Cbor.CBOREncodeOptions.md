## PeterO.Cbor.CBOREncodeOptions

    public sealed class CBOREncodeOptions

Specifies options for encoding and decoding CBOR objects.

### NoDuplicateKeys

    public static readonly PeterO.Cbor.CBOREncodeOptions NoDuplicateKeys;

Disallow duplicate keys when reading CBOR objects from a data stream. Used only when decoding CBOR objects. Value: 2.

### NoIndefLengthStrings

    public static readonly PeterO.Cbor.CBOREncodeOptions NoIndefLengthStrings;

Always encode strings with a definite-length encoding. Used only when encoding CBOR objects. Value: 1.

### None

    public static readonly PeterO.Cbor.CBOREncodeOptions None;

No special options for encoding/decoding. Value: 0.

### Value

    public int Value { get; }

Gets this options object's value.

<b>Returns:</b>

This options object's value.

### And

    public PeterO.Cbor.CBOREncodeOptions And(
        PeterO.Cbor.CBOREncodeOptions o);

Returns an options object whose flags are shared by this and another options object.

<b>Parameters:</b>

 * <i>o</i>: Another CBOREncodeOptions object.

<b>Return Value:</b>

A CBOREncodeOptions object.

### Or

    public PeterO.Cbor.CBOREncodeOptions Or(
        PeterO.Cbor.CBOREncodeOptions o);

Combines the flags of this options object with another options object.

<b>Parameters:</b>

 * <i>o</i>: Another CBOREncodeOptions object.

<b>Return Value:</b>

A CBOREncodeOptions object.
