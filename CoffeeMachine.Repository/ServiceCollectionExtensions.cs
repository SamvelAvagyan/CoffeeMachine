using CoffeeMachine.Repository;
using CoffeeMachine.Repository.Impl;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, string connectionString)
            => services.AddDbContext<CoffeeMachineDbContext>(con => con.UseSqlite(connectionString));

        public static IServiceCollection AddRepositoryContracts(this IServiceCollection services)
            => services
                .AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>))
                .AddScoped<ICoffeeRepository, CoffeeRepository>()
                .AddScoped<IUserRepository, UserRepository>();

        public static IServiceCollection AddRepository(this IServiceCollection services, string connectionString)
            => services
                .AddDbContext(connectionString)
                .AddRepositoryContracts();
    }
}
