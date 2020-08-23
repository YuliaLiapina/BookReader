using AutoMapper;
using BookReaderManager.Business.Interfaces;
using BookReaderManager.Business.Models;
using System;
using System.Collections.Generic;

namespace BookReaderManager.Business.Services
{
    public class AuthorService : IAuthorService
    {
        private protected IAuthorService _authorService;
        private protected IMapper _mapper;

        public AuthorService(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }
        public IList<AuthorModel> GetAllAuthors()
        {
            var authors = _authorService.GetAllAuthors();
            var authorsModel = _mapper.Map<IList<AuthorModel>>(authors);

            return authorsModel;
        }
    }
}
