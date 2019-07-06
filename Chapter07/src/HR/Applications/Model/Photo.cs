using System.ComponentModel.DataAnnotations;

namespace Applications.Model
{
    public class Photo
    {
        [Key]
        public int Employee_ID { get; set; }
        public byte[] Picture { get; set; }
    }
}
