﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApplication3.Models
{
    [Index(nameof(NormalizedEmail), Name = "EmailIndex")]
    public partial class AspNetUser
    {
        public AspNetUser()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaim>();
            AspNetUserLogins = new HashSet<AspNetUserLogin>();
            AspNetUserRoles = new HashSet<AspNetUserRole>();
            AspNetUserTokens = new HashSet<AspNetUserToken>();
            Forums = new HashSet<Forum>();
            Payments = new HashSet<Payment>();
            Products = new HashSet<Product>();
            UserConnectionFollowerUsers = new HashSet<UserConnection>();
            UserConnectionFollowingUsers = new HashSet<UserConnection>();
        }

        [Key]
        public string Id { get; set; }
        [Required]
        [StringLength(256)]
        public string UserName { get; set; }
        [StringLength(256)]
        public string NormalizedUserName { get; set; }
        [StringLength(256)]
        public string Email { get; set; }
        [StringLength(256)]
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

        [InverseProperty(nameof(AspNetUserClaim.User))]
        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        [InverseProperty(nameof(AspNetUserLogin.User))]
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        [InverseProperty(nameof(AspNetUserRole.User))]
        public virtual ICollection<AspNetUserRole> AspNetUserRoles { get; set; }
        [InverseProperty(nameof(AspNetUserToken.User))]
        public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; set; }
        [InverseProperty(nameof(Forum.PostCreator))]
        public virtual ICollection<Forum> Forums { get; set; }
        [InverseProperty(nameof(Payment.PayingUser))]
        public virtual ICollection<Payment> Payments { get; set; }
        [InverseProperty(nameof(Product.Poster))]
        public virtual ICollection<Product> Products { get; set; }
        [InverseProperty(nameof(UserConnection.FollowerUser))]
        public virtual ICollection<UserConnection> UserConnectionFollowerUsers { get; set; }
        [InverseProperty(nameof(UserConnection.FollowingUser))]
        public virtual ICollection<UserConnection> UserConnectionFollowingUsers { get; set; }
    }
}
