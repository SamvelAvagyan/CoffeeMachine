using CoffeeMachine.Repository;
using CoffeeMachine.Repository.Impl;
using CoffeeMachine.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace CoffeeMachine.Test
{
    class Program
    {
        public static IServiceProvider serviceProvider;

        static void Main(string[] args)
        {
            CreateHostBuilder().Build();
            //CreateCoffees(10);
            //CreateUsers(3);
            //CreateIngredients();

            CoffeeMachineManager.ShowUsers();
            CoffeeMachineManager.ShowCoffees();

            CoffeeMachineManager.Start();
        }

        public static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddDbContext<CoffeeMachineDbContext>(con => con.UseSqlite(DataOptions.ConnectionString));
                    services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
                    services.AddScoped<ICoffeeRepository, CoffeeRepository>();
                    services.AddScoped<IOrderRepository, OrderRepository>();
                    services.AddScoped<IUserRepository, UserRepository>();
                    services.AddScoped<IIngredientRepository, IngredientRepository>();

                    serviceProvider = services.BuildServiceProvider();
                });

        private static void CreateCoffees(int count)
        {
            var rnd = new Random();

            for (int i = 0; i < count; i++)
            {
                CoffeeMachineManager.coffeeRepo.Add(new Coffee()
                {
                    Name = $"Coffee{i + 1}",
                    CoffeePortion = Math.Round(rnd.NextDouble(), 1),
                    Price = rnd.Next(1, 5) * 100,
                    SugarPortion = Math.Round(rnd.NextDouble(), 1),
                    WaterPortion = Math.Round(rnd.NextDouble(), 1)
                });
            }
        }

        private static void CreateUsers(int count)
        {
            var rnd = new Random();

            for (int i = 0; i < count; i++)
            {
                CoffeeMachineManager.userRepo.Add(new User()
                {
                    Name = $"User{i + 1}",
                    Balance = rnd.Next(2, 5) * 100
                });
            }
        }

        private static void CreateIngredients()
        {
            var rnd = new Random();

            CoffeeMachineManager.ingredientRepo.Add(new Ingredient() { Name = "Sugar", Quantity = rnd.Next(1, 5) * 3 });
            CoffeeMachineManager.ingredientRepo.Add(new Ingredient() { Name = "Water", Quantity = rnd.Next(1, 5) * 3 });
            CoffeeMachineManager.ingredientRepo.Add(new Ingredient() { Name = "Coffee", Quantity = rnd.Next(1, 5) * 3 });
        }
    }
}
