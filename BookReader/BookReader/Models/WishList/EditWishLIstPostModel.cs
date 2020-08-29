using System.Collections.Generic;

namespace BookReader.Models.WishList
{
    public class EditWishListPostModel
    {
        public EditWishListPostModel()
        {
            Books = new List<BookViewModel>();
        }
        public int? Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public ApplicationUserViewModel User { get; set; }

        public ICollection<BookViewModel> Books { get; set; }
    }
}