using System.ComponentModel.DataAnnotations;

namespace HIJI.SOA.Accounts.Applications.Entities
{
    public class SALARY
    {
        [Key]
        public int Employee_ID { get; set; }
        public int Salary { get; set; }
    }
}
