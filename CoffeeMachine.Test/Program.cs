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
                    services.AddService(DataOptions.ConnectionString);
                });
        }
    }
}
