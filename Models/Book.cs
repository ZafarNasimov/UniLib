using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Unilib.Models
{
    [Table("books")]
    public class Book
    {
        [Key]
        public string ISBN { get; set; }
        public string Title { get; set; }
        public DateOnly? Publication_Date { get; set; }
        public string? Genre { get; set; }

    }
}
