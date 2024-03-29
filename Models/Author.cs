﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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
