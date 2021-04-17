using CoffeeMachine.Repository.Models;

namespace CoffeeMachine.Repository.Impl
{
    public class StoreRepository : BaseRepository<Store>, IStoreRepository
    {
        public StoreRepository(CoffeeMachineDbContext dbContext)
            : base(dbContext)
        { }
    }
}
