using Applications.DataAccess.Engine;
using System;

namespace RegulatoryApps.Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Test_DataAccessLayer();
            Console.ReadKey();
        }

        public static void Test_DataAccessLayer()
        {
            using (var db = new DataContext())
            {
                foreach (var docValidity in db.DOCUMENT_VALIDITY)
                    Console.WriteLine(docValidity.DOC_ID + " - " + docValidity.DOC_Issue_Date.ToString("yyyy-MM-dd"));
            }
        }
    }
}
