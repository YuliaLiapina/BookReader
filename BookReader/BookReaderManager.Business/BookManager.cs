using AutoMapper;
using BookReader.Data.Interfaces;
using BookReader.Data.Models;
using BookReaderManager.Business.Interfaces;
using BookReaderManager.Business.Models;
using System.Collections.Generic;

namespace BookReaderManager.Business
{
    public class BookManager:IbookManager
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookManager(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public void AddBook(BookModel book)
        {
            var mappedBook = _mapper.Map<Book>(book);
            _bookRepository.AddBook(mappedBook);
        }

        public void DeleteBook(int id)
        {
            _bookRepository.DeleteBook(id);
        }

        public IList<BookModel> GetAllBooks()
        {
            var books = _bookRepository.GetAllBooks();
            var result = _mapper.Map<IList<BookModel>>(books);

            return result;
        }

        public BookModel GetBookById(int id)
        {
            var book = _bookRepository.GetBookById(id);
            var bookModel = _mapper.Map<BookModel>(book);

            return bookModel;
        }

        public void UpdateBook(BookModel book)
        {
            var currentBook = _mapper.Map<Book>(book);
            _bookRepository.UpdateBook(currentBook);
        }
    }
}
