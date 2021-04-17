﻿using CoffeeMachine.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeMachine.Repository
{
    public class CoffeeMachineDbContext : DbContext
    {
        public DbSet<Coffee> Coffees { get; set; } 
        public DbSet<Coffee> Users { get; set; } 
        public DbSet<Coffee> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=C:\Users\Acer\CoffeeMachineDB.db");
    }
}
