using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Unilib.Models
{
    [Table("book_author")]
    public class BookAuthor
    {
        [Key]
        public int Id { get; set; }
        public string ISBN { get; set; }
        public int Author_id { get; set; }
    }
}
