using AutoMapper;
using BookReader.Models;
using BookReader.Models.Book;
using BookReaderManager.Business.Interfaces;
using BookReaderManager.Business.Models;
using Microsoft.AspNet.Identity;
using PagedList;
using System.Collections.Generic;
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
        private readonly IWishListService _wishListService;
        private readonly IMapper _mapper;

        public BookController(IBookService bookManager, IGenreService genreService, IAuthorService authorServise, IMapper mapper, IWishListService wishListService)
        {
            _bookService = bookManager;
            _genreService = genreService;
            _authorServise = authorServise;
            _mapper = mapper;
            _wishListService = wishListService;
        }
        // GET: Book
        public ActionResult Books()
        {
            var booksModel = _bookService.GetAllBooks();
            var books = _mapper.Map<IList<BookViewModel>>(booksModel);

            var getBooks = new GetBooksViewModel();
            getBooks.Books = books;

            return View(getBooks);
        }

        // GET: Book/Details/5

        public ActionResult Details(int? id)
        {
            var book = _bookService.GetBookById(id);
            var result = _mapper.Map<BookViewModel>(book);

            var userId = User.Identity.GetUserId();
            var userWishLists = _wishListService.GetWishListsByUserId(userId);
            var userWishListsViewModel = _mapper.Map<IList<WishListViewModel>>(userWishLists);

            var model = _mapper.Map<BookDetailsViewModel>(result);

            //var model = new BookDetailsViewModel();
            model.UserWishLists = userWishListsViewModel;


            return View(model);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            var model = GetCreateBookPostModel();

            return View(model);
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateBookPostModel book, IEnumerable<HttpPostedFileBase> uploads)
        {
            if (ModelState.IsValid)
            {
                var pathBody = Server.MapPath("~/Content/Files/");
                var bookModel = _mapper.Map<BookModel>(book);

                var bookAddFiles = _bookService.AddLoadedFiles(bookModel, uploads, pathBody);
                var result = _bookService.AddNewGenresAndAuthors(bookAddFiles, book.GenresIds, book.AuthorsIds);

                _bookService.AddBook(result);

                return View(book);
            }

            //var book1 = _bookService.CheckLoadedFiles(bookModel, uploads);
            // var bookModel = _mapper.Map<BookModel>(book);
            var model = GetCreateBookPostModel();

            return View("Create", model);
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

            var pathBody = Server.MapPath("~/Content/Files/");
            var bookModel = _mapper.Map<BookModel>(bookEdit.Book);

            var bookAddFiles = _bookService.AddLoadedFiles(bookModel, uploads, pathBody);

            var result = _bookService.AddNewGenresAndAuthors(bookAddFiles, bookEdit.GenresIds, bookEdit.AuthorsIds);

            _bookService.UpdateBook(result);

            return RedirectToAction("Index", "Home");
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            _bookService.DeleteBook(id);

            return RedirectToAction("Books", "Book");
        }

        [Authorize]
        public ActionResult Reed(int? id, int? page)
        {
            var book = _bookService.GetBookById(id);
            var bookBody = _bookService.GetBookBody(book);
            //HttpContext.Request.Cookies.Get("Book" + id);
            var model = _mapper.Map<ReedBookViewModel>(book);

            int pageNumber = page ?? 1;

            var bodyPagging = bookBody.ToPagedList(pageNumber, 1);

            model.Pages = bodyPagging;

            return View(model);

            //var book = _bookService.GetBookById(id);          

            //var test = _bookService.GetBookBody(book);

            //int pageNumber = page ?? 1;

            //var temp = test.ToPagedList(pageNumber, 1);
            //return View(temp);
        }

        public ActionResult Search(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var book = _bookService.GetBooksByName(name);
                var booksViewModel = _mapper.Map<IList<BookViewModel>>(book);

                var model = new GetBooksViewModel();
                model.Books = booksViewModel;
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }

        private CreateBookPostModel GetCreateBookPostModel()
        {
            var genresModel = _genreService.GetAllGenres();
            var genresViewModel = _mapper.Map<IList<GenreViewModel>>(genresModel);

            var authorsModel = _authorServise.GetAllAuthors();
            var authorsViewModel = _mapper.Map<IList<AuthorViewModel>>(authorsModel);

            var model = new CreateBookPostModel
            {
                Genres = from genre in genresViewModel
                         select new SelectListItem { Text = genre.Name, Value = genre.Id.ToString() },
                Authors = from author in authorsViewModel
                          select new SelectListItem { Text = $"{author.FirstName} {author.LastName}", Value = author.Id.ToString() }
            };

            return model;
        }
    }
}

