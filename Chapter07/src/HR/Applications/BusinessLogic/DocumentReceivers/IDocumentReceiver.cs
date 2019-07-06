
namespace Applications.BusinessLogic.DocumentReceivers
{
    public interface IDocumentReceiver
    {
        void ReceiveDocument(byte[] fileInBytes);
    }
}
