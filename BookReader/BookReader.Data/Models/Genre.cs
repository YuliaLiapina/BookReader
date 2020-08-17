using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class Genre
    {
        public Genre()
        {
            Books = new List<Book>();
        }
        public int? Id { get; set; }
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
