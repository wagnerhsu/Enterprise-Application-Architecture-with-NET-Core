using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Services.Controllers
{
    [Route("api/[controller]")]
    public class ExternalExpensesController : Controller
    {
        /// <summary>
        /// Receives the external expenses file and save it to Accounting database.
        /// Case if files come from HTTP Form (ex MVC application)
        /// Type: Adapater Service
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        [HttpPost("SaveToDatabase")]
        public async Task<IActionResult> Post(IFormFile formFile)
        {
            // full path to file in temp location
            var filePath = Path.GetTempFileName();

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }

            //1. Parse the uploaded files
            //2. Save the parsed data into database using data access layer
            //3. Delete the temp file

            return Ok(filePath);
        }

        /// <summary>
        /// Receives the external expenses file and save it to Accounting database.
        /// Case when file comes from another web service
        /// Type: Adapater Service
        /// </summary>
        [HttpPost]
        public void Post()
        {
            if (Request.HasFormContentType)
            {
                var form = Request.Form;
                foreach (var formFile in form.Files)
                {
                    var filePath = Path.GetTempFileName();

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        formFile.CopyTo(fileStream);
                    }

                    //1. Parse the uploaded files
                    //2. Save the parsed data into database using data access layer
                    //3. Delete the temp files
                }
            }
        }
    }
}
