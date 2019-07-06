
namespace Applications.DataAccess.Engine
{
    /// <summary>
    /// This is more like a DataContext factory or DB/DBCon factory
    /// </summary>
    public interface IDataContextCreator
    {
        DataContext GetDataContext();
    }
}
