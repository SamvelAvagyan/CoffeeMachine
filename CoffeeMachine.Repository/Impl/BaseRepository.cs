using CoffeeMachine.Repository.Models;
using System;
using System.Linq;

namespace CoffeeMachine.Repository.Impl
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : AbstractEntity
    {
        private readonly CoffeeMachineDbContext dbContext;

        public BaseRepository(CoffeeMachineDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<T> GetAll()
        {
            return dbContext.Set<T>();
        }

        public T GetById(int id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public void Add(T model)
        {
            dbContext.Set<T>().Add(model);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = GetById(id);
            if (model == null)
                throw new ArgumentException("Invalid id");

            dbContext.Set<T>().Remove(model);
            dbContext.SaveChanges();
        }

        public void Update(T model)
        {
            dbContext.Set<T>().Update(model);
            dbContext.SaveChanges();
        }
    }
}
