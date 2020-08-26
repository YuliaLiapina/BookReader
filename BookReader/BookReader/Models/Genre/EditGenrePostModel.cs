using BookReaderManager.Business.Models;
using System.Collections.Generic;

namespace BookReader.Models
{
    public class EditGenrePostModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }

        public IList<BookViewModel> Books { get; set; }
    }
}