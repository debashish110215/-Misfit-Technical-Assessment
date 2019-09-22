using Microsoft.EntityFrameworkCore;
using Misfit.CORE.Interfaces;
using Misfit.CORE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Misfit.DA.DataAccesses
{
    public class GenericDataAccess<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal MisfitDBContext MisfitDBContext;
        internal DbSet<TEntity> MisfitDBSet;

        public GenericDataAccess(MisfitDBContext context)
        {
            this.MisfitDBContext = context;
            this.MisfitDBSet = MisfitDBContext.Set<TEntity>();
        }

        public int Delete(object id)
        {
            var entity = MisfitDBSet.Find(id);
            return Delete(entity);
        }

        public int Delete(TEntity entity)
        {
            if (MisfitDBContext.Entry(entity).State == EntityState.Detached)
            {
                MisfitDBSet.Attach(entity);
            }

            MisfitDBSet.Remove(entity);
            return MisfitDBContext.SaveChanges();
        }

        public TEntity Get(object Id)
        {
            return MisfitDBContext.Set<TEntity>().Find(Id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return MisfitDBContext.Set<TEntity>().AsNoTracking();
        }

        public TEntity Insert(TEntity entity)
        {
            PropertyInfo propCreatedOn = entity.GetType().GetProperty("CreatedOn");
            if (propCreatedOn != null)
            {
                propCreatedOn.SetValue(entity, DateTime.Now, null);
            }

            PropertyInfo property = entity.GetType().GetProperty("UpdatedOn");
            if (property != null)
            {
                property.SetValue(entity, DateTime.Now, null);
            }

            MisfitDBContext.Set<TEntity>().Add(entity);
            MisfitDBContext.SaveChanges();
            return entity;
        }

        public TEntity InsertAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Save(TEntity entity)
        {
            PropertyInfo prop = entity.GetType().GetProperty("Id");
            if (prop != null)
            {
                object Id = prop.GetValue(entity, null);
                if ((long)Id == 0)
                {
                    return this.Insert(entity);
                }
                else
                {
                    return this.Update(entity);
                }
            }

            return null;
        }

        public TEntity Update(TEntity entity)
        {
            PropertyInfo property = entity.GetType().GetProperty("UpdatedOn");
            if (property != null)
            {
                property.SetValue(entity, DateTime.Now, null);
            }
            MisfitDBContext.Set<TEntity>().Update(entity);
            MisfitDBContext.SaveChanges();
            return entity;

        }

        public TEntity UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public PagedModel<T> CreatedPagedModel<T>(IQueryable<T> query, int pageNo, int pageSize) where T : class
        {
            PagedModel<T> pagedModel = new PagedModel<T>();

            pagedModel.PageNumber = pageNo;
            pagedModel.PageSize = pageSize;
            pagedModel.TotalRows = query.Count();

            var skip = (pageNo - 1) * pageSize;
            pagedModel.TableData = query.Skip(skip).Take(pageSize).ToList();

            return pagedModel;
        }
    }
}
