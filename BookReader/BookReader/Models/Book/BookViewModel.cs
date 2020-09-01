using PagedList;
using System.Collections.Generic;

namespace BookReader.Models
{
    public class BookViewModel
    {
        public BookViewModel()
        {
            Users = new List<ApplicationUserViewModel>();
            Authors = new List<AuthorViewModel>();
            Genres = new List<GenreViewModel>();
            WishLists = new List<WishListViewModel>();
        }
        public int? Id { get; set; }
        public string Name { get; set; }
       // public int Pages { get; set; }
        public string Annotation { get; set; }
        public string Cover { get; set; }
        public string Body { get; set; }
        //public List<string> Test { get; set; }
        //public int? PageCount { get; set; }
        //public int? PageNumber { get; set; }
        //public IPagedList pages { get; set; }

        public ICollection<ApplicationUserViewModel> Users { get; set; }
        public IList<AuthorViewModel> Authors { get; set; }
        public ICollection<GenreViewModel> Genres { get; set; }
        public ICollection<WishListViewModel> WishLists { get; set; }

    }
}