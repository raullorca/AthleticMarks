using AthleticMarks.Data.Entities.Domain;
using AthleticMarks.Data.Entities.Enums;
using AthleticMarks.Data.Persistence.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AthleticMarks.Data.Persistence
{
    public class RankingContext : DbContext
    {
        public RankingContext() : base("Ranking.DbConnection")
        {
            Database.SetInitializer(new RankingInitializer());
        }

        public DbSet<Athlete> Athletes { get; set; }
        public DbSet<Trial> Trials { get; set; }
        public DbSet<Mark> Marks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MarkConfiguration());
        }
    }

    public class RankingInitializer : DropCreateDatabaseAlways<RankingContext>
    {
        protected override void Seed(RankingContext context)
        {
            var ath1 = SetAthlete("Ath 1", Genre.Male, 1950);
            var ath2 = SetAthlete("Ath 2", Genre.Male, 1951);
            var ath3 = SetAthlete("Ath 3", Genre.Male, 1952);

            var athletes = new List<Athlete>
                {
                ath1,                ath2,                ath3,
                    SetAthlete("Ath 4", Genre.Male, 1953),
                    SetAthlete("Ath 11", Genre.Female, 1960),
                    SetAthlete("Ath 12", Genre.Female, 1961),
                    SetAthlete("Ath 13", Genre.Female, 1962),
                    SetAthlete("Ath 14", Genre.Female, 1963)
                };

            athletes.ForEach(x => context.Athletes.Add(x));

            var tri1 = SetTrial(Measurement.Distance, "Distance 1", 1);

            var trials = new List<Trial>
                {
                tri1,
                    SetTrial(Measurement.Distance, "Distance 3", 3),
                    SetTrial(Measurement.Distance, "Distance 4", 4),
                    SetTrial(Measurement.Points, "Points 1", 1),
                    SetTrial(Measurement.Points, "Points 3", 3),
                    SetTrial(Measurement.Points, "Points 4", 4),
                    SetTrial(Measurement.Time, "Time 1", 1),
                    SetTrial(Measurement.Time, "Time 3", 3),
                    SetTrial(Measurement.Time, "Time 4", 4)
                };

            trials.ForEach(x => context.Trials.Add(x));

            var mark = SetMark("comments", DateTime.Today,
                "receipt", "town", Track.Indoor, 123);

            mark.Athletes = new List<Athlete>();
            mark.Athletes.Add(ath1);
            mark.Trial = tri1;

            context.Marks.Add(mark);

            context.SaveChanges();
        }

        private Athlete SetAthlete(string name, Genre genre, int birth)
        {
            return new Athlete
            {
                Name = name,
                Genre = genre,
                BirthYear = birth
            };
        }

        private Trial SetTrial(Measurement measurement, string name, int quantityAthletes)
        {
            return new Trial
            {
                Measurement = measurement,
                Name = name,
                QuantityAthletes = quantityAthletes
            };
        }

        private Mark SetMark(
            string comments, DateTime date, string receipt,
            string town, Track track, decimal value)
        {
            return new Mark
            {
                //Athletes = athletes,
                Comments = comments,
                Date = date,
                Receipt = receipt,
                Town = town,
                Track = track,
                // TrialId = trialId,
                Value = value
            };
        }
    }
}