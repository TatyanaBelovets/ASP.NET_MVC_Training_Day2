using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2.Library;

namespace Task2.Tests
{
    [TestClass]
    public class TestsForHexNumberFormat
    {
        [TestMethod]
        public void ValuesAreEqual()
        {
            var data = new Dictionary<int, string>()
            {
                {0xC0FFEE, "0xC0FFEE"},
                {0xBEEF, "0xBEEF"},
                {-0xDEADDAD, "-0xDEADDAD"},
                {0xFA11, "0xFA11"},
                {-0xFACE, "-0xFACE"},
                {-0xC0DE, "-0xC0DE"}
            };
            foreach (var entry in data)
            {

                var result = String.Format(new HexNumberFormat(), "{0:HEX}", entry.Key);
                Assert.AreEqual(entry.Value, result);
            }
        }
    }
}
