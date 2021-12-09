using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApplication3.Models
{
    [Table("Product")]
    public partial class Product
    {
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
        [Column("Sale Posted Date", TypeName = "smalldatetime")]
        public DateTime? SellEndDate { get; set; }
        [Required]
        [StringLength(256)]
        public string PosterName { get; set; }
        [StringLength(100)]
        [DisplayName("Image 1")]
        public string Image1 { get; set; }
        [StringLength(100)]
        [DisplayName("Image 2")]
        public string Image2 { get; set; }
        [StringLength(100)]
        [DisplayName("Image 3")]
        public string Image3 { get; set; }
        [StringLength(100)]
        [DisplayName("Image 4")]
        public string Image4 { get; set; }
        [StringLength(100)]
        [DisplayName("Image 5")]
        public string Image5 { get; set; }
        [StringLength(100)]
        [DisplayName("Image 6")]
        public string Image6 { get; set; }
        [StringLength(100)]
        [DisplayName("Image 7")]
        public string Image7 { get; set; }
        [StringLength(100)]
        [DisplayName("Image 8")]
        public string Image8 { get; set; }
        [StringLength(100)]
        [DisplayName("Image 9")]
        public string Image9 { get; set; }
        [StringLength(100)]
        [DisplayName("Image 10")]
        public string Image10 { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }
        [NotMapped]
        [DisplayName("Upload File 2")]
        public IFormFile ImageFile2 { get; set; }
        [NotMapped]
        [DisplayName("Upload File 3")]
        public IFormFile ImageFile3 { get; set; }
        [NotMapped]
        [DisplayName("Upload File 4")]
        public IFormFile ImageFile4 { get; set; }
        [NotMapped]
        [DisplayName("Upload File 5")]
        public IFormFile ImageFile5 { get; set; }
        [NotMapped]
        [DisplayName("Upload File 6")]
        public IFormFile ImageFile6 { get; set; }
        [NotMapped]
        [DisplayName("Upload File 7")]
        public IFormFile ImageFile7 { get; set; }
        [NotMapped]
        [DisplayName("Upload File 8")]
        public IFormFile ImageFile8 { get; set; }
        [NotMapped]
        [DisplayName("Upload File 9")]
        public IFormFile ImageFile9 { get; set; }
        [NotMapped]
        [DisplayName("Upload File 10")]
        public IFormFile ImageFile10 { get; set; }

    }
}
