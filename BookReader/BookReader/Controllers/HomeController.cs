using AutoMapper;
using BookReader.Models;
using BookReaderManager.Business.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BookReader.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IGenreService _genreService;
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public HomeController(IBookService bookService, IMapper mapper, IGenreService genreService, IAuthorService authorService)
        {
            _bookService = bookService;
            _mapper = mapper;
            _genreService = genreService;
            _authorService = authorService;
        }
        public ActionResult Index()
        {
            var booksModel = _bookService.GetAllBooks();
            var books = _mapper.Map<IList<BookViewModel>>(booksModel);//маппер

            var genresModel = _genreService.GetAllGenres();
            var genres = _mapper.Map<IList<GenreViewModel>>(genresModel);

            var authorsModel = _authorService.GetAllAuthors();
            var authors = _mapper.Map <IList<AuthorViewModel>>(authorsModel);
            
            var model = new StartPageIndexViewModel();
            model.Books = books;
            model.Genres = genres;
            model.Authors = authors;

            return View(model);
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