using AutoMapper;
using BookReader.Models;
using BookReaderManager.Business.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BookReader.Controllers
{
    public class BookController : Controller
    {
        private readonly IbookManager _bookManager;
        private readonly IMapper _mapper;

        public BookController(IbookManager bookManager, IMapper mapper)
        {
            _bookManager = bookManager;
            _mapper = mapper;
        }
        // GET: Book
        public ActionResult Books()
        {
            var booksModel = _bookManager.GetAllBooks();
            var booksViewModel = _mapper.Map<IList<BookViewModel>>(booksModel);
            var books = new GetBooksViewModel();
            books.Books = booksViewModel;

            return View("Books",books);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
