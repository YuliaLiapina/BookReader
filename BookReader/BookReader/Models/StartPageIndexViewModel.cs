using Microsoft.AspNet.Identity;
using System.Collections.Generic;

namespace BookReader.Models
{
    public class StartPageIndexViewModel
    {
        public IList<BookViewModel> Books { get; set; }
        public IList<GenreViewModel> Genres { get; set; }
        public IList<AuthorViewModel> Authors { get; set; }

    }
}