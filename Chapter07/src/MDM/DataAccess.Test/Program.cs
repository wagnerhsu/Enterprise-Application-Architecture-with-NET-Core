using DataAccess.Engine;
using DataAccess.Model;
using DataAccess.Repositories;
using System;

namespace DataAccess.Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Test_DataAccessLayer();
            Test_RepositoryAccess();
            Console.ReadKey();
        }

        public static void Test_DataAccessLayer()
        {
            using (var db = new DataContext())
            {
                foreach (var docType in db.DOC_TYPE)
                    Console.WriteLine(docType.Name);
            }
        }

        public static void Test_RepositoryAccess()
        {
            var repoFactory = new GenericRepositoryFactory<DOC_TYPE, int>();
            using (var repo = repoFactory.GetRepository())
            {

                var allDocTypes = repo.GetAll();
                foreach (var docType in allDocTypes)
                    Console.WriteLine(docType.Name);
            }
        }
    }
}
