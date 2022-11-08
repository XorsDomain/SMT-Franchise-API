using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Shin.Megami.Tensei.Data.Model
{
    /// <summary>
    /// This class is a representation of a Product.
    /// </summary>
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public string Sku { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public string Type { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string GlobalProductCode { get; set; }

        public string Material { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }


        public bool Active { get; set; }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
        public static IEqualityComparer<Product> ProductComparer { get; } = new ProductEqualityComparer();

        private sealed class ProductEqualityComparer : IEqualityComparer<Product>
        {
            public bool Equals(Product x, Product y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Name == y.Name
                    && x.Description == y.Description
                    && x.Price == y.Price
                    && x.Material == y.Material
                    && x.Category == y.Category
                    && x.Type == y.Type
                    && x.ReleaseDate.Equals(y.ReleaseDate)
                    && x.GlobalProductCode == y.GlobalProductCode
                    && x.Active == y.Active;
            }

            public int GetHashCode(Product obj)
            {
                var hashCode = new HashCode();
                hashCode.Add(obj.Name);
                hashCode.Add(obj.Description);
                hashCode.Add(obj.Category);
                hashCode.Add(obj.Type);
                hashCode.Add(obj.ReleaseDate);
                hashCode.Add(obj.GlobalProductCode);
                hashCode.Add(obj.Active);

                return hashCode.ToHashCode();
            }
        }
    }

}
