using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misfit.CORE.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        TEntity InsertAsync(TEntity entity);
        TEntity UpdateAsync(TEntity entity);
        TEntity Save(TEntity entity);
        int Delete(object id);
        int Delete(TEntity entity);
        TEntity Get(object Id);
    }
}

