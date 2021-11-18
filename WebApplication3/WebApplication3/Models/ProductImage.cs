using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApplication3.Models
{
    [Table("ProductImage")]
    public partial class ProductImage
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "image")]
        public byte[] Image1 { get; set; }
        [Column(TypeName = "image")]
        public byte[] Image2 { get; set; }
        [Column(TypeName = "image")]
        public byte[] Image3 { get; set; }
        [Column(TypeName = "image")]
        public byte[] Image4 { get; set; }
        [Column("image5", TypeName = "image")]
        public byte[] Image5 { get; set; }
        [Column(TypeName = "image")]
        public byte[] Image6 { get; set; }
        [Column(TypeName = "image")]
        public byte[] Image7 { get; set; }
        [Column(TypeName = "image")]
        public byte[] Image8 { get; set; }
        [Column(TypeName = "image")]
        public byte[] Image9 { get; set; }
        [Column(TypeName = "image")]
        public byte[] Image10 { get; set; }
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        [InverseProperty("ProductImages")]
        public virtual Product Product { get; set; }
    }
}
