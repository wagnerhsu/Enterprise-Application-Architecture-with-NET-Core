using Applications.Model;
using System.Collections.Generic;

namespace Applications.BusinessLogic.Managers
{
    public interface IEmployeeManager : IBusinessManager
    {
        int GetTotalNumberOfEmployees();

        /// <summary>
        /// Adds the new employee into the DB
        /// </summary>
        /// <returns></returns>
        Employee AddNewEmployee(Employee newEmployee);

        void RemoveAnEmployee(Employee newEmployee);

        /// <summary>
        /// Gets the List of All Employees eventually from data source
        /// </summary>
        /// <returns></returns>
        IEnumerable<Employee> GetListofAllEmployees();

        Employee GetAnEmployee(int employeeId);
    }
}
