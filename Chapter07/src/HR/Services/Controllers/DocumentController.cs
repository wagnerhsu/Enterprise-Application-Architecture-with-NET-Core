using Applications.BusinessLogic.Managers;
using Applications.Model;
using Microsoft.AspNetCore.Mvc;
using HIJK.SOA.SOAServices;
using System.Collections.Generic;

namespace Services.Controllers
{
    /// <summary>
    /// This class exposes the APIs related to Employee's document in HR Database
    /// </summary>
    [Route("api/[controller]")]
    public class DocumentController : Controller
    {
        private SOAContext soaContext;
        private IDocumentManager _manager;

        public DocumentController(IDocumentManager documentManager)
        {
            _manager = documentManager;
        }

        /// <summary>
        /// Gets the list of all documents
        /// Usage: GET api/document
        /// Type: Information Service
        /// </summary>
        /// <returns>List of Documents</returns>
        [HttpGet]
        public IEnumerable<Document> Get()
        {
            soaContext = new SOAContext();
            soaContext.Initialize();

            var retVal = _manager.GetAllDocuments();

            soaContext.Close();

            return retVal;
        }

        /// <summary>
        /// Gets the list of all documents
        /// Usage: GET api/document/2
        /// Type: Information Service
        /// </summary>
        /// <returns>Document
        /// </returns>
        [HttpGet("{id}")]
        public Document Get(int id)
        {
            soaContext = new SOAContext();
            soaContext.Initialize();

            var retVal = _manager.GetAnEmployeesDocument(id);

            soaContext.Close();

            return retVal;
        }

        // GET api/document/about
        [HttpGet("About")]
        public ContentResult About()
        {
            return Content("APIs for Employee's documents in the HR Database.");
        }
    }
}
