using Applications.BusinessLogic.DocumentReceivers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using Applications.Model;

namespace Services.Controllers
{
    [Route("api/regulatory/[controller]")]
    public class FileUploadController : Controller
    {
        private readonly string ServerUploadFolder;

        public FileUploadController()
        {
            //Determine base path for the application.
            var basePath = PlatformServices.Default.Application.ApplicationBasePath;
            ServerUploadFolder = Path.Combine(basePath, "ReceivedFiles");
        }

        /// <summary>
        /// This method receives the binary/file data in the WebAPI
        /// Type: Access Service
        /// Remarks: This method should execute asynchronously as it can take more time than usual in case of high traffic
        /// </summary>
        /// <returns></returns>
        [Route("files")]
        [HttpPost]
        [ValidateMimeMultipartContentFilter]
        public IActionResult UploadSingleFile()
        {
            byte[] fileInBytes;
            Request.Body.Seek(0, SeekOrigin.Begin);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                Request.Body.CopyTo(memoryStream);
                fileInBytes = memoryStream.ToArray();
            }

            //Save the byte buffer into filesystem cache/log
            var docType = DocumentTypes.DetermineDocType(fileInBytes);

            //Invoke the Relevant DocumentReceiver
            IDocumentReceiver docReceiver = GetTheRightReceiver(docType);
            docReceiver.ReceiveDocument(fileInBytes);

            return new OkResult();
        }

        private IDocumentReceiver GetTheRightReceiver(DOC_TYPE docType)
        {
            return new PassportReceiver();
        }
    }
}
