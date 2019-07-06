using DataAccess.Model;
using DataAccess.Repositories;
using System.Collections.Generic;

namespace Applications
{
    public class DocumentTypes
    {
        public DocumentTypes()
        {
        }

        public IEnumerable<DOC_TYPE> WhatAreAllDocumentTypes()
        {
            var repoFactory = new GenericRepositoryFactory<DOC_TYPE, int>();

            using (var repo = repoFactory.GetRepository())
            {
                var allDocTypes = repo.GetAll();
                return allDocTypes;
            }
        }
    }
}
