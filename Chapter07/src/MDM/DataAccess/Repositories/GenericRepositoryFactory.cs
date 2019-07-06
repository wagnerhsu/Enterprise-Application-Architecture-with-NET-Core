using DataAccess.Engine;

namespace DataAccess.Repositories
{
    /// <summary>
    /// The idea of generic factory is to be able to create, use and discard repository object in demand.
    /// And not keep repository object for the life cycle of the relevant SOA Service.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public class GenericRepositoryFactory<TEntity, TKey> : IGenericRepositoryFactory<TEntity, TKey> where TEntity : class
    {
        public IRepository<TEntity, TKey> GetRepository()
        {
            return new GenericRepository<TEntity, TKey>(new DataContext()); //Candidate to use DI
        }
    }
}
