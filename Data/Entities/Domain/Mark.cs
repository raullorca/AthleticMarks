using AthleticMarks.Data.Entities.Enums;
using System;
using System.Collections.Generic;

namespace AthleticMarks.Data.Entities.Domain
{
    public class Mark
    {
        public virtual ICollection<Athlete> Athletes { get; set; }
        public string Comments { get; set; }
        public DateTime Date { get; set; }
        public int Id { get; set; }
        public string Receipt { get; set; }
        public string Town { get; set; }
        public Track Track { get; set; }
        public virtual Trial Trial { get; set; }
        public int TrialId { get; set; }
        public decimal Value { get; set; }
    }
}