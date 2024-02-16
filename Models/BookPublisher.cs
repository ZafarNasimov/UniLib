using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Unilib.Models
{
    [Table("book_publisher")]
    public class BookPublisher
    {
        [Key]
        public string ISBN { get; set; }
        public int Publisher_id { get; set; }
    }
}
