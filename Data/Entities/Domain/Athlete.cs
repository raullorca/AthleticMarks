using AthleticMarks.Data.Entities.Enums;
using System.Collections.Generic;

namespace AthleticMarks.Data.Entities.Domain
{
    public class Athlete
    {
        public int BirthYear { get; set; }
        public Genre Genre { get; set; }
        public int Id { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
        public string Name { get; set; }
    }
}