using Shin.Megami.Tensei.Data.Model;
using Shin.Megami.Tensei.Data.SeedData;
using Microsoft.EntityFrameworkCore;
using System;

namespace Shin.Megami.Tensei.Data.Context
{
    public static class Extensions
    {
        /// <summary>
        /// Produces a set of seed data to insert into the database on startup.
        /// </summary>
        /// <param name="modelBuilder">Used to build model base DbContext.</param>
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            var productFactory = new ProductFactory();
            var ProductList = productFactory.GenerateRandomProducts(100);
            modelBuilder.Entity<Product>().HasData(ProductList);

            ///Each compendium will go by order of Arcana.
            ///
            /// This line signifies the start of the Person 5 Royal Compendium.
            var persona5ROne = new Persona5Royal()
            {
                Id = 1,
                Name = "Arsene",
                Arcana = "Fool",
                Affinity = "Curse",
                StrongestSkill = "Eigaon",
                Level = 1,
                Origin = "French"
            };

            var persona5RTwo = new Persona5Royal()
            {
                Id = 2,
                Name = "Satanael",
                Arcana = "Fool",
                Affinity = "Almighty",
                StrongestSkill = "Sinful Shell",
                Level = 95,
                Origin = "Jewish"
            };

            var persona5RThree = new Persona5Royal()
            {
                Id = 3,
                Name = "Raoul",
                Arcana = "Fool",
                Affinity = "Curse",
                StrongestSkill = "Phantom Show",
                Level = 76,
                Origin = "French"
            };

            var persona5RFour = new Persona5Royal()
            {
                Id = 4,
                Name = "Obariyon",
                Arcana = "Fool",
                Affinity = "Physical",
                StrongestSkill = "Lucky Punch",
                Level = 8,
                Origin = "Japanese"
            };

            var persona5RFive = new Persona5Royal()
            {
                Id = 5,
                Name = "Orpheus(F)",
                Arcana = "Fool",
                Affinity = "Fire",
                StrongestSkill = "Neo Cadenza",
                Level = 11,
                Origin = "Greek"
            };

            var persona5RSix = new Persona5Royal()
            {
                Id = 6,
                Name = "Orpheus(F) Picaro",
                Arcana = "Fool",
                Affinity = "Fire",
                StrongestSkill = "Neo Cadenza",
                Level = 13,
                Origin = "Greek"
            };

            var persona5RSeven = new Persona5Royal()
            {
                Id = 7,
                Name = "High Pixie",
                Arcana = "Fool",
                Affinity = "Wind",
                StrongestSkill = "Diarama",
                Level = 16,
                Origin = "Scottish"
            };

            var persona5REight = new Persona5Royal()
            {
                Id = 8,
                Name = "Izanagi",
                Arcana = "Fool",
                Affinity = "Elec",
                StrongestSkill = "Cross Slash",
                Level = 20,
                Origin = "Japanese"
            };

            var persona5RNine = new Persona5Royal()
            {
                Id = 9,
                Name = "Izanagi Picaro",
                Arcana = "Fool",
                Affinity = "Elec",
                StrongestSkill = "Cross Slash",
                Level = 23,
                Origin = "Japanese"
            };

            var persona5RTen = new Persona5Royal()
            {
                Id = 10,
                Name = "Orpheus(M)",
                Arcana = "Fool",
                Affinity = "Fire",
                StrongestSkill = "Cadenza",
                Level = 26,
                Origin = "Greek"
            };

            var persona5REleven = new Persona5Royal()
            {
                Id = 11,
                Name = "Orpheus(M) Picaro",
                Arcana = "Fool",
                Affinity = "Fire",
                StrongestSkill = "Cadenza",
                Level = 29,
                Origin = "Greek"
            };

            var persona5RTwelve = new Persona5Royal()
            {
                Id = 12,
                Name = "Legion",
                Arcana = "Fool",
                Affinity = "Curse",
                StrongestSkill = "Bloodbath",
                Level = 38,
                Origin = "English"
            };

            var persona5RThirteen = new Persona5Royal()
            {
                Id = 13,
                Name = "Ose",
                Arcana = "Fool",
                StrongestSkill = "Heat Wave",
                Level = 42,
                Origin = "English"
            };
        }
    }
}
