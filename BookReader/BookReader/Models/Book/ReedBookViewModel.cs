using PagedList;
using System.Collections.Generic;

namespace BookReader.Models.Book
{
    public class ReedBookViewModel
    {
        public ReedBookViewModel()
        {
            Authors = new List<AuthorViewModel>();
            Genres = new List<GenreViewModel>();
        }
        public IPagedList<string> Pages { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Annotation { get; set; }
        public string Cover { get; set; }
        public IList<AuthorViewModel> Authors { get; set; }
        public ICollection<GenreViewModel> Genres { get; set; }
    }
}