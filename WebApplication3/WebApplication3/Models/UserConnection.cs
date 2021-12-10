using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApplication3.Models
{
    public partial class UserConnection
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(450)]
        public string FollowingUserId { get; set; }
        [Required]
        [StringLength(450)]
        public string FollowerUserId { get; set; }

        [ForeignKey(nameof(FollowerUserId))]
        [InverseProperty(nameof(AspNetUser.UserConnectionFollowerUsers))]
        public virtual AspNetUser FollowerUser { get; set; }
        [ForeignKey(nameof(FollowingUserId))]
        [InverseProperty(nameof(AspNetUser.UserConnectionFollowingUsers))]
        public virtual AspNetUser FollowingUser { get; set; }
    }
}
