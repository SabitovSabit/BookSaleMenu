using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _Lab_Library.Data.Entity
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:50,MinimumLength =3)]
        public string Name { get; set; }
        public ICollection<AuthorBook> AuthorBooks { get; set; }
        public ICollection<BookLanguage> BookLanguages { get; set; }
        public Book()
        {
            AuthorBooks = new HashSet<AuthorBook>();
            BookLanguages = new HashSet<BookLanguage>();
        }

    }
}
