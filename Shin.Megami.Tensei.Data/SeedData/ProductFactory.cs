using Shin.Megami.Tensei.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shin.Megami.Tensei.Data.SeedData
{
    /// <summary>
    /// This class provides tools for generating random ptients.
    /// </summary>
    public class ProductFactory
    {
        Random _rand = new();

        private readonly List<string> _categories = new()
        {
            "Organic",
        };

        private readonly List<string> _materials = new()
        {
            "Coconut Oil",
            "Avacado Oil"
        };


        private readonly List<string> _types = new()
        {
            "Soap Bar",
            "Body Butter",
            "Lip Balm",
            "Laundry Detergent",
            "Dish Detergent",
            "Hand Soap",
        };

        private readonly List<string> _skuMods = new()
        {
            "ORG"
        };

        /// <summary>
        /// Generates a randomized product SKU.
        /// </summary>
        /// <returns>A SKU string.</returns>
        private string GetRandomSku()
        {
            var builder = new StringBuilder();
            builder.Append(RandomString(3));
            builder.Append('-');
            builder.Append(RandomString(3));
            builder.Append('-');
            builder.Append(_skuMods[_rand.Next(_skuMods.Count)]);

            return builder.ToString().ToUpper();
        }


        /// <summary>
        /// Returns a random material from the list of materials.
        /// </summary>
        /// <returns>A material string.</returns>
        private string GetMaterial()
        {
            return _materials[_rand.Next(0, _materials.Count)];
        }

        /// <summary>
        /// Generates a random price between 9.99 and 500.00.
        /// </summary>
        /// <returns>A decimal with two decimal places representing the price.</returns>
        private decimal GetPrice()
        {
            var result = new decimal((_rand.Next(999, 50000)));
            return Math.Round((result) / 100, 2);
        }

        /// <summary>
        /// Generates a random quantity between 0 and 9.
        /// </summary>
        /// <returns>A 32 bit integer representing the quantity.</returns>
        private Int32 GetQuantity()
        {
            var result = _rand.Next(1, 13);
            return result;
        }

        /// <summary>
        /// Returns a random type from the list of types.
        /// </summary>
        /// <returns>A type string.</returns>
        private string GetRandomType()
        {
            return _types[_rand.Next(0, _types.Count)];
        }

        /// <summary>
        /// Generates a random product offering id.
        /// </summary>
        /// <returns>A product offering string.</returns>
        private string GetRandomProductId()
        {
            return "po-" + RandomString(7);
        }

        /// <summary>
        /// Generates a random Boolean.
        /// </summary>
        /// <returns>A Boolean.</returns>
        private Boolean GetRandomBool(int id)
        {
            if (id <= 4) return true;
            return _rand.Next(2) == 1;
        }

        /// <summary>
        /// Returns a random category from the list of categories.
        /// </summary>
        /// <returns>A category string.</returns>
        private string GetRandomCategory()
        {
            return _categories[_rand.Next(_categories.Count)];
        }

        /// <summary>
        /// Generates a random date between two dates.
        /// </summary>
        /// <returns>A random DateTime.</returns>
        private DateTime GetRandomDate(DateTime startDate, DateTime endDate)
        {
            /// Potentially slow when called multiple times. Should maybe only create startDate and endDate vars once for entire product seed data.
            int range = (endDate - startDate).Days;
            return startDate.AddDays(_rand.Next(range));
        }

        /// <summary>
        /// Generates a number of random products based on input.
        /// </summary>
        /// <param name="numberOfProducts">The number of random products to generate.</param>
        /// <returns>A list of random products.</returns>
        public List<Product> GenerateRandomProducts(int numberOfProducts)
        {
            var productList = new List<Product>();

            for (var i = 0; i < numberOfProducts; i++)
            {
                productList.Add(CreateRandomProduct(i + 1));
            }
            return productList;
        }

        /// <summary>
        /// Uses random generators to build a products.
        /// </summary>
        /// <param name="id">ID to assign to the product.</param>
        /// <returns>A randomly generated product.</returns>
        private Product CreateRandomProduct(int id)
        {
            // Create adjective, category, type, and demographic variables
            // Used to maintain consistency across fields including Name and Description.
            String randCategory = GetRandomCategory();
            String randType = GetRandomType();

            return new Product
            {
                Id = id,
                Name = randCategory + " " + randType,
                Description = randCategory + " " + randType,
                Category = randCategory,
                Type = randType,
                Sku = GetRandomSku(),
                Price = GetPrice(),
                Quantity = GetQuantity(),
                Material = GetMaterial(),
                GlobalProductCode = GetRandomProductId(),
                ReleaseDate = GetRandomDate(new DateTime(2015, 1, 1), DateTime.Today),
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                Active = GetRandomBool(id),
            };
        }

        /// <summary>
        /// Generates a random string of characters.
        /// </summary>
        /// <param name="size">Number of characters in the string.</param>
        /// <param name="lowerCase">Boolean if the character string should be lowercase only; defaults to false.</param>
        /// <returns>A random string of characters.</returns>
        private string RandomString(int size, bool lowerCase = false)
        {

            // ** Learning moment **
            // Code From
            // https://www.c-sharpcorner.com/article/generating-random-number-and-string-in-C-Sharp/

            // ** Learning moment **
            // Always use a string builder when concatenating more than a couple of strings.
            // Why? https://www.geeksforgeeks.org/c-sharp-string-vs-stringbuilder/
            var builder = new StringBuilder(size);

            // Unicode/ASCII Letters are divided into two blocks
            // (Letters 65–90 / 97–122):
            // The first group containing the uppercase letters and
            // the second group containing the lowercase.  

            // char is a single Unicode character  
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length=26  

            for (var i = 0; i < size; i++)
            {
                // ** Learning moment **
                // Because 'char' is a reserved word you can put '@' at the beginning to allow
                // its use as a variable name.  You could do the same thing with 'class'
                var @char = (char)_rand.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }
    }

}
