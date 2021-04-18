using CoffeeMachine.Repository;
using CoffeeMachine.Repository.Models;

namespace CoffeeMachine.Services.Impl
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(IBaseRepository<User> repo)
            : base(repo)
        { }
    }
}
