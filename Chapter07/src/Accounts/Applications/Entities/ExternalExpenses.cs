using System;
using System.ComponentModel.DataAnnotations;

namespace HIJI.SOA.Accounts.Applications.Entities
{
    public class ExternalExpenses
    {
        [Key]
        public int Employee_ID { get; set; }
        public int AmountInUSD { get; set; }
        public int ApprovalRequired { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime ApprovedAt { get; set; }
    }
}
