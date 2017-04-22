using CBORTest.Converters.TestTypes;
using NUnit.Framework;
using PeterO.Cbor.Converters;
using System;

namespace CBORTest.Converters
{
    [TestFixture]
    public class BinaryConverterTests
    {
        [Test]
        public void SerializeDeserializeSimpleClassTest()
        {
            var testObj = new Simple
            {
                Name = "test",
                Int = int.MaxValue,
                UInt = uint.MaxValue,
                Double = double.MaxValue,
                Long = long.MaxValue,
                ULong = ulong.MaxValue,
                IsBool = true,
                Byte = byte.MaxValue,
                Short = short.MaxValue,
                UShort = ushort.MaxValue,
                Float = float.MaxValue,
                Decimal = decimal.MaxValue,
                SByte = sbyte.MaxValue,
                Char = char.MaxValue
            };

            var converter = new BinaryConverter<Simple>();

            byte[] serializedData = converter.Serialize(testObj);
            Simple deserializedObj = converter.Deserialize(serializedData);

            Assert.IsNotNull(deserializedObj);
            Assert.AreEqual(testObj.Name, deserializedObj.Name);
            Assert.AreEqual(testObj.Int, deserializedObj.Int);
            Assert.AreEqual(testObj.Double, deserializedObj.Double);
            Assert.AreEqual(testObj.Long, deserializedObj.Long);
            Assert.AreEqual(testObj.IsBool, deserializedObj.IsBool);
            Assert.AreEqual(testObj.Byte, deserializedObj.Byte);
            Assert.AreEqual(testObj.Short, deserializedObj.Short);
            Assert.AreEqual(testObj.Float, deserializedObj.Float);
            Assert.AreEqual(testObj.Decimal, deserializedObj.Decimal);
            Assert.AreEqual(testObj.SByte, deserializedObj.SByte);
            Assert.AreEqual(testObj.UShort, deserializedObj.UShort);
            Assert.AreEqual(testObj.UInt, deserializedObj.UInt);
            Assert.AreEqual(testObj.ULong, deserializedObj.ULong);
            Assert.AreEqual(testObj.Char, deserializedObj.Char);
        }
    }
}
