using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApplication3.Models
{
    [Table("Payment")]
    public partial class Payment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(450)]
        public string PayingUserId { get; set; }
        [Required]
        [StringLength(450)]
        public string SellingUserId { get; set; }
        [Required]
        [StringLength(50)]
        public string CardNumber { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        [Required]
        [StringLength(10)]
        public string Cvc { get; set; }
        public int Value { get; set; }

        [ForeignKey(nameof(PayingUserId))]
        [InverseProperty(nameof(AspNetUser.Payments))]
        public virtual AspNetUser PayingUser { get; set; }
    }
}
