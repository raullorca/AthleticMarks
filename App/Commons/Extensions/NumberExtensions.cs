using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthleticMarks.App.Commons.Extensions
{
    public static class NumberExtensions
    {
        public static bool Between(this int value, int first, int second)
        {
            return value >= first && value <= second;
        }
    }
}