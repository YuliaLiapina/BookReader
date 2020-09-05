using BookReader.Models.Book;
using System.Collections.Generic;

namespace BookReader.Models.Genre
{
    public class GenrePostModel
    {
        public GenrePostModel()
        {
            Books = new List<BookPostModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<BookPostModel> Books { get; set; }
    }
}