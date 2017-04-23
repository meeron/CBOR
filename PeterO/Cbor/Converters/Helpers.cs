using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace PeterO.Cbor.Converters
{
    internal static class Helpers
    {
        public static byte[] DateTimeOffsetToBytes(DateTimeOffset value)
        {
            List<byte> result = new List<byte>();
            result.AddRange(BitConverter.GetBytes(value.Ticks));
            result.AddRange(BitConverter.GetBytes(value.Offset.Hours));

            return result.ToArray();
        }

        public static DateTimeOffset DateTimeOffsetFromBytes(byte[] data)
        {
            long ticks = BitConverter.ToInt64(data, 0);
            int offset = BitConverter.ToInt32(data, sizeof(long));

            return new DateTimeOffset(ticks, TimeSpan.FromHours(offset));
        }

        public static IDictionary ObjectToDictionary(object obj)
        {
            Dictionary<string, object> objMap = new Dictionary<string, object>();

            var props = obj.GetType().GetRuntimeProperties();

            foreach (var prop in props)
            {
                objMap.Add(prop.Name, prop.GetValue(obj));
            }

            return objMap;
        }
    }
}
