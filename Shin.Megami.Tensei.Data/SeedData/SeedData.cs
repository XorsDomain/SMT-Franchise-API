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
            /// Start FOOL Arcana
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

            var persona5RFourteen = new Persona5Royal()
            {
                Id = 14,
                Name = "Bugbear",
                Arcana = "Fool",
                Affinity = "Psychic",
                StrongestSkill = "Psiodyne",
                Level = 65,
                Origin = "Celtic"
            };

            var persona5RFifteen = new Persona5Royal()
            {
                Id = 15,
                Name = "Crystal Skull",
                Arcana = "Fool",
                StrongestSkill = "All -dyne skills",
                Level = 50,
                Origin = "Pre-Columbian Mesoamerica"
            };

            var persona5RSixteen = new Persona5Royal()
            {
                Id = 16,
                Name = "Dionysus",
                Arcana = "Fool",
                Affinity = "Elec",
                StrongestSkill = "Maragidyne",
                Level = 61,
                Origin = "Greek"
            };

            var persona5RSeventeen = new Persona5Royal()
            {
                Id = 17,
                Name = "Black Frost",
                Arcana = "Fool",
                Affinity = "Ice",
                StrongestSkill = "Diamond Dust",
                Level = 67,
                Origin = "English"
            };

            var persona5REighteen = new Persona5Royal()
            {
                Id = 18,
                Name = "Vishnu",
                Arcana = "Fool",
                Affinity = "Almighty",
                StrongestSkill = "Megidolaon",
                Level = 83,
                Origin = "Hindu"
            };

            /// Start MAGICIAN Arcana

            var persona5RNineteen = new Persona5Royal()
            {
                Id = 19,
                Name = "Zorro",
                Arcana = "Magician",
                Affinity = "Wind",
                StrongestSkill = "Magarudyne",
                Level = 1,
                Origin = "Spanish"
            };

            var persona5RTwenty = new Persona5Royal()
            {
                Id = 20,
                Name = "Mercurius",
                Arcana = "Magician",
                Affinity = "Wind",
                StrongestSkill = "Magarudyne",
                Level = 1,
                Origin = "Roman"
            };

            var persona5RTwentyOne = new Persona5Royal()
            {
                Id = 21,
                Name = "Diego",
                Arcana = "Magician",
                Affinity = "Wind",
                StrongestSkill = "Magarudyne",
                Level = 1,
                Origin = "Spanish"
            };

            var persona5RoyalTwentyTwo = new Persona5Royal()
            {
                Id = 22,
                Name = "Jack-O-Lantern",
                Arcana = "Magician",
                Affinity = "Fire",
                StrongestSkill = "Agi",
                Level = 2,
                Origin = "Irish"
            };

            var persona5RoyalTwentyThree = new Persona5Royal()
            {
                Id = 23,
                Name = "Cait Sith(Sidhe)",
                Arcana = "Magician",
                Affinity = "Fire/Phys",
                StrongestSkill = "Agi",
                Level = 2,
                Origin = "Irish and Scottish"
            };

            var persona5RoyalTwentyFour = new Persona5Royal()
            {
                Id = 24,
                Name = "Jack Frost",
                Arcana = "Magician",
                Affinity = "Ice",
                StrongestSkill = "Mabufu",
                Level = 11,
                Origin = "English"
            };

            var persona5RoyalTwentyFive = new Persona5Royal()
            {
                Id = 25,
                Name = "Nekomata",
                Arcana = "Magician",
                Affinity = "Psy/Phys",
                StrongestSkill = "Hysterical Slap",
                Level = 17,
                Origin = "Japanese"
            };

            var persona5RoyalTwentySix = new Persona5Royal()
            {
                Id = 26,
                Name = "Sandman",
                Arcana = "Magician",
                Affinity = "Wind",
                StrongestSkill = "Magarula",
                Level = 23,
                Origin = "North European"
            };

            var persona5RoyalTwentySeven = new Persona5Royal()
            {
                Id = 27,
                Name = "Choronzon",
                Arcana = "Magician",
                Affinity = "Curse",
                StrongestSkill = "Eiga",
                Level = 28,
                Origin = "English"
            };

            var persona5RoyalTwentyEight = new Persona5Royal()
            {
                Id = 28,
                Name = "Queen Mab(Medb, Meive)",
                Arcana = "Magician",
                Affinity = "Fire/Elec",
                StrongestSkill = "Agidyne",
                Level = 43,
                Origin = "Irish"
            };

            var persona5RoyalTwentyNine = new Persona5Royal()
            {
                Id = 29,
                Name = "Rangda",
                Arcana = "Magician",
                Affinity = "Phys/Curse",
                StrongestSkill = "Bloodbath/Eigaon",
                Level = 48,
                Origin = "Balinese"
            };

            var persona5RoyalThirty = new Persona5Royal()
            {
                Id = 30,
                Name = "Surt",
                Arcana = "Magician",
                Affinity = "Fire",
                StrongestSkill = "Inferno",
                Level = 83,
                Origin = "Norse"
            };

            var persona5RoyalThirtyOne = new Persona5Royal()
            {
                Id = 31,
                Name = "Forneus",
                Arcana = "Magician",
                Affinity = "Psy",
                StrongestSkill = "Mapsiodyne",
                Level = 63,
                Origin = "English"
            };

            var persona5RoyalThirtyTwo = new Persona5Royal()
            {
                Id = 32,
                Name = "Futsunushi",
                Arcana = "Magician",
                Affinity = "Physical",
                StrongestSkill = "Brave Blade",
                Level = 86,
                Origin = "Japanese"
            };

            var persona5RoyalThirtyThree = new Persona5Royal()
            {
                Id = 33,
                Name = "Johanna",
                Arcana = "Priestess",
                Affinity = "Nuke",
                StrongestSkill = "Atomic Flare",
                Level = 21,
                Origin = "Europe"
            };

            var persona5RoyalThirtyFour = new Persona5Royal()
            {
                Id = 34,
                Name = "Anat",
                Arcana = "Priestess",
                Affinity = "Nuke",
                StrongestSkill = "Atomic Flare",
                Level = 21,
                Origin = "Syrian"
            };

            var persona5RoyalThirtyFive = new Persona5Royal()
            {
                Id = 35,
                Name = "Agnes",
                Arcana = "Priestess",
                Affinity = "Nuke",
                StrongestSkill = "Atomic Flare",
                Level = 21,
                Origin = "European"
            };

            var persona5RoyalThirtySix = new Persona5Royal()
            {
                Id = 36,
                Name = "Silky",
                Arcana = "Priestess",
                Affinity = "Ice",
                StrongestSkill = "Bufu",
                Level = 6,
                Origin = "Scottish"
            };

            var persona5RoyalThirtySeven = new Persona5Royal()
            {
                Id = 37,
                Name = "Apsaras",
                Arcana = "Priestess",
                Affinity = "Ice",
                StrongestSkill = "Bufu",
                Level = 11,
                Origin = "Hindu"
            };

            var persona5RoyalThirtyEight = new Persona5Royal()
            {
                Id = 38,
                Name = "Koh-i-Noor",
                Arcana = "Priestess",
                Affinity = "Almighty",
                StrongestSkill = "All 'Dodge' Skills",
                Level = 25,
                Origin = "British"
            };

            var persona5RoyalThirtyNine = new Persona5Royal()
            {
                Id = 39,
                Name = "Isis",
                Arcana = "Priestess",
                Affinity = "Bless/Curse",
                StrongestSkill = "Zionga/Garula/Agilao",
                Level = 26,
                Origin = "Egyptian"
            };

            var persona5RoyalFourty = new Persona5Royal()
            {
                Id = 40,
                Name = "Kikuri-Hime",
                Arcana = "Priestess",
                Affinity = "Bless/Wind",
                StrongestSkill = "Mediarama",
                Level = 40,
                Origin = "Japanese"
            };

            var persona5RoyalFourtyOne = new Persona5Royal()
            {
                Id = 41,
                Name = "Sarasvati",
                Arcana = "Priestess",
                Affinity = "Ice/Elec",
                StrongestSkill = "Diarahan",
                Level = 50,
                Origin = "Hindu"
            };

            var persona5RoyalFourtyTwo = new Persona5Royal()
            {
                Id = 42,
                Name = "Skadi",
                Arcana = "Priestess",
                Affinity = "Ice/Curse",
                StrongestSkill = "Bufudyne",
                Level = 53,
                Origin = "Norse"
            };

            var persona5RoyalFourtyThree = new Persona5Royal()
            {
                Id = 43,
                Name = "Cybele",
                Arcana = "Priestess",
                Affinity = "Fire/Bless",
                StrongestSkill = "Makougaon/Salvation",
                Level = 83,
                Origin = "Greek"
            };

            var persona5RoyalFourtyFour = new Persona5Royal()
            {
                Id = 44,
                Name = "Scathach",
                Arcana = "Priestess",
                Affinity = "Wind/Fire/Phys",
                StrongestSkill = "Magarula/Maragion",
                Level = 77,
                Origin = "Scottish"
            };
    }
}
