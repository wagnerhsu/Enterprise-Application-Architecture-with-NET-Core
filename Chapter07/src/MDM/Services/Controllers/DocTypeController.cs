using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Model;
using Applications;
using HIJK.SOA.SOAServices;

namespace Services.Controllers
{
    /// <summary>
    /// This class exposes the APIs for Document Types for the MDM data source
    /// </summary>
    [Route("api/[controller]")]
    public class DocTypeController : Controller
    {
        private SOAContext soaContext;

        /// <summary>
        /// Usage: GET api/doctype
        /// Type: Information Service
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<DOC_TYPE> Get()
        {
            soaContext = new SOAContext();
            soaContext.Initialize();

            var retVal = new DocumentTypes().WhatAreAllDocumentTypes();

            soaContext.Close();
            return retVal;
        }

        // GET api/doctype/about
        [HttpGet("About")]
        public ContentResult About()
        {
            return Content("APIs for Document Types in the MDM data source.");
        }
    }
}
