using System;
using System.Collections.Generic;
using System.Reflection;

namespace PeterO.Cbor.Converters
{
    /// <include file='../../../docs.xml'
    /// path='docs/doc[@name="T:PeterO.Cbor.Converters.BinaryConverter"]/*'/>
    public sealed class BinaryConverter<T>
        where T : class, new()
    {
        /// <include file='../../../docs.xml'
        /// path='docs/doc[@name="T:PeterO.Cbor.Converters.BinaryConverter.Serialize(T)"]/*'/>
        public byte[] Serialize(T obj)
        {
            var cbor = CBORObject.NewMap();

            foreach (var prop in Properties)
            {
                cbor.Add(prop.Name, prop.GetValue(obj));
            }

            return cbor.EncodeToBytes();
        }

        /// <include file='../../../docs.xml'
        /// path='docs/doc[@name="T:PeterO.Cbor.Converters.BinaryConverter.Deserialize(System.Byte[])"]/*'/>
        public T Deserialize(byte[] serializedOb)
        {
            var cbor = CBORObject.DecodeFromBytes(serializedOb);

            var obj = new T();

            CBORObject cborPropValue;
            foreach (var prop in Properties)
            {
                if (cbor.ContainsKey(prop.Name))
                {
                    cborPropValue = cbor[prop.Name];

                    prop.SetValue(obj, GetValue(prop.PropertyType, cborPropValue));
                }
            }

            return obj;
        }

        private object GetValue(Type type, CBORObject cbor)
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

            return null;
        }

        private IEnumerable<PropertyInfo> Properties => typeof(T).GetRuntimeProperties();
    }
}
