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
                Weakness = "Ice, Bless",
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
                Weakness = "None",
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
                Weakness = "Bless",
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
                Weakness = "Elec",
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
                Weakness = "Elec",
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
                Weakness = "Elec, Curse",
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
                Weakness = "Gun, Nuke",
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
                Weakness = "Wind",
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
                Weakness = "Wind",
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
                Weakness = "Elec, Curse",
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
                Weakness = "Elec, Curse",
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
                Weakness = "Bless",
                Level = 38,
                Origin = "English"
            };

            var persona5RThirteen = new Persona5Royal()
            {
                Id = 13,
                Name = "Ose",
                Arcana = "Fool",
                StrongestSkill = "Heat Wave",
                Weakness = "Bless",
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
                Weakness = "Nuke, Fire",
                Level = 65,
                Origin = "Celtic"
            };

            var persona5RFifteen = new Persona5Royal()
            {
                Id = 15,
                Name = "Crystal Skull",
                Arcana = "Fool",
                StrongestSkill = "All -dyne skills",
                Weakness = "Wind",
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
                Weakness = "None",
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
                Weakness = "None",
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
                Weakness = "Fire",
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
                Weakness = "Elec",
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
                Weakness = "Elec",
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
                Weakness = "Elec",
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
                Weakness = "Ice, Wind",
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
                Weakness = "Wind",
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
                Weakness = "Fire",
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
                Weakness = "Elec",
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
                Weakness = "Fire, Elec",
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
                Weakness = "Bless",
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
                Weakness = "Wind",
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
                Weakness = "Elec, Bless",
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
                Weakness = "Ice",
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
                Weakness = "Elec",
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
                Weakness = "Nuke",
                Level = 86,
                Origin = "Japanese"
            };

            ///Start the PRIESTESS Arcana

            var persona5RoyalThirtyThree = new Persona5Royal()
            {
                Id = 33,
                Name = "Johanna",
                Arcana = "Priestess",
                Affinity = "Nuke",
                StrongestSkill = "Atomic Flare",
                Weakness = "Psy",
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
                Weakness = "Psy",
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
                Weakness = "Psy",
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
                Weakness = "Fire, Elec",
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
                Weakness = "Fire, Elec",
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
                Weakness = "Gun",
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
                Weakness = "Psy",
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
                Weakness = "Fire",
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
                Weakness = "Nuke",
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
                Weakness = "Fire",
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
                Weakness = "Elec",
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
                Weakness = "None",
                Level = 77,
                Origin = "Scottish"
            };

            ///Star the EMPRESS Arcana

            var persona5RoyalFourtyFive = new Persona5Royal()
            {
                Id = 45,
                Name = "Milady",
                Arcana = "Empress",
                Affinity = "Psy",
                StrongestSkill = "Mapsiodyne/Triple Down",
                Weakness = "Nuke",
                Level = 36,
                Origin = "French"
            };

            var persona5RoyalFourtySix = new Persona5Royal()
            {
                Id = 46,
                Name = "Astarte",
                Arcana = "Empress",
                Affinity = "Psy",
                StrongestSkill = "Mapsiodyne/Triple Down",
                Weakness = "Nuke",
                Level = 36,
                Origin = "Greek"
            };

            var persona5RoyalFourtySeven = new Persona5Royal()
            {
                Id = 47,
                Name = "Lucy",
                Arcana = "Empress",
                Affinity = "Psy",
                StrongestSkill = "Mapsiodyne/One-Shot Kill",
                Weakness = "Nuke",
                Level = 36,
                Origin = "Greek"
            };

            var persona5RoyalFourtyEight = new Persona5Royal()
            {
                Id = 48,
                Name = "Queen's Necklace",
                Arcana = "Empress",
                Affinity = "Almighty",
                StrongestSkill = "-Kaja/-nda Supports, Recarm, Media",
                Weakness = "Gun, Psy",
                Level = 15,
                Origin = "French"
            };

            var persona5RoyalFourtyNine = new Persona5Royal()
            {
                Id = 49,
                Name = "Yaksini",
                Arcana = "Empress",
                Affinity = "Ice",
                StrongestSkill = "Oni-Kagura",
                Weakness = "Nuke",
                Level = 20,
                Origin = "Hindu"
            };

            var persona5RoyalFifty = new Persona5Royal()
            {
                Id = 50,
                Name = "Lamia",
                Arcana = "Empress",
                Affinity = "Curse/Elec/Gun",
                StrongestSkill = "Maragion/Rising Slash",
                Weakness = "Ice, Nuke",
                Level = 26,
                Origin = "Greek"
            };

            var persona5RoyalFiftyOne = new Persona5Royal()
            {
                Id = 51,
                Name = "Hariti",
                Arcana = "Empress",
                Affinity = "Psy/Bless",
                StrongestSkill = "Nocturnal Flash/Mediarama/Samarecarm",
                Weakness = "Wind",
                Level = 40,
                Origin = "Buddhism"
            };

            var persona5RoyalFiftyTwo = new Persona5Royal()
            {
                Id = 52,
                Name = "Dakini",
                Arcana = "Empress",
                Affinity = "Fire",
                StrongestSkill = "Charge/Rising Slash",
                Weakness = "None",
                Level = 40,
                Origin = "Hindu"
            };

            var persona5RoyalFiftyThree = new Persona5Royal()
            {
                Id = 53,
                Name = "Titania",
                Arcana = "Empress",
                Affinity = "Nuke/Bless/Curse",
                StrongestSkill = "Mafreidyne/Mediarahan",
                Weakness = "Psy",
                Level = 56,
                Origin = "English"
            };

            var persona5RoyalFiftyFour = new Persona5Royal()
            {
                Id = 54,
                Name = "Kali",
                Arcana = "Empress",
                Affinity = "Fire",
                StrongestSkill = "Psiodyne/Vorpal Blade",
                Weakness = "None",
                Level = 77,
                Origin = "Hindu"
            };

            var persona5RoyalFiftyFive = new Persona5Royal()
            {
                Id = 55,
                Name = "Mother Harlot",
                Arcana = "Empress",
                Affinity = "Elec/Curse/Ice",
                StrongestSkill = "Mabufudyne/Mamudoon",
                Weakness = "Bless",
                Level = 85,
                Origin = "Roman"
            };

            var persona5RoyalFiftySix = new Persona5Royal()
            {
                Id = 56,
                Name = "Alilat",
                Arcana = "Empress",
                Affinity = "Ice",
                StrongestSkill = "Diamond Dust",
                Weakness = "Fire, Curse",
                Level = 81,
                Origin = "Arabian"
            };
        }
    }
}
