using CoffeeMachine.Repository;
using CoffeeMachine.Repository.Impl;
using CoffeeMachine.Repository.Models;
using CoffeeMachine.Services;
using CoffeeMachine.Services.Impl;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CoffeeMachine.Test
{
    class Program
    {
        private static IServiceProvider serviceProvider;
        private static ICoffeeService coffeeService;

        static void Main(string[] args)
        {
            Configure();
            //CoffeeMachineManager.SelectUser();
            CreateCoffees(10);
        }

        private static void Configure()
        {
            var services = new ServiceCollection();
            //services.AddDbContext(DataOptions.ConnectionString);
            services.AddDbContext<CoffeeMachineDbContext>(con => con.UseSqlite(DataOptions.ConnectionString));
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped<ICoffeeService, CoffeeService>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICoffeeRepository, CoffeeRepository>();

            serviceProvider = services.BuildServiceProvider();
        }

        private static void CreateCoffees(int count)
        {
            coffeeService = serviceProvider.GetService<ICoffeeService>();
            var rnd = new Random();

            for (int i = 0; i < count; i++)
            {
                coffeeService.Add(new Coffee()
                {
                    Name = $"Coffee{i + 1}",
                    CoffeePortion = Math.Round(rnd.NextDouble(), 2),
                    Price = rnd.Next(1, 5) * 10,
                    SugarPortion = Math.Round(rnd.NextDouble(), 2),
                    WaterPortion = Math.Round(rnd.NextDouble(), 2)
                });
            }
        }
    }
}
