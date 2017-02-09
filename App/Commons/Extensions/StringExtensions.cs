using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthleticMarks.App.Commons.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNumeric(this string value)
        {
            double result;
            return double.TryParse(value, out result);
        }

        public static bool IsOnlyDigits(this string value)
        {
            return value.All(char.IsDigit);
        }
    }
}