using Misfit.CORE.Domains;
using Misfit.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misfit.SERVICE.Services
{
    public class GenericService<TEntity> : BaseService where TEntity : class
    {
        protected T GetInstance<T>() where T : IGenericRepository<TEntity>
        {
            var repository = ServiceLocator.GetInstance<T>();

            return repository;

        }

        public virtual Response<TEntity> Get(object id)
        {
            var repository = GetInstance<IGenericRepository<TEntity>>();
            var result = SafeExecute(() => repository.Get(id));
            return result;
        }

        public virtual Response<TEntity> Insert(TEntity entity)
        {
            var repository = GetInstance<IGenericRepository<TEntity>>();
            var result = SafeExecute(() => repository.InsertAsync(entity));
            return result;
        }

        public virtual Response<TEntity> Update(TEntity entity)
        {
            var repository = GetInstance<IGenericRepository<TEntity>>();
            var result = SafeExecute(() => repository.UpdateAsync(entity));
            return result;
        }

        public virtual Response<TEntity> Save(TEntity entity)
        {
            var repository = GetInstance<IGenericRepository<TEntity>>();
            var result = SafeExecute(() => repository.Save(entity));
            return result;
        }

        public virtual Response<IQueryable<TEntity>> GetAll()
        {
            var repository = GetInstance<IGenericRepository<TEntity>>();
            var result = SafeExecute(() => repository.GetAll());
            return result;
        }
    }
}