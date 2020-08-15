using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookReader.Models
{
    public class WishListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string UserId { get; set; }
        public ApplicationUserViewModel User { get; set; }

        public ICollection<BookViewModel> Books { get; set; }
    }
}