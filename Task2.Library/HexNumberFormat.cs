using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Task2.Library
{
    public class HexNumberFormat : IFormatProvider, ICustomFormatter
    {
        private static readonly Dictionary<int, char> Conversions =
            Enumerable.Range(0, 0xf + 1).ToDictionary(x => x, x => x.ToString("X")[0]);

        public object GetFormat(Type formatType)
        {
            return formatType == typeof(ICustomFormatter) ? this : null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            string upperFormat = format.ToUpper(CultureInfo.InvariantCulture); 
            if (arg.GetType() != typeof(int) || upperFormat != "HEX")
                try
                {
                    return HandleOtherFormats(format, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException(String.Format("The format of '{0}' is invalid.", format), e);
                }
            var number = (int) arg;
            var result = new StringBuilder();
            for (var tmp = Math.Abs(number); tmp != 0; tmp >>= 4)
            {
                result.Insert(0, Conversions[tmp & 0xF]); //& 0xF - take last 4 bytes of the number
            }
            result.Insert(0, "0x");
            result.Insert(0, (number < 0) ? "-" : ""); // insert sign of the number
            return result.ToString();
        }

        private static string HandleOtherFormats(string format, object arg)
        {
            var formattable = arg as IFormattable;
            if (formattable != null)
                return formattable.ToString(format, CultureInfo.CurrentCulture);
            return arg != null ? arg.ToString() : String.Empty;
        }
    }
}
