using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReaderManager.Business.Models
{
    public class WishListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string UserId { get; set; }
        public ApplicationUserModel User { get; set; }

        public ICollection<BookModel> Books { get; set; }
    }
}
