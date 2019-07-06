using Applications.Model;

namespace Applications.BusinessLogic.DocumentReceivers
{
    public class DocumentTypes
    {
        public static DOC_TYPE DetermineDocType(byte[] documentData)
        {
            DOC_TYPE docType;

            //..Deterministric Code..

            docType = DOC_TYPE.Passport; //sample..

            return docType;
        }
    }
}
