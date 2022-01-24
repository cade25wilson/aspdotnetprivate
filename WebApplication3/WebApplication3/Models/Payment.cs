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
        [StringLength(16), MinLength(16)]
        public string CardNumber { get; set; }
        [Required]
        [Range(0, 12)]
        public int Month { get; set; }
        [Required]
        [Range(2021, 2030)]
        public int Year { get; set; }
        [Required]
        [Range(0,1000)]
        public string Cvc { get; set; }
        public int Value { get; set; }
    }
}
