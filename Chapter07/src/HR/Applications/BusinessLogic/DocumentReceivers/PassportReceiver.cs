
namespace Applications.BusinessLogic.DocumentReceivers
{
    /// <summary>
    /// Receives the newly issued/renewed Passport Document and pass it on to the HR service
    /// </summary>
    public class PassportReceiver : AbsDocumentReceiver
    {
        public new void ReceiveDocument(byte[] fileInBytes)
        {
            _fileInBytes = fileInBytes;

            //Invoke the HR Web Service to pass them the new passport document
            //HRServiceProxy.UpdateHRDocWithDocType
        }
    }
}
