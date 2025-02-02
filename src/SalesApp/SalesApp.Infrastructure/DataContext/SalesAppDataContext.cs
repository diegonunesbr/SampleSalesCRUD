﻿using Microsoft.EntityFrameworkCore;
using SalesApp.Domain.Entities;

namespace SalesApp.Infrastructure.DataContext
{
    public class SalesAppDataContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }


        public SalesAppDataContext(DbContextOptions<SalesAppDataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).ValueGeneratedOnAdd();
                entity.Property(e => e.title).IsRequired().HasMaxLength(1000);
                entity.Property(e => e.price).IsRequired().HasPrecision(18, 2);
                entity.Property(e => e.description).IsRequired().HasMaxLength(5000);
                entity.Property(e => e.category).IsRequired().HasMaxLength(100);
                entity.Property(e => e.image).IsRequired(false).HasMaxLength(5000);
                entity.ComplexProperty(e => e.rating);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).ValueGeneratedOnAdd();
                entity.Property(e => e.email).IsRequired().HasMaxLength(300);
                entity.Property(e => e.username).IsRequired().HasMaxLength(300);
                entity.Property(e => e.password).IsRequired().HasMaxLength(100);
                entity.Property(e => e.phone).IsRequired().HasMaxLength(30);
                entity.ComplexProperty(e => e.name);
                entity.ComplexProperty(e => e.address);
                entity.ComplexProperty(e => e.address, b => b.ComplexProperty(e => e.geolocation));
            });
        }
    }
}
