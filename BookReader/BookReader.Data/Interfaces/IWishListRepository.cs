using BookReader.Data.Models;
using System.Collections.Generic;

namespace BookReader.Data.Interfaces
{
    public interface IWishListRepository
    {
        IList<WishList> GetAllWishLists();
        void AddWishList(WishList wishList);
        void DeleteWishList(int id);
        WishList GetWishListById(int id);
        void UpdateWishList(WishList wishList);
        IList<WishList> GetWishListsByUserId(string id);
        void DeleteBookFromWishList(Book book, int wishListId);
        void AddBookToWishList(Book book, int wishListId);
    }
}
