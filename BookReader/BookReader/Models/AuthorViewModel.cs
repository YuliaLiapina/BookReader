using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookReader.Models
{
    public class AuthorViewModel
    {
        public AuthorViewModel()
        {
            Books = new List<BookViewModel>();
        }
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<BookViewModel> Books { get; set; }
    }
}