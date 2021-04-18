using CoffeeMachine.Services;
using CoffeeMachine.Services.Impl;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceContracts(this IServiceCollection services)
            => services
                .AddScoped(typeof(IBaseService<>), typeof(BaseService<>))
                .AddScoped<ICoffeeService, CoffeeService>()
                .AddScoped<IIngredientService, IngredientService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IOrderService, OrderService>();

        public static IServiceCollection AddService(this IServiceCollection services, string connectionString)
            => services
                .AddRepository(connectionString)
                .AddServiceContracts();
    }
}
