namespace DataAccess.Engine
{
    public class DataContextCreator : IDataContextCreator
    {
        public DataContext GetDataContext()
        {
            return new DataContext();
        }
    }
}
