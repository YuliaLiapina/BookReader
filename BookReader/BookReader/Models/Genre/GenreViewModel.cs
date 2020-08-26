using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookReader.Models
{
    public class GenreViewModel
    {
        public GenreViewModel()
        {
            Books = new List<BookViewModel>();
        }
        public int? Id { get; set; }
        public string Name { get; set; }

        public ICollection<BookViewModel> Books { get; set; }
    }
}