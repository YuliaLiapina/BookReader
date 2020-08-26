using AutoMapper;
using BookReader.Models;
using BookReaderManager.Business.Interfaces;
using BookReaderManager.Business.Models;
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

        public ActionResult Create ()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateGenrePostModel genre)
        {
            var genreModel = _mapper.Map<GenreModel>(genre);
            _genreService.AddGenre(genreModel);

            return RedirectToAction("Genres");
        }

        public ActionResult Edit(int? id)
        {
            var genre = _genreService.GetGenreById(id);
            var model = _mapper.Map<EditGenrePostModel>(genre);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditGenrePostModel genreEdit)
        {
            var genre = _mapper.Map<GenreModel>(genreEdit);

            _genreService.UpdateGenre(genre);

            return RedirectToAction("Genres");
        }

        public ActionResult Details(int? id)
        {
            var genre = _genreService.GetGenreById(id);
            var genreViewModel = _mapper.Map<GenreViewModel>(genre);

            return View(genreViewModel);
        }
    }
}
