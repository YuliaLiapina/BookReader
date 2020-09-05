using System.Collections.Generic;

namespace BookReaderManager.Business.Models
{
    public class BookModel
    {
        public BookModel()
        {
            Users = new List<ApplicationUserModel>();
            Authors = new List<AuthorModel>();
            Genres = new List<GenreModel>();
            WishLists = new List<WishListModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
       // public int Pages { get; set; }
        public string Annotation { get; set; }
        public string Cover { get; set; }
        public string Body { get; set; }

        public ICollection<ApplicationUserModel> Users { get; set; }

        public ICollection<AuthorModel> Authors { get; set; }

        public ICollection<GenreModel> Genres { get; set; }

        public ICollection<WishListModel> WishLists { get; set; }
    }
}
