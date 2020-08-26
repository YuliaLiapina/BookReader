using AutoMapper;
using BookReaderManager.Business.Interfaces;
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
        private readonly IMapper _mapper;

        public WishListController(IWishListService wishListService, IMapper mapper)
        {
            _wishListService = wishListService;
            _mapper = mapper;
        }

        // GET: WishList
        public ActionResult Index()
        {
            return View();
        }
    }
}