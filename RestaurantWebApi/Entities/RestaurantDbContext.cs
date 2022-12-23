﻿using Microsoft.EntityFrameworkCore;

namespace RestaurantWebApi.Entities
{
    public class RestaurantDbContext : DbContext

    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        {

        }
        private string _connectionString = "Server=(LocalDB)\\MSSQLLocalDB;Database=RestaurantDB;Trusted_Connection=True;";
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Dish> Dishes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>()
                .Property(r => r.Name)
                .IsRequired().HasMaxLength(25);
            modelBuilder.Entity<Dish>().Property(d => d.Name).IsRequired();
            modelBuilder.Entity<Address>().Property(a => a.City).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Address>().Property(a => a.Street).IsRequired().HasMaxLength(50);
        }

    }
}
