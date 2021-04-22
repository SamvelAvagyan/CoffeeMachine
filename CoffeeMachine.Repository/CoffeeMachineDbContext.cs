using CoffeeMachine.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeMachine.Repository
{
    public class CoffeeMachineDbContext : DbContext
    {
        public CoffeeMachineDbContext(DbContextOptions<CoffeeMachineDbContext> options)
            : base(options)
        { }

        public DbSet<Coffee> Coffees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=C:\Users\Acer\Database.db");
    }
}
