using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

namespace Applications.Model
{
    public class Employee
    {
        [Key]
        public int Employee_ID { get; set; }
        public string FamilyName { get; set; }
        public string FirstName { get; set; }
        public DateTime DOB { get; set; }
        public string Grade { get; set; }
        public DateTime PPT_Issue_Date { get; set; }
        public DateTime PPT_Expiry_Date { get; set; }
    }
}
