using AthleticMarks.Data.Entities.Domain;
using AthleticMarks.Data.Entities.Enums;
using System;
using System.Linq;

namespace AthleticMarks.App.Business
{
    public interface IMarkService
    {
        string GetNameAthletes(Mark item);

        string GetNameCategory(Mark item);

        string GetSaison(DateTime markDate);

        string GetValueFormatted(Mark mark);

        decimal SetValueFormatted(string text, Measurement measurement);
    }

    public class MarkService : IMarkService
    {
        public string GetNameAthletes(Mark item)
        {
            var athleteNames = string.Empty;
            if (item.Athletes != null && item.Athletes.Count > 0)
            {
                athleteNames = item.Athletes
                                   .Select(x => x.Name)
                                   .Aggregate((current, next) => current + ", " + next);
            }
            return athleteNames;
        }

        public string GetNameCategory(Mark item)
        {
            var age = 0;
            if (item.Athletes != null && item.Athletes.Count > 0)
            {
                var birthYear = item.Athletes.Max(x => x.BirthYear);
                age = item.Date.Year - birthYear;
            }
            return GetCategory(age);
        }

        public string GetSaison(DateTime markDate)
        {
            var year = markDate.Year;
            var initSaison = new DateTime(year, 11, 1);

            if (markDate >= initSaison)
                return $"{year}-{year + 1}";

            return $"{year - 1}-{year}";
        }

        public string GetValueFormatted(Mark mark)
        {
            if (mark.Trial.Measurement == Measurement.Time)
            {
                try
                {
                    var date = new DateTime(Convert.ToInt64(mark.Value));

                    return Transformation.ToString(date);
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }

            return $"{mark.Value}";
        }

        public decimal SetValueFormatted(string text, Measurement measurement)
        {
            decimal valueFormatted;

            switch (measurement)
            {
                case Measurement.Distance:
                case Measurement.Points:
                    valueFormatted = decimal.Parse(text.Replace('.', ','));
                    break;

                case Measurement.Time:
                    var value = Transformation.ToDate(text);
                    valueFormatted = Convert.ToDecimal(value.Ticks);
                    break;

                default:
                    throw new NotSupportedException();
            }
            return valueFormatted;
        }

        private string GetCategory(int age)
        {
            if (age == 0)
                return string.Empty;

            if (age > 34) return "Vetera"; // Veterano  Des del dia que facin 35 anys
            if (age > 22) return "Senior"; // Senior    22-34
            if (age > 19) return "sub-23"; // Promesa       20-21
            if (age > 17) return "sub-20"; // Junior        18-19
            if (age > 15) return "sub-18"; // Juvenil       16-17
            if (age > 13) return "sub-16"; // Cadete        14-15
            if (age > 11) return "sub-14"; // Infantil      12-13
            if (age > 9) return "sub-12"; // Alevin        10-11
            if (age > 7) return "sub-10"; // Benjamin      8-9
            return "7";                    // Prebenjamin < 8
        }
    }
}