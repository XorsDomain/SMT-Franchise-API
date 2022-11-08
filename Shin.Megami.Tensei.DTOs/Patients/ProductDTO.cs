using System;
using System.ComponentModel.DataAnnotations;

namespace Shin.Megami.Tensei.DTOs.Products
{
    /// <summary>
    /// Describes a data transfer object for a product.
    /// </summary>
    public class ProductDTO
    {
        public int Id { get; set; }
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


    }
}
