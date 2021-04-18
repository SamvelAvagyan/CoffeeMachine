using CoffeeMachine.Repository;
using CoffeeMachine.Repository.Models;

namespace CoffeeMachine.Services.Impl
{
    public class StoreService : BaseService<Store>, IStoreService
    {
        public StoreService(IBaseRepository<Store> repo)
            : base(repo)
        { }
    }
}
