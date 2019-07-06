using Applications.DataAccess.Engine;
using Applications.DataAccess.Repositories;
using Applications.Model;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HRApps.Test
{
    public class Program
    {
        private static IServiceProvider Provider { get; set; }

        public static void Main(string[] args)
        {
            RegisterServices();

            //Test_DataAccessLayer();
            Test_RepositoryAccess();

            Test_AddNewEmployee();

            Test_RepositoryAccess();

            Console.ReadKey();
        }

        private static void RegisterServices()
        {
            IServiceCollection services = new ServiceCollection();

            //Adding required dependencies to the DI Container
            services.AddTransient<IDataContextCreator, DataContextCreator>();

            Provider = services.BuildServiceProvider();
        }

        /// <summary>
        /// Test case method for DataAccessLayer
        /// </summary>
        public static void Test_DataAccessLayer()
        {
            using (var db = new DataContext())
            {
                foreach (var emp in db.EMPLOYEE)
                    Console.WriteLine("(" + emp.Employee_ID +") " + emp.FirstName + " " + emp.FamilyName + " - " + emp.DOB.ToString("yyyy-MM-dd"));

                foreach (var photo in db.PHOTO)
                    Console.WriteLine("Photo of " + photo.Employee_ID);

                foreach (var doc in db.DOCUMENTS)
                    Console.WriteLine("Document of " + doc.Employee_ID + " - " + doc.FileName);
            }
        }

        /// <summary>
        /// Test case method for Repository layer
        /// </summary>
        public static void Test_RepositoryAccess()
        {
            //var repoFactory = new GenericRepositoryFactory<Employee, int>();
            var dataContextCreator = Provider.GetRequiredService<IDataContextCreator>();
            var repo = new GenericRepository(dataContextCreator);

            var employees = repo.GetAll<Employee>();
            foreach (var emp in employees)
                Console.WriteLine("(" + emp.Employee_ID + ") " + emp.FirstName + " " + emp.FamilyName + " - " + emp.DOB.ToString("yyyy-MM-dd"));
        }

        /// <summary>
        /// Test case method for Repository layer
        /// </summary>
        public static void Test_AddNewEmployee()
        {
            //var repoFactory = new GenericRepositoryFactory<Employee, int>();
            var dataContextCreator = Provider.GetRequiredService<IDataContextCreator>();
            var repo = new GenericRepository(dataContextCreator);

            int totalNumberOfEmployees = repo.GetRecordsCount<Employee>();
            Console.WriteLine("Total number of employees: " + totalNumberOfEmployees);

            int newEmployeeId = totalNumberOfEmployees + 1;
            repo.Create(new Employee()
            {
                Employee_ID = newEmployeeId,
                FirstName = "AFirstName" + newEmployeeId,
                FamilyName = "AFamilyName" + newEmployeeId,
                DOB = DateTime.Now.AddYears(-33)
            });

            totalNumberOfEmployees = repo.GetRecordsCount<Employee>();
            Console.WriteLine("Total number of employees: " + totalNumberOfEmployees);
        }
    }
}
