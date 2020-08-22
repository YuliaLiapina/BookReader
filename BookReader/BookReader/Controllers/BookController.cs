using AutoMapper;
using BookReader.Models;
using BookReaderManager.Business.Interfaces;
using BookReaderManager.Business.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BookReader.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;

        public BookController(IBookService bookManager, IMapper mapper, IGenreService genreService)
        {
            _bookService = bookManager;
            _genreService = genreService;
            _mapper = mapper;
        }
        // GET: Book
        public ActionResult Books()
        {
            var booksModel = _bookService.GetAllBooks();
            var books = _mapper.Map<IList<BookViewModel>>(booksModel);

            var booksSorted = books.OrderBy(b => b.Name).ToList();

            var getBooks = new GetBooksViewModel();
            getBooks.Books = booksSorted;

            return View(getBooks);
        }

        // GET: Book/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            var book = _bookService.GetBookById(id);
            var result = _mapper.Map<BookViewModel>(book);
            result.Body = _bookService.GetBookBody(book);

            return View("Details", result);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(CreateBookPostModel book)
        {
            var bookModel = _mapper.Map<BookModel>(book);
            _bookService.AddBook(bookModel);
            return View("Books");
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int? id)
        {
            var book = _bookService.GetBookById(id);
            var bookViewModel = _mapper.Map<BookViewModel>(book);
            var genresModel = _genreService.GetAll();
            var genresViewModel = _mapper.Map<IList<GenreViewModel>>(genresModel);

            var idBook = bookViewModel.Id;

            MultiSelectList genres = new MultiSelectList(genresViewModel, "Id", "Name"); 

            ViewBag.Genres = genres;           

            return View(bookViewModel);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(BookViewModel book, IList<GenreViewModel>genres)
        {
            foreach(var genre in genres)
            {
                book.Genres.Add(genre);
            }
            var bookModel = _mapper.Map<BookModel>(book);
            _bookService.UpdateBook(bookModel);

            return RedirectToAction("Books");
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            _bookService.DeleteBook(id);
            return RedirectToAction("Books","Book");
        }
    }
}
