using AutoMapper;
using BookReader.Data.Interfaces;
using BookReader.Data.Models;
using BookReaderManager.Business.Interfaces;
using BookReaderManager.Business.Models;
using System.Collections.Generic;

namespace BookReaderManager.Business.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public void AddGenre(GenreModel genre)
        {
            var mappedGenre = _mapper.Map<Genre>(genre);
            _genreRepository.AddGenre(mappedGenre);
        }

        public void DeleteGenre(int? id)
        {
            _genreRepository.DeleteGenre(id);
        }

        public IEnumerable<GenreModel> GetAllGenres()
        {
            var genres = _genreRepository.GetAllGenres();
            var result = _mapper.Map<IList<GenreModel>>(genres);

            return result;
        }

        public GenreModel GetGenreById(int? id)
        {
            var genre = _genreRepository.GetGenreById(id);
            var genreModel = _mapper.Map<GenreModel>(genre);

            return genreModel;
        }

        public void UpdateGenre(GenreModel genre)
        {
            var currentGenre = _mapper.Map<Genre>(genre);
            _genreRepository.UpdateGenre(currentGenre);
        }
    }
}
