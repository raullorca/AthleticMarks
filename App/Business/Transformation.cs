using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthleticMarks.App.Business
{
    public static class Transformation
    {
        public static DateTime ToDate(string value)
        {
            Validate(value);

            int year = 1;
            int month = 1;
            int day = 1;
            int hour = 0;
            int minute = 0;
            int second = 0;
            int millisecond = 0;

            string item = "";

            foreach (var character in value)
            {
                if (character == ' ')
                    continue;

                if (char.IsDigit(character))
                {
                    item += character;
                    continue;
                }

                if (IsSecond(character))
                {
                    second = Parse(item);
                    item = "";
                    continue;
                }

                if (IsMinute(character))
                {
                    minute = Parse(item);
                    item = "";
                    continue;
                }

                if (IsHour(character))
                {
                    hour = Parse(item);
                    item = "";
                    continue;
                }

                throw new Exception("formato incorrecto");
            }

            millisecond = Parse(item);

            return new DateTime(year, month, day, hour, minute, second, millisecond);
        }

        public static string ToString(DateTime value)
        {
            int hour = value.Hour;
            int minute = value.Minute;
            int second = value.Second;
            int milisecond = value.Millisecond;

            var partial = new StringBuilder();

            if (hour > 0)
                partial.Append($"{hour}h ");
            if (minute > 0)
                partial.Append($"{minute}' ");
            if (second > 0)
                partial.Append($"{second}\" ");
            if (milisecond > 0)
                partial.Append($"{milisecond} ");

            var result = partial.ToString().Trim();

            if (string.IsNullOrEmpty(result))
                throw new Exception("Tiempo no definido");

            return result;
        }

        private static int Parse(string value)
        {
            int result;
            int.TryParse(value, out result);
            return result;
        }

        private static bool IsHour(char value)
        {
            return 'h'.Equals(value);
        }

        private static bool IsMinute(char value)
        {
            return '\''.Equals(value);
        }

        private static bool IsSecond(char value)
        {
            return '"'.Equals(value);
        }

        private static void Validate(string item)
        {
            if (Defined('h', item) > 1 ||
                Defined('\'', item) > 1 ||
                Defined('"', item) > 1)
                throw new Exception("formato incorrecto");
        }

        private static int Defined(char searchChar, string cadena)
        {
            var defined = 0;

            var query = from item in cadena.ToArray()
                        group item by item into g
                        select new KeyValuePair<char, int>(g.Key, g.Count());

            var dictionary = query.ToDictionary(item => item.Key, item => item.Value);

            if (dictionary.ContainsKey(searchChar))
                defined = dictionary[searchChar];

            return defined;
        }
    }
}