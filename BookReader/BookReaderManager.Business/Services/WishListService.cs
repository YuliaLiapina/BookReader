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

        public WishListService(IWishListRepository wishListRepository, IMapper mapper)
        {
            _wishListRepository = wishListRepository;
            _mapper = mapper;
        }

        public void AddWishList(WishListModel wishList)
        {
            var mappedWishlist = _mapper.Map<WishList>(wishList);
            _wishListRepository.AddWishList(mappedWishlist);
        }

        public void DeleteWishList(int? id)
        {
            _wishListRepository.DeleteWishList(id);
        }

        public IList<WishListModel> GetAllWishLists()
        {
            var wishLists = _wishListRepository.GetAllWishLists();
            var wishListsModel = _mapper.Map<IList<WishListModel>>(wishLists);

            return wishListsModel;
        }

        public WishListModel GetWishListById(int? id)
        {
            var wishList = _wishListRepository.GetWishListById(id);
            var wishListModel = _mapper.Map<WishListModel>(wishList);

            return wishListModel;
        }

        public void UpdateWishList(WishListModel wishList)
        {
            var currentWishLIst = _mapper.Map<WishList>(wishList);
            _wishListRepository.UpdateWishList(currentWishLIst);
        }
    }
}
