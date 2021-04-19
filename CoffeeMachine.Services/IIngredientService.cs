using CoffeeMachine.Repository.Models;

namespace CoffeeMachine.Services
{
    public interface IIngredientService : IBaseService<Ingredient>
    {
        Ingredient GetByName(string name);
    }
}
