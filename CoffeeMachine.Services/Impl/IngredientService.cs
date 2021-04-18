using CoffeeMachine.Repository;
using CoffeeMachine.Repository.Models;

namespace CoffeeMachine.Services.Impl
{
    public class IngredientService : BaseService<Ingredient>, IIngredientService
    {
        public IngredientService(IBaseRepository<Ingredient> repo)
            : base(repo)
        { }
    }
}
