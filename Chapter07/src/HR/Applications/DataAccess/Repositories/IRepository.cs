using System.Collections.Generic;

namespace Applications.DataAccess.Repositories
{
    /// <summary>
    /// This repository class takes care of disposing underlying dbcon/context objects
    /// </summary>
    public interface IRepository
    {
        TEntity GetEntity<TEntity>(int id) where TEntity : class;
        IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class;
        void Create<TEntity>(TEntity entity) where TEntity : class;
        void Update<TEntity>(TEntity entity) where TEntity : class;
        void Delete<TEntity>(TEntity entity) where TEntity : class;
        int GetRecordsCount<TEntity>() where TEntity : class;
    }
}
