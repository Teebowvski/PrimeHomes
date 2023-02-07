using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PrimeHomes.Areas.Identity.Data;
using PrimeHomes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeHomes.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Bathrooms> Bathrooms { get; set; }
        public DbSet<Bedrooms> Bedrooms { get; set; }
        public DbSet<Features> Features { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<PrimeHomes.Models.Type> Types { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<TeamMembers> TeamMembers { get; set; }

    }
}
