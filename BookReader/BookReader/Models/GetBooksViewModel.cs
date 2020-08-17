using System.Collections.Generic;

namespace BookReader.Models
{
    public class GetBooksViewModel
    {
        public IList<BookViewModel> Books { get; set; }
    }
}