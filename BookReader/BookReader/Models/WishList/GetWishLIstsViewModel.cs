using System.Collections.Generic;

namespace BookReader.Models.WishList
{
    public class GetWishListsViewModel
    {
        public IList<WishListViewModel> wishLists { get; set; }
    }
}