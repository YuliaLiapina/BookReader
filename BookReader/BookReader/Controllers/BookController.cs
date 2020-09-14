using AutoMapper;
using BookReader.Models;
using BookReader.Models.Book;
using BookReaderManager.Business.Interfaces;
using BookReaderManager.Business.Models;
using Microsoft.AspNet.Identity;
using PagedList;
using System;
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
        [Authorize(Roles = "Admin")]
        public ActionResult Books()
        {
            var booksModel = _bookService.GetAllBooks();
            var books = _mapper.Map<IList<BookViewModel>>(booksModel);

            var getBooks = new GetBooksViewModel();
            getBooks.Books = books;

            return View(getBooks);
        }

        // GET: Book/Details/5

        public ActionResult Details(int id)
        {
            var book = _bookService.GetBookById(id);
            var result = _mapper.Map<BookViewModel>(book);

            var userId = User.Identity.GetUserId();
            var userWishLists = _wishListService.GetWishListsByUserId(userId);
            var userWishListsViewModel = _mapper.Map<IList<WishListViewModel>>(userWishLists);

            var model = _mapper.Map<BookDetailsViewModel>(result);
            model.UserWishLists = userWishListsViewModel;

            return View(model);
        }

        // GET: Book/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            var model = GetCreateBookPostModel();

            return View(model);
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(CreateBookPostModel book, IEnumerable<HttpPostedFileBase> uploads)
        {
            if (ModelState.IsValid && uploads != null&&book.AuthorsIds!=null&&book.GenresIds!=null)
            {
                var pathBody = Server.MapPath("~/Content/Files/");
                var bookModel = _mapper.Map<BookModel>(book);

                var bookAddFiles = _bookService.AddLoadedFiles(bookModel, uploads, pathBody);
                var result = _bookService.AddNewGenresAndAuthors(bookAddFiles, book.GenresIds, book.AuthorsIds);

                _bookService.AddBook(result);

                return RedirectToAction("Books", "Book");
            }

            var model = GetCreateBookPostModel();

            return View("Create", model);
        }

        // GET: Book/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var model=GetEditBookPostModel(id);

            return View(model);
        }


        // POST: Book/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(EditBookPostModel bookEdit, IEnumerable<HttpPostedFileBase> uploads)
        {
            if(ModelState.IsValid)
            {                
                var pathBody = Server.MapPath("~/Content/Files/");
                var bookModel = _mapper.Map<BookModel>(bookEdit.Book);

                var bookAddFiles = _bookService.AddLoadedFiles(bookModel, uploads, pathBody);
                var result = _bookService.AddNewGenresAndAuthors(bookAddFiles, bookEdit.GenresIds, bookEdit.AuthorsIds);

                _bookService.UpdateBook(result);

                return RedirectToAction("Books", "Book");
            }
            var model = GetEditBookPostModel(bookEdit.Id);

            return View("Edit", model);
        }

        // GET: Book/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            _bookService.DeleteBook(id);

            return RedirectToAction("Books", "Book");
        }

        [Authorize]
        public ActionResult Reed(int id, int? page)
        {
            var book = _bookService.GetBookById(id);
            var idUser= User.Identity.GetUserId();

            HttpCookie cookieRequest = HttpContext.Request.Cookies.Get($"Book{id}{idUser}");

            if (page.HasValue||cookieRequest==null)
            {
                int pageNumber = page ?? 1;

                var bookBody = _bookService.GetBookBody(book.Body);

                var model = _mapper.Map<ReedBookViewModel>(book);

                var bodyPagging = bookBody.ToPagedList(pageNumber, 1);

                model.Pages = bodyPagging;

                var userId= User.Identity.GetUserId();
                HttpCookie cookie = new HttpCookie($"Book{id}{userId}", $"{pageNumber}");
                cookie.Expires = DateTime.Now.AddDays(2);
                Response.Cookies.Add(cookie);

                return View(model);
            }

                var getBookBody = _bookService.GetBookBody(book.Body);
                var getModel = _mapper.Map<ReedBookViewModel>(book);

                var cookiesPage = cookieRequest.Value;
                var currentPage = int.Parse(cookiesPage);
                var bodyPaggingCookies = getBookBody.ToPagedList(currentPage, 1);

                getModel.Pages = bodyPaggingCookies;

                return View(getModel);
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

        private EditBookPostModel GetEditBookPostModel(int id)
        {
            var book = _bookService.GetBookById(id);
            var bookPostModel = _mapper.Map<BookPostModel>(book);
            
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

            model.Book = bookPostModel;

            return model;
        }
    }
}

