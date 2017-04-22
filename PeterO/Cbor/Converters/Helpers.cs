using System;
using System.Collections.Generic;

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
    }
}
