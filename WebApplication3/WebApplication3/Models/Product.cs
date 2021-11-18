using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication3.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductImages = new HashSet<ProductImage>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string ShippingMethod { get; set; }
        public decimal ShippingPrice { get; set; }
        public DateTime? SellEndDate { get; set; }
        public string PosterId { get; set; }

        public virtual AspNetUser Poster { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
    }
}
