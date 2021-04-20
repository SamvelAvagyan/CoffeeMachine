using CoffeeMachine.Repository.Models;
using System.Linq;

namespace CoffeeMachine.Repository.Impl
{
    public class IngredientRepository : BaseRepository<Ingredient>, IIngredientRepository
    {
        private readonly IBaseRepository<Ingredient> repo;
        public IngredientRepository(CoffeeMachineDbContext dbContext, IBaseRepository<Ingredient> repo)
            : base(dbContext)
        {
            this.repo = repo;
        }

        public Ingredient GetByName(string name)
        {
            return repo.GetAll().Where(i => i.Name == name).FirstOrDefault();
        }
    }
}
