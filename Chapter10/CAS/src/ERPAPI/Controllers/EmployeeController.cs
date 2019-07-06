using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ERPAPI.Controllers
{


    [Route("api/[controller]")]
    [Authorize(Policy ="RequireAPIAccess")]
    public class EmployeeController : Controller
    {
        [Authorize(Policy ="RequireManagerRole")]
        [HttpGet]
        public List<Employee> Get()
        {
            return GetEmployees();
        }

        [HttpPost]
        public bool Create(Employee employee)
        {
            return CreateEmployee(employee);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            return DeleteEmployee(id);
        }

        [HttpPut]
        public bool Update(Employee employee)
        {
            return UpdateEmployee(employee);
        }



        private bool CreateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        private bool DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        private bool UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
        private List<Employee> GetEmployees()
        {
            throw new NotImplementedException();
        }
    }
}