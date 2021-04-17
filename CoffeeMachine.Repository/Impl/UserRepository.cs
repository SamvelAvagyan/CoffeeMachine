using CoffeeMachine.Repository.Models;

namespace CoffeeMachine.Repository.Impl
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(CoffeeMachineDbContext dbContext)
            : base(dbContext)
        { }
    }
}
