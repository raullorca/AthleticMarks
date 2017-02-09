using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace AthleticMarks.App.Commons.Extensions
{
    public static class ComboBoxExtensions
    {
        public static void Populate<T>(this ComboBox cbo) where T : struct, IConvertible
        {
            cbo.DataSource = Enum.GetValues(typeof(T))
                    .Cast<Enum>()
                    .Select(value => new
                    {
                        (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()),
                        typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                        value
                    })
                    .OrderBy(item => item.value)
                    .ToList();
            cbo.DisplayMember = "Description";
            cbo.ValueMember = "value";
        }
    }
}