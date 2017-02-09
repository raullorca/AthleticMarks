using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthleticMarks.App.Commons
{
    public static class Enums
    {
        public static string GetDescription<T>(T value) where T : struct, IConvertible
        {
            var type = typeof(T);
            var memInfo = type.GetMember(value.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute),
                false);
            return ((DescriptionAttribute)attributes[0]).Description;
        }
    }
}