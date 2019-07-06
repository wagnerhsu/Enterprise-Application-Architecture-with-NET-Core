using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Applications.Model;
using Applications.BusinessLogic.Managers;
using HIJK.SOA.SOAServices;

namespace Services.Controllers
{
    /// <summary>
    /// This class exposes the APIs related to Employee in HR Database
    /// </summary>
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private SOAContext soaContext;
        private IEmployeeManager _manager;

        public EmployeeController(IEmployeeManager employeeManager)
        {
            _manager = employeeManager;
        }

        /// <summary>
        /// Gets the list of all Employees
        /// Usage: GET api/employee
        /// Type: Information Service
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            soaContext = new SOAContext();
            soaContext.Initialize();

            var retVal = _manager.GetListofAllEmployees();

            soaContext.Close();

            return retVal;
        }

        /// <summary>
        /// Gets a record of single Employee.
        /// Exposes an Employee structure based on its ID.
        /// Usage: GET api/employee/2
        /// Type: Information Service
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            soaContext = new SOAContext();
            soaContext.Initialize();

            var retVal = _manager.GetAnEmployee(id);

            soaContext.Close();

            return retVal;
        }

        // POST api/employee
        [HttpPost]
        public IActionResult Post([FromBody]Employee newEmployee)
        {
            soaContext = new SOAContext();
            soaContext.Initialize();

            _manager.AddNewEmployee(newEmployee);

            soaContext.Close();
            return new OkResult();
        }

        //// GET: api/employee/search?name=th
        //[HttpGet("Search")]
        //public IActionResult Search(string name)
        //{
        //    soaContext = new SOAContext();
        //    soaContext.Initialize();

        //    //var result = _manager.GetByNameSubstring(namelike);

        //    soaContext.Close();

        //    return Ok(result);
        //}

        // GET api/employee/about
        [HttpGet("About")]
        public ContentResult About()
        {
            return Content("APIs for Employees in the HR Database.");
        }
    }
}
