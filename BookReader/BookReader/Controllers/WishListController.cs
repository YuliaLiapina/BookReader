using AutoMapper;
using BookReader.Models;
using BookReader.Models.WishList;
using BookReaderManager.Business.Interfaces;
using BookReaderManager.Business.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BookReader.Controllers
{
    public class WishListController : Controller
    {
        private readonly IWishListService _wishListService;
        private readonly IMapper _mapper;

        public WishListController(IWishListService wishListService, IMapper mapper)
        {
            _wishListService = wishListService; 
            _mapper = mapper;
        }

        // GET: WishList
        [Authorize]
        public ActionResult Create()
        {
            var model = new CreateWishListPostModel();
            model.ReturnUrl = Request.UrlReferrer.ToString();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateWishListPostModel wishList)
        {
            if (ModelState.IsValid)
            {
                var currentWishList = _mapper.Map<WishListModel>(wishList);
                var id = User.Identity.GetUserId();
                currentWishList.UserId = id;
                _wishListService.AddWishList(currentWishList);

                return Redirect(wishList.ReturnUrl);
            }

            var model = new CreateWishListPostModel();
            model.ReturnUrl = wishList.ReturnUrl;

            return View("Create", model);
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

        public ActionResult Details(int id)
        {
            var wishList = _wishListService.GetWishListById(id);
            var model = _mapper.Map<WishListViewModel>(wishList);

            return View(model);
        }

        public ActionResult AddBookToWishList(int bookId, int wishListId)
        {
            _wishListService.AddBookToWishList(bookId, wishListId);
            var returnUrl = Request.UrlReferrer.ToString();

            return Redirect($"{returnUrl}");
        }


        public ActionResult DeleteBookFromWishList(int bookId, int wishListId)
        {
            _wishListService.DeleteBookFromWishList(bookId, wishListId);
            var returnUrl = Request.UrlReferrer.ToString();

            return Redirect($"{returnUrl}");
        }

        public ActionResult Edit(int id)
        {
            var wishList = _wishListService.GetWishListById(id);
            var model = _mapper.Map<EditWishListPostModel>(wishList);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditWishListPostModel wishList)
        {
            if (ModelState.IsValid)
            {
                var wishListModel = _mapper.Map<WishListModel>(wishList);
                _wishListService.UpdateWishList(wishListModel);

                return RedirectToAction("Details", new { id = wishList.Id });
            }

            var wishListEdit = _wishListService.GetWishListById(wishList.Id);
            var model = _mapper.Map<EditWishListPostModel>(wishListEdit);

            return View(model);
        }
        public ActionResult Delete(int id)
        {
            _wishListService.DeleteWishList(id);

            return RedirectToAction("WishLists");
        }
    }
}