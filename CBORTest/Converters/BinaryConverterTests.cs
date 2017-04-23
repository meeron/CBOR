using CBORTest.Converters.TestTypes;
using NUnit.Framework;
using PeterO.Cbor.Converters;
using System;
using System.Collections.Generic;

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

            byte[] serializedData = BinaryConverter.Serialize(testObj);
            Simple deserializedObj = BinaryConverter.Deserialize<Simple>(serializedData);

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

        [Test]
        public void SerializeDeserializeExtendentClassTest()
        {
            var testObj = new Extendent
            {
                DateTime = DateTime.Now,
                TimeSpan = TimeSpan.MaxValue,
                DateTimeOffset = DateTimeOffset.Now,
                Guid = Guid.NewGuid()
            };

            byte[] serializedData = BinaryConverter.Serialize(testObj);
            Extendent deserializedObj = BinaryConverter.Deserialize<Extendent>(serializedData);

            Assert.IsNotNull(deserializedObj);
            Assert.AreEqual(testObj.DateTime, deserializedObj.DateTime);
            Assert.AreEqual(testObj.TimeSpan, deserializedObj.TimeSpan);
            Assert.AreEqual(testObj.DateTimeOffset, deserializedObj.DateTimeOffset);
            Assert.AreEqual(testObj.Guid, deserializedObj.Guid);
        }

        [Test]
        public void SerializeDeserializeComplexClassTest()
        {
            var testObj = new Complex
            {
                ArrayOfInt = new[] { 1, 2 ,3 },
                EnumerableOfString = new List<string>() { "test1", "test2" },
                ListOfDateTime = new List<DateTime>() { DateTime.Now, DateTime.Now.AddDays(-1)  },
                DictionaryOfIntAndString = new Dictionary<int, string>
                {
                    { 1, "test1" },
                    { 2, "test2" }
                }
            };

            byte[] serializedData = BinaryConverter.Serialize(testObj);
            Complex deserializedObj = BinaryConverter.Deserialize<Complex>(serializedData);

            Assert.IsNotNull(deserializedObj);
            Assert.AreEqual(testObj.ArrayOfInt, deserializedObj.ArrayOfInt);
            Assert.AreEqual(testObj.EnumerableOfString, deserializedObj.EnumerableOfString);
            Assert.AreEqual(testObj.ListOfDateTime, deserializedObj.ListOfDateTime);
            Assert.AreEqual(testObj.DictionaryOfIntAndString, deserializedObj.DictionaryOfIntAndString);
        }
    }
}
