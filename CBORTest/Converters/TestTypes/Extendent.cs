using System;

namespace CBORTest.Converters.TestTypes
{
    public class Extendent
    {
        public DateTime DateTime { get; set; }

        public TimeSpan TimeSpan { get; set; }

        public DateTimeOffset DateTimeOffset { get; set; }

        public Guid Guid { get; set; }

        public EValues CustomEnum { get; set; }
    }

    public enum EValues
    {
        Id = 10,
        Name,
        Age
    }
}
