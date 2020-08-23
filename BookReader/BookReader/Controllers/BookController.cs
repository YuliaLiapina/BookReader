using AutoMapper;
using BookReader.Models;
using BookReaderManager.Business.Interfaces;
using BookReaderManager.Business.Models;
using System.Collections;
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

        public BookController(IBookService bookManager, IGenreService genreService, IMapper mapper)
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

            //ViewBag.Genres = new MultiSelectList(_genreService.GetAllGenres(), "Id", "Name", book.Genres.Select(g => g.Id));

            var genresModel = _genreService.GetAllGenres();
            var genresViewModel = _mapper.Map<IList<GenreViewModel>>(genresModel);

            var model = new EditBookPostModel
            {
                Genres = from genre in genresViewModel
                         select new SelectListItem { Text = genre.Name, Value = genre.Id.ToString() }
            };

            model.Book = bookViewModel;

            return View(model);
        }


        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(EditBookPostModel bookEdit/*BookViewModel bookEdit*/)
        {
            
            foreach(var id in bookEdit.SelectedIds)
            {
                bookEdit.Book.Genres.Add(new GenreViewModel { Id = id });
            }

            var book = _mapper.Map<BookModel>(bookEdit.Book);
            _bookService.UpdateBook(book);

            //var genresModel = _genreService.GetAllGenres();
            //var genresViewModel = _mapper.Map<IList<GenreViewModel>>(genresModel);


            ////var book = _bookService.GetBookById(bookEdit.Book.Id);
            ////var bookViewModel = _mapper.Map<BookViewModel>(book);

            //if (bookEdit.SelectedIds != null)
            //{
            //    for (int i = 0; i < bookEdit.SelectedIds.Count; i++)
            //    {
            //        var genreToAdd = genresViewModel.FirstOrDefault(g => g.Id == bookEdit.SelectedIds[i]);
            //        bookEdit.Book.Genres.Add(genreToAdd);
            //    }
            //}
            
            //var bookModel = _mapper.Map<BookModel>(bookEdit.Book);
            //_bookService.UpdateBook(bookModel);

            return RedirectToAction("Index", "Home");
            //if (bookEdit.SelectedIds != null)
            //{
            //    for (int i = 0; i < bookEdit.SelectedIds.Count; i++)
            //    {
            //        var genreToAdd = genresViewModel.FirstOrDefault(g => g.Id == bookEdit.SelectedIds[i]);
            //        bookViewModel.Genres.Add(genreToAdd);
            //    }
            //}
            //ICollection<GenreViewModel> res = bookViewModel.Genres.GroupBy(x => x.Id).Select(x => x.FirstOrDefault()).ToList();
            //bookViewModel.Genres = res;
            //var bookModel = _mapper.Map<BookModel>(bookViewModel);
            //_bookService.UpdateBook(bookModel);


        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            _bookService.DeleteBook(id);
            return RedirectToAction("Books", "Book");
        }
    }
}

