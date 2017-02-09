using AthleticMarks.Data.Entities.Domain;
using AthleticMarks.Data.Entities.Enums;
using AthleticMarks.Data.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Testing.Persistence
{
    [TestClass]
    public class DbContextTests
    {
        private RankingContext unit;

        [TestInitialize]
        public void Initialize()
        {
            unit = new RankingContext();
        }

        [TestCleanup]
        public void Cleanup()
        {
            unit.Dispose();
        }

        [TestMethod]
        public void AddNewAthlete()
        {
            var athleteFirst = CreateAthlete();

            Assert.AreNotEqual(0, athleteFirst.Id);
            Assert.AreEqual("Raul", athleteFirst.Name);
            Assert.AreEqual(1990, athleteFirst.BirthYear);
            Assert.AreEqual(Genre.Male, athleteFirst.Genre);
        }

        private Athlete CreateAthlete()
        {
            var athlete = new Athlete
            {
                Name = "Raul",
                BirthYear = 1990,
                Genre = Genre.Male
            };

            unit.Athletes.Add(athlete);
            unit.SaveChanges();

            return unit.Athletes.First();
        }

        private Athlete CreateAthlete2()
        {
            var athlete = new Athlete
            {
                Name = "Adria",
                BirthYear = 1990,
                Genre = Genre.Male
            };

            unit.Athletes.Add(athlete);
            unit.SaveChanges();

            return unit.Athletes.ToList()[1];
        }

        [TestMethod]
        public void AddNewTrial()
        {
            Trial trialFirst = CreateTrial();

            Assert.AreNotEqual(0, trialFirst.Id);
            Assert.AreEqual(Measurement.Distance, trialFirst.Measurement);
            Assert.AreEqual("100 mts", trialFirst.Name);
            Assert.AreEqual(1, trialFirst.QuantityAthletes);
        }

        private Trial CreateTrial()
        {
            var trial = new Trial
            {
                Measurement = Measurement.Distance,
                Name = "100 mts",
                QuantityAthletes = 1
            };

            unit.Trials.Add(trial);
            unit.SaveChanges();

            var trialFirst = unit.Trials.First();
            return trialFirst;
        }

        [TestMethod]
        public void AddNewMark()
        {
            // Create Athletes
            var athlete = CreateAthlete();
            var athlete2 = CreateAthlete2();
            var trial = CreateTrial();

            var mark = new Mark
            {
                Comments = "It's a new record !!",
                Date = DateTime.Today,
                Receipt = "NY Times Today pg 3",
                Town = "City of Angels",
                Track = Track.Indoor,
                Trial = trial,
                Value = 1.22m
            };
            mark.Athletes = new List<Athlete> { athlete, athlete2 };

            unit.Marks.Add(mark);
            unit.SaveChanges();

            var markFirst = unit.Marks.First();

            Assert.AreNotEqual(0, markFirst.Id);
            Assert.AreEqual(markFirst.Athletes.Count, 2);
            Assert.AreEqual(markFirst.Athletes.First().Id, athlete.Id);
            Assert.AreEqual(athlete2.Id, markFirst.Athletes.ToList()[1].Id);

            Assert.AreEqual(markFirst.Comments, "It's a new record !!");
            Assert.AreEqual(markFirst.Date, DateTime.Today);
            Assert.AreEqual(markFirst.Receipt, "NY Times Today pg 3");
            Assert.AreEqual(markFirst.Town, "City of Angels");
            Assert.AreEqual(markFirst.Track, Track.Indoor);
            Assert.AreEqual(markFirst.Trial.Id, trial.Id);
            Assert.AreEqual(markFirst.Value, 1.22m);
        }
    }
}