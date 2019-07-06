namespace Services.WebServiceProxy
{
    /// <summary>
    /// Document Proxy class that deals/calls the appropriate web service.
    /// The calling web service endpoint and request depends on the type of document to submit to relevant authorities.
    /// Possible third parties to call and pass-on the data: Gov Authorities, B2B (configured), Batch-process (file based, directory watchers), Other third-part services and manual services
    /// 
    /// Type: Mediation Service
    /// Remarks: This does not has to be static class.
    /// </summary>
    public static class DocumentSubmitterProxy
    {
        public static void ProcessDocumentSubmission(int employeeId, int expiringDocumentId)
        {
            //...
        }
    }
}
