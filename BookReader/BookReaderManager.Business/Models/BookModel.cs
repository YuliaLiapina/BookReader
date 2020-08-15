using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReaderManager.Business.Models
{
   public class BookModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Pages { get; set; }
        public string Annotation { get; set; }
        public string Cover { get; set; }
        public string Body { get; set; }

        public ICollection<ApplicationUserModel> Users { get; set; }

        public ICollection<AuthorModel> Authors { get; set; }

        public ICollection<GenreModel> Genres { get; set; }

        public ICollection<WishListModel> WishLists { get; set; }
    }
}
