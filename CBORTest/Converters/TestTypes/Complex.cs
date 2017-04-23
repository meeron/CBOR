using System;
using System.Collections;
using System.Collections.Generic;

namespace CBORTest.Converters.TestTypes
{
    public class Complex
    {
        public int[] ArrayOfInt { get; set; }

        public IEnumerable<string> EnumerableOfString { get; set; }

        public List<DateTime> ListOfDateTime { get; set; }

        public Dictionary<int, string> DictionaryOfIntAndString { get; set; }
    }
}
