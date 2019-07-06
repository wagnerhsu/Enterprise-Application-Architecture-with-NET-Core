using System.Collections.Generic;
using Applications.DataAccess.Repositories;
using Applications.Model;

namespace Applications.BusinessLogic.Managers
{
    public class EmployeeManager : IEmployeeManager
    {
        private IRepository _employeeRepository;
        protected readonly Employee DEFAULT_EMPLOYEE;

        public EmployeeManager(IRepository employeeRepository) : base()
        {
            _employeeRepository = employeeRepository;
            DEFAULT_EMPLOYEE = new Employee { FirstName = "Not found", FamilyName = "Not found", Employee_ID = 0 };
        }

        public int GetTotalNumberOfEmployees()
        {
            return _employeeRepository.GetRecordsCount<Employee>();
        }

        public Employee AddNewEmployee(Employee newEmployee)
        {
            _employeeRepository.Create(newEmployee);
            return newEmployee;
        }

        public IEnumerable<Employee> GetListofAllEmployees()
        {
            return _employeeRepository.GetAll<Employee>();
        }

        public void RemoveAnEmployee(Employee newEmployee)
        {
            _employeeRepository.Delete(newEmployee);
        }

        public Employee GetAnEmployee(int employeeId)
        {
            var employee = _employeeRepository.GetEntity<Employee>(employeeId);
            if (employee == null) return DEFAULT_EMPLOYEE;
            return employee;
        }
    }
}
