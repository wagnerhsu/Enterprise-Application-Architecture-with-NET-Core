// <copyright file="AccountsDB.cs" company="HIJK">
//     Copyright (c) HIJK Ltd. All rights reserved.
// </copyright>
// <summary>
//     <project>HIJK Accounts Department Services</project>
//     <description>
//         Services for Accounts Department. Database Access Layer (DAL)
//         IT team for Accounts does not use EF but ADO.NET
//     </description>
// </summary>

using HIJI.SOA.Accounts.Applications.Entities;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace HIJI.SOA.Accounts.Applications.DAL
{
    public class AccountsDB
    {
        private SqliteConnection _connection;

        public AccountsDB()
        {
            var conBuilder = new SqliteConnectionStringBuilder { DataSource = "E:\\SOA_Sample.db" };
            _connection = new SqliteConnection(conBuilder.ConnectionString);
        }

        private void OpenConnection()
        {
            _connection.Open();
        }

        private void CloseConnection()
        {
            _connection.Close();
        }

        public int GetEmployeeSalary(int employeeID)
        {
            int retVal = 0;
            _connection.Open();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT Salary from SALARY where Employee_ID=" + employeeID + ";";
                var result = command.ExecuteReader();
                if (result.Read())
                    retVal = result.GetInt32(0);
            }
            _connection.Close();
            return retVal;
        }

        public IEnumerable<SALARY> ListAllSalaries()
        {
            IList<SALARY> salaryList = new List<SALARY>();

            _connection.Open();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT * from SALARY;";
                var result = command.ExecuteReader();
                while (result.Read())
                {
                    var objSalary = new SALARY { Employee_ID = result.GetInt32(0), Salary = result.GetInt32(1) };
                    salaryList.Add(objSalary);
                }
            }
            _connection.Close();
            return salaryList;
        }
    }
}
