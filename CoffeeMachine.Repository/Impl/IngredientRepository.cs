using CoffeeMachine.Repository.Models;

namespace CoffeeMachine.Repository.Impl
{
    public class IngredientRepository : BaseRepository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(CoffeeMachineDbContext dbContext)
            : base(dbContext)
        { }
    }
}
