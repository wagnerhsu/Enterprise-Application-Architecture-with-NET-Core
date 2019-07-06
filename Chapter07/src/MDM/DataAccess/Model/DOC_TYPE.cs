using System.ComponentModel.DataAnnotations;

namespace DataAccess.Model
{
    public class DOC_TYPE
    {
        [Key]
        public int DOC_ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
