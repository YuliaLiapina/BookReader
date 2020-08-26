using AutoMapper;
using BookReader.Data.Interfaces;
using BookReader.Data.Models;
using BookReaderManager.Business.Interfaces;
using BookReaderManager.Business.Models;
using System.Collections.Generic;

namespace BookReaderManager.Business.Services
{
    public class AuthorService : IAuthorService
    {
        private protected IAuthorRepository _authorRepository;
        private protected IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public void AddAuthor(AuthorModel author)
        {
            var mappedAuthor = _mapper.Map<Author>(author);
            _authorRepository.AddAuthor(mappedAuthor);
        }

        public void DeleteAuthor(int? id)
        {
            _authorRepository.DeleteAuthor(id);
        }

        public IList<AuthorModel> GetAllAuthors()
        {
            var authors = _authorRepository.GetAllAuthors();
            var authorsModel = _mapper.Map<IList<AuthorModel>>(authors);

            return authorsModel;
        }

        public AuthorModel GetAuthorById(int? id)
        {
            var author = _authorRepository.GetAuthorById(id);
            var authorModel = _mapper.Map<AuthorModel>(author);

            return authorModel;
        }

        public void UpdateAuthor(AuthorModel author)
        {
            var currentAuthor = _mapper.Map<Author>(author);
            _authorRepository.UpdateAuthor(currentAuthor);
        }
    }
}
