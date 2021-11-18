using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApplication3.Models
{
    [Table("Product")]
    public partial class Product
    {
        public Product()
        {
            ProductImages = new HashSet<ProductImage>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(4000)]
        public string Description { get; set; }
        [Column("COLOR")]
        [StringLength(30)]
        public string Color { get; set; }
        [Column("PRICE", TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        [Column("CATEGORY")]
        [StringLength(30)]
        public string Category { get; set; }
        [Column("BRAND")]
        [StringLength(50)]
        public string Brand { get; set; }
        [Required]
        [Column("SHIPPING METHOD")]
        [StringLength(50)]
        public string ShippingMethod { get; set; }
        [Column("SHIPPING PRICE", TypeName = "decimal(18, 2)")]
        public decimal ShippingPrice { get; set; }
        [Column("SELL END DATE", TypeName = "smalldatetime")]
        public DateTime? SellEndDate { get; set; }
        [Required]
        [StringLength(256)]
        public string PosterName { get; set; }

        [InverseProperty(nameof(ProductImage.Product))]
        public virtual ICollection<ProductImage> ProductImages { get; set; }
    }
}
