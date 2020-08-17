using System.Collections.Generic;

namespace BookReaderManager.Business.Models
{
    public class WishListModel
    {
        public WishListModel()
        {
            Books = new List<BookModel>();
        }
        public int? Id { get; set; }
        public string Name { get; set; }

        public string UserId { get; set; }
        public ApplicationUserModel User { get; set; }

        public ICollection<BookModel> Books { get; set; }
    }
}
