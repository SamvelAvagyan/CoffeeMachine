using CoffeeMachine.Repository;
using CoffeeMachine.Repository.Models;
using System.Linq;

namespace CoffeeMachine.Services.Impl
{
    public class IngredientService : BaseService<Ingredient>, IIngredientService
    {
        private readonly IIngredientRepository repo;

        public IngredientService(IBaseRepository<Ingredient> repo, IIngredientRepository ingRepo)
            : base(repo)
        {
            this.repo = ingRepo;
        }

        public Ingredient GetByName(string name)
        {
            return repo.GetAll().Where(i => i.Name == name).FirstOrDefault();
        }
    }
}
