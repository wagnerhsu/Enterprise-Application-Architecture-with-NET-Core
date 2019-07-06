using System;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    /// <summary>
    /// A Common Repository interface which is pretty generic to all db repositories
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public interface IRepository<TEntity, in TKey> : IDisposable where TEntity : class
    {
        //TEntity Get(TKey id);
        IEnumerable<TEntity> GetAll();
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
