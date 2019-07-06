using System.ComponentModel.DataAnnotations;

namespace Applications.Model
{
    public class Document
    {
        [Key]
        public int Employee_ID { get; set; }
        public int DOC_ID { get; set; }
        public byte[] DocData { get; set; }
        public string FileName { get; set; }
    }
}
