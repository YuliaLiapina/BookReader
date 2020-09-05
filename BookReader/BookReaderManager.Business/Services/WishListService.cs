using AutoMapper;
using BookReader.Data.Interfaces;
using BookReader.Data.Models;
using BookReaderManager.Business.Interfaces;
using BookReaderManager.Business.Models;
using System;
using System.Collections.Generic;

namespace BookReaderManager.Business.Services
{
    public class WishListService : IWishListService
    {
        private readonly IWishListRepository _wishListRepository;
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;

        public WishListService(IWishListRepository wishListRepository, IMapper mapper, IBookRepository bookRepository)
        {
            _wishListRepository = wishListRepository;
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public void AddWishList(WishListModel wishList)
        {
            var mappedWishlist = _mapper.Map<WishList>(wishList);
            _wishListRepository.AddWishList(mappedWishlist);
        }

        public void DeleteBookFromWishList(int bookId, int wishListId)
        {
            var book = _bookRepository.GetBookById(bookId);
            _wishListRepository.DeleteBookFromWishList(book, wishListId);
        }
        public void AddBookToWishList(int bookId, int wishListId)
        {
            var book = _bookRepository.GetBookById(bookId);
            _wishListRepository.AddBookToWishList(book, wishListId);
        }

        public void DeleteWishList(int id)
        {
            _wishListRepository.DeleteWishList(id);
        }

        public IList<WishListModel> GetAllWishLists()
        {
            var wishLists = _wishListRepository.GetAllWishLists();
            var wishListsModel = _mapper.Map<IList<WishListModel>>(wishLists);

            return wishListsModel;
        }

        public WishListModel GetWishListById(int id)
        {
            var wishList = _wishListRepository.GetWishListById(id);
            var wishListModel = _mapper.Map<WishListModel>(wishList);

            return wishListModel;
        }

        public IList<WishListModel> GetWishListsByUserId(string id)
        {
            var wishLists = _wishListRepository.GetWishListsByUserId(id);
            var wishListsViewModel = _mapper.Map<IList<WishListModel>>(wishLists);

            return wishListsViewModel;
        }

        public void UpdateWishList(WishListModel wishList)
        {
            var currentWishLIst = _mapper.Map<WishList>(wishList);
            _wishListRepository.UpdateWishList(currentWishLIst);
        }

    }
}
