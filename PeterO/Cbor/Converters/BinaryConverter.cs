using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        {
            var cbor = SetValue(obj) as CBORObject;
            return cbor.EncodeToBytes();
        }

        /// <include file='../../../docs.xml'
        /// path='docs/doc[@name="T:PeterO.Cbor.Converters.BinaryConverter.Deserialize(System.Byte[])"]/*'/>
        public static T Deserialize<T>(byte[] serializedOb)
        {
            var cbor = CBORObject.DecodeFromBytes(serializedOb);
            return (T)GetValue(typeof(T), cbor);
        }

        private static object SetValue(object value)
        {
            if (value == null)
                return CBORObject.Null;

            if (value is byte[])
                return value;

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

            if (value is IDictionary)
                return SetDictionaryValue(value as IDictionary);

            if (value is IEnumerable && !(value is string))
                return SetCollectionValue(value as IEnumerable);

            if (!value.GetType().Namespace.StartsWith("System"))
                return SetObjectValue(value);

            return CBORObject.FromObject(value);
        }

        private static object SetObjectValue(object value)
        {
            return SetDictionaryValue(Helpers.ObjectToDictionary(value));
        }

        private static object SetDictionaryValue(IDictionary dictionary)
        {
            var cborMap = CBORObject.NewMap();

            foreach (var key in dictionary.Keys)
            {
                cborMap.Add(SetValue(key), SetValue(dictionary[key]));
            }

            return cborMap;
        }

        private static object SetCollectionValue(IEnumerable enumerable)
        {
            var cborArray = CBORObject.NewArray();

            foreach (var item in enumerable)
            {

                cborArray.Add(SetValue(item));
            }


            return cborArray;
        }

        private static object GetValue(Type type, CBORObject cbor)
        {
            if (cbor.IsNull)
                return null;

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

            if (type == typeof(byte[]))
                return cbor.GetByteString();

            if (type == typeof(DateTime))
                return new DateTime(cbor.AsInt64());

            if (type == typeof(TimeSpan))
                return new TimeSpan(cbor.AsInt64());

            if (type == typeof(DateTimeOffset))
                return Helpers.DateTimeOffsetFromBytes(cbor.GetByteString());

            if (type == typeof(Guid))
                return new Guid(cbor.GetByteString());

            if (type.IsArray )
                return GetArrayValue(type.GetElementType(), cbor);

            if (type.GenericTypeArguments.Length > 0 && type.Name.StartsWith("IEnumerable"))
                return GetArrayValue(type.GenericTypeArguments[0], cbor);

            if (type.Name.StartsWith("List"))
                return GetListValue(type.GenericTypeArguments[0], cbor);

            if (type.Name.StartsWith("Dictionary"))
                return GetDictionaryValue(type, cbor);

            if (!type.Namespace.StartsWith("System"))
                return GetObjectValue(type, cbor);

            return null;
        }

        private static object GetObjectValue(Type type, CBORObject cbor)
        {
            object instance = Activator.CreateInstance(type);

            var props = type.GetRuntimeProperties();

            foreach (var prop in props)
            {
                if (cbor.ContainsKey(prop.Name))
                {
                    prop.SetValue(instance, GetValue(prop.PropertyType, cbor[prop.Name]));
                }
            }

            return instance;
        }

        private static object GetDictionaryValue(Type type, CBORObject cbor)
        {
            var dictType = typeof(Dictionary<,>).MakeGenericType(type.GenericTypeArguments);
            var dictionray = Activator.CreateInstance(dictType) as IDictionary;

            var keyType = type.GenericTypeArguments[0];
            var valType = type.GenericTypeArguments[1];

            foreach (var key in cbor.Keys)
            {
                dictionray.Add(GetValue(keyType, key), GetValue(valType, cbor[key]));
            }

            return dictionray;
        }

        private static object GetListValue(Type elementType, CBORObject cbor)
        {
            var genericListType = typeof(List<>).MakeGenericType(new[] { elementType });
            return Activator.CreateInstance(genericListType, GetArrayValue(elementType, cbor));
        }

        private static object GetArrayValue(Type elementType, CBORObject cbor)
        {
            var value = Array.CreateInstance(elementType, cbor.Values.Count);

            int index = 0;
            foreach (var item in cbor.Values)
            {
                value.SetValue(GetValue(elementType, item), index);
                index++;
            }

            return value;
        }

        private static IEnumerable<PropertyInfo> GetProperties<T>() => typeof(T).GetRuntimeProperties();
    }
}
