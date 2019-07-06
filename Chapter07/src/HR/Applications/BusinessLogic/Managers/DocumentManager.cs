using System.Collections.Generic;
using Applications.Model;
using Applications.DataAccess.Repositories;

namespace Applications.BusinessLogic.Managers
{
    public class DocumentManager : IDocumentManager
    {
        private IRepository _documentRepository;
        protected readonly Document DEFAULT_DOCUMENT;

        public DocumentManager(IRepository documentRepository) : base()
        {
            _documentRepository = documentRepository;
            DEFAULT_DOCUMENT = new Document { FileName = "Not found", Employee_ID = 0, DOC_ID = 0, DocData = null };
        }

        public IEnumerable<Document> GetAllDocuments()
        {
            return _documentRepository.GetAll<Document>();
        }

        public Document GetAnEmployeesDocument(int employeeId)
        {
            var document = _documentRepository.GetEntity<Document>(employeeId);
            if (document == null) return DEFAULT_DOCUMENT;
            return document;
        }

        public int GetTotalNumberOfDocuments()
        {
            return _documentRepository.GetRecordsCount<Document>();
        }
    }
}
