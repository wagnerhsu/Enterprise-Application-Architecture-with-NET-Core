
namespace Applications.BusinessLogic.DocumentReceivers
{
    /// <summary>
    /// Abstract base class to hold the common functionality across all types of Document Receiver
    /// managed by HIJK Regulatory Affairs.
    /// Place holder for:
    /// Common Constants
    /// Static & Dynamic Configuration
    /// Default location/path/error handling
    /// Default implementation
    /// </summary>
    public abstract class AbsDocumentReceiver : IDocumentReceiver
    {
        protected byte[] _fileInBytes;
        public void ReceiveDocument(byte[] fileInBytes)
        {
            _fileInBytes = fileInBytes;
        }
    }
}
