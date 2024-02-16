using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unilib.Models
{
    [Table("book_student")]
    public class BookStudent
    {
        [Key]
        public int Id { get; set; }
        public string ISBN { get; set; }
        public int Student_id { get; set; }
        public DateOnly Borrowing_Date { get; set; }
        public DateOnly? Return_Date { get; set; }
        public int? Fine {  get; set; }
    }
}
