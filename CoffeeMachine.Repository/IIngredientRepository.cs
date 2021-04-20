using CoffeeMachine.Repository.Models;

namespace CoffeeMachine.Repository
{
    public interface IIngredientRepository : IBaseRepository<Ingredient>
    {
        Ingredient GetByName(string name);
    }
}
