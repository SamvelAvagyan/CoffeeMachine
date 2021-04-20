using CoffeeMachine.Repository;
using CoffeeMachine.Repository.Impl;
using CoffeeMachine.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CoffeeMachine.Test
{
    class Program
    {
        public static IServiceProvider serviceProvider;

        static void Main(string[] args)
        {
            Configure();
            //CreateCoffees(10);
            //CreateUsers(3);

            CoffeeMachineManager.SelectUser();
            CoffeeMachineManager.InsertCoins();
        }

        private static void Configure()
        {
            var services = new ServiceCollection();

            services.AddDbContext<CoffeeMachineDbContext>(con => con.UseSqlite(DataOptions.ConnectionString));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICoffeeRepository, CoffeeRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();

            serviceProvider = services.BuildServiceProvider();
        }

        private static void CreateCoffees(int count)
        {
            var rnd = new Random();

            for (int i = 0; i < count; i++)
            {
                CoffeeMachineManager.coffeeRepo.Add(new Coffee()
                {
                    Name = $"Coffee{i + 1}",
                    CoffeePortion = Math.Round(rnd.NextDouble(), 2),
                    Price = rnd.Next(1, 5) * 100,
                    SugarPortion = Math.Round(rnd.NextDouble(), 2),
                    WaterPortion = Math.Round(rnd.NextDouble(), 2)
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
                    Name = $"Coffee{i + 1}",
                    Balance = rnd.Next(2, 5) * 100
                });
            }
        }
    }
}
