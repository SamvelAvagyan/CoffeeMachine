using CoffeeMachine.Repository.Models;

namespace CoffeeMachine.Repository.Impl
{
    public class CoffeeRepository : BaseRepository<Coffee>, ICoffeeRepository
    {
        public CoffeeRepository(CoffeeMachineDbContext dbContext)
            : base(dbContext)
        { }
    }
}
