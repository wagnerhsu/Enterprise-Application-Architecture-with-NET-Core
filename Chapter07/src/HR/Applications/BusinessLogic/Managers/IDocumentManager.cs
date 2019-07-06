using Applications.Model;
using System.Collections.Generic;

namespace Applications.BusinessLogic.Managers
{
    public interface IDocumentManager : IBusinessManager
    {
        int GetTotalNumberOfDocuments();

        /// <summary>
        /// Gets the List of All Documents
        /// </summary>
        /// <returns></returns>
        IEnumerable<Document> GetAllDocuments();

        /// <summary>
        /// Get the document of an employee with a given id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Document GetAnEmployeesDocument(int employeeId);
    }
}
