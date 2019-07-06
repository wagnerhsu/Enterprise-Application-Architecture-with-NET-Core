using Microsoft.AspNetCore.Mvc;

namespace MathWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class MathController : Controller
    {
        // GET: api/math(a=aVal&b=bVal)
        [HttpGet]
        public int Sum(int a, int b)
        {
            return a + b;
        }
        
    }
}
