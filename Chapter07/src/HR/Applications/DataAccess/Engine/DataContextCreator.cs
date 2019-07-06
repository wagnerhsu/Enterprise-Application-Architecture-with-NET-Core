namespace Applications.DataAccess.Engine
{
    /// <summary>
    /// This class is to facilitate the creation of DataContext
    /// It can keep the reference counts as well as perform the house keeping
    /// </summary>
    public class DataContextCreator : IDataContextCreator
    {
        public DataContext GetDataContext()
        {
            return new DataContext();
        }
    }
}
