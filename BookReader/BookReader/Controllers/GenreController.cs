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
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;

        public GenreController(IGenreService genreService, IMapper mapper)
        {
            _genreService = genreService;
            _mapper = mapper;
        }
        // GET: Genre
        public ActionResult Genres()
        {
            var genres = _genreService.GetAllGenres();
            var genresViewModel = _mapper.Map<IList<GenreViewModel>>(genres);

            var result = new GetGenresViewModel();
            result.Genres = genresViewModel;

            return View(result);
        }

        public ActionResult Delete(int? id)
        {
            _genreService.DeleteGenre(id);

            return RedirectToAction("Genres");
        }

       
    }
}
