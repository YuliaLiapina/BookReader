using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
   public class Book
    {
        public int Id { get; set; }
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
