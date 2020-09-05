using System.Collections.Generic;

namespace BookReaderManager.Business.Models
{
    public class AuthorModel
    {
        public AuthorModel()
        {
            Books = new List<BookModel>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<BookModel> Books { get; set; }
    }
}
