using System.Linq;

namespace CoffeeMachine.Repository
{
    public interface IBaseRepository<T>
    {
        void Add(T model);
        IQueryable<T> GetAll();
        T GetById(int id);
        void Delete(int id);
        void Update(T model);
    }
}
