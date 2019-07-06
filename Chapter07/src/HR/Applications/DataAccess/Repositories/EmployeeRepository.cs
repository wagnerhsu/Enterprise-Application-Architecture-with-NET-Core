using Applications.DataAccess.Engine;
using Applications.Model;
using System.Linq;

namespace Applications.DataAccess.Repositories
{
    public class EmployeeRepository : GenericRepository
    {
        public EmployeeRepository(IDataContextCreator dataContextCreator) : base(dataContextCreator)
        {            
        }

        public Employee GetSingleEmployee(int employeeId)
        {
            using (var context = _dataContextCreator.GetDataContext())
            {
                return context.EMPLOYEE.SingleOrDefault(e => e.Employee_ID == employeeId);
            }
        }
    }
}
