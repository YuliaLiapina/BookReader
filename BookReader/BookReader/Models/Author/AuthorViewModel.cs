using System.Collections.Generic;

namespace BookReader.Models
{
    public class AuthorViewModel
    {
        public AuthorViewModel()
        {
            Books = new List<BookViewModel>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<BookViewModel> Books { get; set; }
    }
}