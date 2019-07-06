using System.ComponentModel.DataAnnotations;

namespace Applications.Model
{
    /// <summary>
    /// This class is used for document identification purpose
    /// </summary>
    public class DocumentIdentifier
    {
        [Key]
        public int Employee_ID { get; set; }
        [Key]
        public int DOC_ID { get; set; }
    }
}
