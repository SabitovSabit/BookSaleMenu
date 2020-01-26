using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _Lab_Library.Data.Entity
{
    public class AuthorBook
    {
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
    }
}
