using System.Collections.Generic;

namespace BookReader.Data.Models
{
    public class Book
    {
        public Book()
        {
            Users = new List<ApplicationUser>();
            Authors = new List<Author>();
            Genres = new List<Genre>();
            WishLists = new List<WishList>();
        }
        public int? Id { get; set; }
        public string Name { get; set; }
        public int Pages { get; set; }
        public string Annotation { get; set; }
        public string Cover { get; set; }
        public string Body { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }
        public ICollection<Author> Authors { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<WishList> WishLists { get; set; }
    }
}
