using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Unilib.DatabaseUtil;
using System.Linq;
using System.Collections.Generic;

namespace Unilib.Models
{
    [Table("authors")]
    public class Author
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Biography { get; set; }
    }
}
