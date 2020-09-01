using AutoMapper;
using BookReader.Models;
using BookReader.Models.Book;
using BookReader.Models.WishList;
using BookReaderManager.Business.Interfaces;
using BookReaderManager.Business.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookReader.Controllers
{
    public class WishListController : Controller
    {
        private readonly IWishListService _wishListService;
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public WishListController(IWishListService wishListService, IBookService bookService, IMapper mapper)
        {
            _wishListService = wishListService;
            _bookService = bookService;
            _mapper = mapper;
        }

        // GET: WishList
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateWishListPostModel wishList)
        {
            var currentWishList = _mapper.Map<WishListModel>(wishList);
            var id = User.Identity.GetUserId();
            currentWishList.UserId = id;
            _wishListService.AddWishList(currentWishList);

            return RedirectToAction("WishLists"); //Исправить
        }

        public ActionResult WishLists()
        {
            var id = User.Identity.GetUserId();

            var wishLists = _wishListService.GetWishListsByUserId(id);
            var wishListsViewModel = _mapper.Map<IList<WishListViewModel>>(wishLists);

            var model = new GetWishListsViewModel();
            model.wishLists = wishListsViewModel;

            return View(model);
        }

        public ActionResult Details (int? id)
        {
            var wishList = _wishListService.GetWishListById(id);
            var model = _mapper.Map<WishListViewModel>(wishList);

            return View(model);
        }
                
        //public ActionResult AddBookToWishList(int? bookId, int? wishListId)        
        //{
        //    var id = User.Identity.GetUserId();
        //    var wishLists = _wishListService.GetWishListsByUserId(id);
        //    var currentWish = wishLists.FirstOrDefault(w => w.Id == wishListId);

        //    if(!currentWish.Books.Any(b=>b.Id==bookId))
        //    {
        //        _wishListService.AddBookToWishList(bookId, wishListId);
        //        return RedirectToAction("Details", "Book", new { id = bookId });
        //    }

        //    return 
        //}

               
        public ActionResult DeleteBookFromWishList(int? bookId, int? wishListId)
        {
            _wishListService.DeleteBookFromWishList(bookId, wishListId);

            return RedirectToAction("Details", "WishList", new { id = wishListId });
        }

        public ActionResult Edit(int? id)
        {
            var wishList = _wishListService.GetWishListById(id);
            var model = _mapper.Map<EditWishListPostModel>(wishList);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditWishListPostModel wishList)
        {
            var wishListModel = _mapper.Map<WishListModel>(wishList);
            _wishListService.UpdateWishList(wishListModel);

            return RedirectToAction("Details", new { id = wishList.Id });
        }
        public ActionResult Delete(int? id)
        {
            _wishListService.DeleteWishList(id);

            return RedirectToAction("WishLists");
        }
    }
}