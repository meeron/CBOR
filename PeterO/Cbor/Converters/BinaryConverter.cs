using System;
using System.Collections.Generic;
using System.Reflection;

namespace PeterO.Cbor.Converters
{
    /// <include file='../../../docs.xml'
    /// path='docs/doc[@name="T:PeterO.Cbor.Converters.BinaryConverter"]/*'/>
    public static class BinaryConverter
    {
        /// <include file='../../../docs.xml'
        /// path='docs/doc[@name="T:PeterO.Cbor.Converters.BinaryConverter.Serialize(T)"]/*'/>
        public static byte[] Serialize<T>(T obj)
            where T : class, new()
        {
            var cbor = CBORObject.NewMap();

            foreach (var prop in GetProperties<T>())
            {
                cbor.Add(prop.Name, SetValue(prop.GetValue(obj)));
            }

            return cbor.EncodeToBytes();
        }

        /// <include file='../../../docs.xml'
        /// path='docs/doc[@name="T:PeterO.Cbor.Converters.BinaryConverter.Deserialize(System.Byte[])"]/*'/>
        public static T Deserialize<T>(byte[] serializedOb)
            where T : class, new()
        {
            var cbor = CBORObject.DecodeFromBytes(serializedOb);

            var obj = new T();

            CBORObject cborPropValue;
            foreach (var prop in GetProperties<T>())
            {
                if (cbor.ContainsKey(prop.Name))
                {
                    cborPropValue = cbor[prop.Name];

                    prop.SetValue(obj, GetValue(prop.PropertyType, cborPropValue));
                }
            }

            return obj;
        }

        private static object SetValue(object value)
        {
            if (value is DateTime)
                return ((DateTime)value).Ticks;

            if (value is TimeSpan)
                return ((TimeSpan)value).Ticks;

            if (value is DateTimeOffset)
                return Helpers.DateTimeOffsetToBytes((DateTimeOffset)value);

            if (value is Guid)
                return ((Guid)value).ToByteArray();

            if (value is Enum)
                throw new NotSupportedException("Enums are not supported");

            return value;
        }

        private static object GetValue(Type type, CBORObject cbor)
        {
            if (type == typeof(int))
                return cbor.AsInt32();

            if (type == typeof(string))
                return cbor.AsString();

            if (type == typeof(double))
                return cbor.AsDouble();

            if (type == typeof(long))
                return cbor.AsInt64();

            if (type == typeof(bool))
                return cbor.AsBoolean();

            if (type == typeof(byte))
                return cbor.AsByte();

            if (type == typeof(short))
                return cbor.AsInt16();

            if (type == typeof(float))
                return cbor.AsSingle();

            if (type == typeof(decimal))
                return cbor.AsDecimal();

            if (type == typeof(sbyte))
                return cbor.AsSByte();

            if (type == typeof(ushort))
                return cbor.AsUInt16();

            if (type == typeof(uint))
                return cbor.AsUInt32();

            if (type == typeof(ulong))
                return cbor.AsUInt64();

            if (type == typeof(char))
                return Convert.ToChar(cbor.AsString());

            if (type == typeof(DateTime))
                return new DateTime(cbor.AsInt64());

            if (type == typeof(TimeSpan))
                return new TimeSpan(cbor.AsInt64());

            if (type == typeof(DateTimeOffset))
                return Helpers.DateTimeOffsetFromBytes(cbor.GetByteString());

            if (type == typeof(Guid))
                return new Guid(cbor.GetByteString());

            return null;
        }

        private static IEnumerable<PropertyInfo> GetProperties<T>() => typeof(T).GetRuntimeProperties();
    }
}
