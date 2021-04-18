using CoffeeMachine.Repository;
using System.Collections.Generic;

namespace CoffeeMachine.Services.Impl
{
    public class BaseService<T> : IBaseService<T>
    {
        private readonly IBaseRepository<T> repo;

        public BaseService(IBaseRepository<T> repo)
        {
            this.repo = repo;
        }

        public IEnumerable<T> GetAll()
        {
            return repo.GetAll();
        }

        public T GetById(int id)
        {
            return repo.GetById(id);
        }

        public void Add(T model)
        {
            repo.Add(model);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public void Update(T model)
        {
            repo.Update(model);
        }
    }
}
