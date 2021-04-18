using CoffeeMachine.Repository;
using CoffeeMachine.Repository.Impl;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoffeeMachine.Test
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        private IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
                    services.AddScoped<ICoffeeRepository, CoffeeRepository>();
                    services.AddScoped<IStoreRepository, StoreRepository>();
                    services.AddScoped<IUserRepository, UserRepository>();
                });
        }
    }
}
