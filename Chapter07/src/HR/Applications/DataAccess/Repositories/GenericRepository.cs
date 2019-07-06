using Applications.DataAccess.Engine;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Applications.DataAccess.Repositories
{
    /// <summary>
    /// Generic implementation of IRepository interface for HR business apps.
    /// The class takes will take care of disposing underlying dbcon/context objects.
    /// </summary>
    public class GenericRepository : IRepository
    {
        protected IDataContextCreator _dataContextCreator;

        public GenericRepository(IDataContextCreator dataContextCreator)
        {
            _dataContextCreator = dataContextCreator;
        }

        public void Create<TEntity>(TEntity entity) where TEntity : class
        {
            using (var context = _dataContextCreator.GetDataContext())
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            using (var context = _dataContextCreator.GetDataContext())
            {
                context.Set<TEntity>().Remove(entity);
                context.SaveChanges();
            }
        }

        public TEntity GetEntity<TEntity>(int id) where TEntity : class
        {
            using (var context = _dataContextCreator.GetDataContext())
            {
                if (typeof(TEntity) == typeof(Model.Employee)) //Not a good way, for such cases implement respective repository
                    return context.EMPLOYEE.SingleOrDefault(e => e.Employee_ID == id) as TEntity;
                if (typeof(TEntity) == typeof(Model.Document))
                    return context.DOCUMENTS.SingleOrDefault(e => e.Employee_ID == id) as TEntity;
                return null;
            }
        }

        public IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            using (var context = _dataContextCreator.GetDataContext())
                return context.Set<TEntity>().ToList();
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            try
            {
                using (var context = _dataContextCreator.GetDataContext())
                {
                    var entry = context.Entry(entity);
                    context.Set<TEntity>().Attach(entity);
                    entry.State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetRecordsCount<TEntity>() where TEntity : class
        {
            using (var context = _dataContextCreator.GetDataContext())
                return context.Set<TEntity>().Count();
        }
    }
}
