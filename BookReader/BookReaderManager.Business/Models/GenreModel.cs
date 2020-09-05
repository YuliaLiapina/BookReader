using System.Collections.Generic;

namespace BookReaderManager.Business.Models
{
    public class GenreModel
    {
        public GenreModel()
        {
            Books = new List<BookModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<BookModel> Books { get; set; }
    }
}
