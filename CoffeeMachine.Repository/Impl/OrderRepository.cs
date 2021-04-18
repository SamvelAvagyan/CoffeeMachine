using CoffeeMachine.Repository.Models;

namespace CoffeeMachine.Repository.Impl
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(CoffeeMachineDbContext dbContext)
            : base(dbContext)
        { }
    }
}
