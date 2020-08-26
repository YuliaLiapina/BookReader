using AutoMapper;
using BookReader.Models;
using BookReaderManager.Business.Interfaces;
using BookReaderManager.Business.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookReader.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IGenreService _genreService;
        private readonly IAuthorService _authorServise;
        private readonly IMapper _mapper;

        public BookController(IBookService bookManager, IGenreService genreService, IAuthorService authorServise, IMapper mapper)
        {
            _bookService = bookManager;
            _genreService = genreService;
            _authorServise = authorServise;
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
            //result.Body = _bookService.GetBookBody(book);

            return View("Details", result);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            ViewBag.Genres = new MultiSelectList(_genreService.GetAllGenres(), "Id", "Name");
            ViewBag.Authors = new MultiSelectList(_authorServise.GetAllAuthors(), "Id", "LastName");

            //    var genresModel = _genreService.GetAllGenres();
            //    var genresViewModel = _mapper.Map<IList<GenreViewModel>>(genresModel);

            //    var authorsModel = _authorServise.GetAllAuthors();
            //    var authorsViewModel = _mapper.Map<IList<AuthorViewModel>>(authorsModel);

            //    var model = new CreateBookPostModel
            //    {
            //        Genres = from genre in genresViewModel
            //                 select new SelectListItem { Text = genre.Name, Value = genre.Id.ToString() },
            //        Authors = from author in authorsViewModel
            //                  select new SelectListItem { Text = $"{author.FirstName} {author.LastName}", Value = author.Id.ToString() }
            //    };

            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(CreateBookPostModel book, IEnumerable<HttpPostedFileBase> uploads)
        {
            //if (ModelState.IsValid)
            //{
                var pathBody = Server.MapPath("~/Content/Files/");
                var bookModel = _mapper.Map<BookModel>(book);

                var bookAddFiles = _bookService.AddLoadedFiles(bookModel, uploads, pathBody);
                var result = _bookService.AddNewGenresAndAuthors(bookAddFiles, book.GenresIds, book.AuthorsIds);

                _bookService.AddBook(result);

                return RedirectToAction("Index", "Home");
            //}
          
            //var book1 = _bookService.CheckLoadedFiles(bookModel, uploads);
            // var bookModel = _mapper.Map<BookModel>(book);

            //return RedirectToAction("Create");

        }

        // GET: Book/Edit/5
        public ActionResult Edit(int? id)
        {
            var book = _bookService.GetBookById(id);
            var bookViewModel = _mapper.Map<BookViewModel>(book);

            var genresModel = _genreService.GetAllGenres();
            var genresViewModel = _mapper.Map<IList<GenreViewModel>>(genresModel);

            var authorsModel = _authorServise.GetAllAuthors();
            var authorsViewModel = _mapper.Map<IList<AuthorViewModel>>(authorsModel);

            var model = new EditBookPostModel
            {
                Genres = from genre in genresViewModel
                         select new SelectListItem { Text = genre.Name, Value = genre.Id.ToString() },
                Authors = from author in authorsViewModel
                          select new SelectListItem { Text = $"{author.FirstName} {author.LastName}", Value = author.Id.ToString() }
            };

            model.Book = bookViewModel;

            return View(model);
        }


        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(EditBookPostModel bookEdit, IEnumerable<HttpPostedFileBase> uploads)
        {

            var bookModel = _mapper.Map<BookModel>(bookEdit.Book);

            var result = _bookService.AddNewGenresAndAuthors(bookModel, bookEdit.GenresIds, bookEdit.AuthorsIds);

            _bookService.UpdateBook(result);

            return RedirectToAction("Index", "Home");
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            _bookService.DeleteBook(id);
            return RedirectToAction("Books", "Book");
        }

        public ActionResult Reed(int? id)
        {
            var book = _bookService.GetBookById(id);
            var result = _mapper.Map<BookViewModel>(book);
            result.Body = _bookService.GetBookBody(book);

            return View(result);
        }
    }
}

