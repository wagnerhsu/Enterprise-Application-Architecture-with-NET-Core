using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ERPAPI.Controllers
{
    public class CourseController : Controller
    {

        IAuthorizationService _authorizationService = null;
        public CourseController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
       
        
        public Course GetCourseObject(string courseCode)
        {
            return new Course();
        }

        public async Task<IActionResult> ViewCourse(string courseCode)
        {

            Course course = GetCourseObject(courseCode);
            if(await _authorizationService.AuthorizeAsync(HttpContext.User, course, "PaidCourse"))
            {
                return View(course);
            }
            else
            {
                return new ChallengeResult();
            }
        }
    }

    public class Course
    {
        public bool IsPaid { get; internal set; }
    }
}
