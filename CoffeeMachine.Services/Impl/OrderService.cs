using CoffeeMachine.Repository;
using CoffeeMachine.Repository.Models;

namespace CoffeeMachine.Services.Impl
{
    public class OrderService : BaseService<Order>, IOrderService
    {
        public OrderService(IBaseRepository<Order> repo)
            : base(repo)
        { }
    }
}
