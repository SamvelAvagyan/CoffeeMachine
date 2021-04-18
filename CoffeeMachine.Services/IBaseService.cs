using System.Collections.Generic;

namespace CoffeeMachine.Services
{
    public interface IBaseService<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T model);
        void Delete(int id);
        void Update(T model);
    }
}
