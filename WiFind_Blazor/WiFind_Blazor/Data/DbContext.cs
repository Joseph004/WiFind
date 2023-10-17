﻿using Microsoft.EntityFrameworkCore;
using WiFind_Blazor.Models;

namespace WiFind_Blazor.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Location> Locations { get; set; } // DbSet property for Location model
        public DbSet<WiFiName> WiFiNames { get; set; } // DbSet property for WiFiName model

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Here you can configure relationships, keys, and other database settings

            // Example: Configure a primary key attribute for Location
            modelBuilder.Entity<Location>()
                .HasKey(l => l.Id);

            // Example: Configure a relationship between Location and WiFiName
            
            /* modelBuilder.Entity<Location>()
                .HasMany(l => l.WiFiNames)
                .WithOne(w => w.Location)
                .HasForeignKey(w => w.LocationId); */

            // Additional configuration for other models and relationships can be added here
        }
    }
}
