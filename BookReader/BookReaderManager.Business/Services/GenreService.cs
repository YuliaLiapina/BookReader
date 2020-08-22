using AutoMapper;
using BookReader.Data.Interfaces;
using BookReaderManager.Business.Interfaces;
using BookReaderManager.Business.Models;
using System;
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

        public IList<GenreModel> GetAll()
        {
            var genres = _genreRepository.GetAll();
            var result = _mapper.Map<IList<GenreModel>>(genres);

            return result;
        }
    }
}
