using CoffeeMachine.Repository;
using CoffeeMachine.Repository.Models;

namespace CoffeeMachine.Services.Impl
{
    public class CoffeeService : BaseService<Coffee>, ICoffeeService
    {
        public CoffeeService(IBaseRepository<Coffee> repo)
            : base(repo)
        { }
    }
}
