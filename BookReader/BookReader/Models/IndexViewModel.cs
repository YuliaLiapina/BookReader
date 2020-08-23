using System.Collections.Generic;

namespace BookReader.Models
{
    public class IndexViewModel
    {
        public IList<BookViewModel> Books { get; set; }
        public IList<GenreViewModel> Genres { get; set; }
    }
}