using AutoMapper;
using BookReader.Models;
using BookReaderManager.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookReader.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public HomeController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }
        public ActionResult Index()
        {
            var booksModel = _bookService.GetAllBooks();
            var books = _mapper.Map<IList<BookViewModel>>(booksModel);

            var booksSorted = books.OrderBy(b => b.Name).ToList();

            var getBooks = new GetBooksViewModel();
            getBooks.Books = booksSorted;
            return View(getBooks);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}