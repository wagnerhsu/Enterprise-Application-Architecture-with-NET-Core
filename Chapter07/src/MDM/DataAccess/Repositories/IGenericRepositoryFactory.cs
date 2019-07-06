
namespace DataAccess.Repositories
{
    /// <summary>
    /// Generic Repository Creator
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public interface IGenericRepositoryFactory<TEntity, TKey> where TEntity : class
    {
        IRepository<TEntity, TKey> GetRepository();
    }
}
