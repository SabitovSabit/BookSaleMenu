using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _Lab_Library.Data.Entity
{
    public class BookLanguage
    {
        public Book Book { get; set; }
        public int BookId { get; set; }
        public Language Language { get; set; }
        public int LanguageId { get; set; }
    }
}
