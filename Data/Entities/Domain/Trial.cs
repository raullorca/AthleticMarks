using AthleticMarks.Data.Entities.Enums;
using System.Collections.Generic;

namespace AthleticMarks.Data.Entities.Domain
{
    public class Trial
    {
        public int Id { get; set; }

        public virtual ICollection<Mark> Marks { get; set; }

        public Measurement Measurement { get; set; }

        public string Name { get; set; }

        public int QuantityAthletes { get; set; }
    }
}