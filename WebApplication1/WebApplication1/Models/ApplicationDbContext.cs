﻿using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace JewelryStore.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Jewelry> Jewelries { get; set; }
        public DbSet<Order> Orders { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
