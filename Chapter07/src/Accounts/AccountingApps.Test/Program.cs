using HIJI.SOA.Accounts.Applications.DAL;
using System;

namespace HIJI.SOA.Accounts.Applications.Test
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
            var db = new AccountsDB();
            Console.WriteLine("Employee ID: 2 - Salary: " + db.GetEmployeeSalary(2));

            var salaries = db.ListAllSalaries();
            foreach(var salary in salaries)
                Console.WriteLine("E: " + salary.Employee_ID + " - S: " + salary.Salary);
        }
    }
}
