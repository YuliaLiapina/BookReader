using BookReaderManager.Business.Models;
using System.Collections.Generic;

namespace BookReaderManager.Business.Interfaces
{
    public interface IWishListService
    {
        IList<WishListModel> GetAllWishLists();
        void AddWishList(WishListModel wishList);
        void DeleteWishList(int? id);
        WishListModel GetWishListById(int? id);
        void UpdateWishList(WishListModel wishList);
        IList<WishListModel> GetWishListsByUserId(string id);
        void DeleteBookFromWishList(int? bookId, int? wishListId);
        void AddBookToWishList(int? bookId, int? wishListId);
    }
}
