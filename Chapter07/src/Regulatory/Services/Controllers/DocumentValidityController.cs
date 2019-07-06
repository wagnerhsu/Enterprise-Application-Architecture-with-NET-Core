using Microsoft.AspNetCore.Mvc;
using Applications.Model;
using HIJK.SOA.SOAServices;
using Services.WebServiceProxy;

namespace Services.Controllers
{
    [Route("api/[controller]")]
    public class DocumentValidityController : Controller
    {
        private SOAContext soaContext;

        /// <summary>
        /// This API gets the notifications from the DB Documents Validation Notification service.
        /// Usage: - GET api/DocumentValidity/notify?employeeId=2&docid=1
        /// Type: Interaction Service
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="docId"></param>
        /// <returns></returns>
        [HttpGet("Notify")]
        public IActionResult Notify(int employeeId, int docId)
        {
            soaContext = new SOAContext();
            soaContext.Initialize();

            //Start document validation/expiry process by invoking DocumentSubmitter to Authorities depending on the type of the document
            DocumentSubmitterProxy.ProcessDocumentSubmission(employeeId, docId);

            soaContext.Close();

            return new OkResult();
        }

        // GET: api/DocumentValidity
        [HttpGet]
        public ContentResult Get()
        {
            return Content("APIs for Documents validations in HIJK's Regulatory Affairs department.");
        }

        // GET api/DocumentValidity/2
        [HttpGet("{id}")]
        public DocumentValidity Get(int employeeId)
        {
            return new DocumentValidity(); //TODO - not important for architectural concepts..
        }
    }
}
