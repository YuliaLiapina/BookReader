using BookReader.Models.Book;
using System.Collections.Generic;

namespace BookReader.Models.Author
{
    public class AuthorPostModel
    {
        public AuthorPostModel()
        {
            Books = new List<BookPostModel>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<BookPostModel> Books { get; set; }
    }
}