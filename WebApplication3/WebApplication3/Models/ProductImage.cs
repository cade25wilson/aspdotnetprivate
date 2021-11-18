using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication3.Models
{
    public partial class ProductImage
    {
        public int Id { get; set; }
        public byte[] Image1 { get; set; }
        public byte[] Image2 { get; set; }
        public byte[] Image3 { get; set; }
        public byte[] Image4 { get; set; }
        public byte[] Image5 { get; set; }
        public byte[] Image6 { get; set; }
        public byte[] Image7 { get; set; }
        public byte[] Image8 { get; set; }
        public byte[] Image9 { get; set; }
        public byte[] Image10 { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
