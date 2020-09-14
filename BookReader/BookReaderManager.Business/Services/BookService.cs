using AutoMapper;
using BookReader.Data.Interfaces;
using BookReader.Data.Models;
using BookReaderManager.Business.Interfaces;
using BookReaderManager.Business.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace BookReaderManager.Business.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
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
            var booksSorted = result.OrderBy(b => b.Name).ToList();

            return booksSorted;
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

        public List<string> GetBookBody(string bookfilePath)
        {
            string localPath = AppDomain.CurrentDomain.BaseDirectory;
            var strinBuilder = new StringBuilder();
            int count = 0;
            var listLines = new List<string>();
            string lineResult;
            int linesOnPage = 50;

            var lines = File.ReadAllLines($"{localPath}/{bookfilePath}");

            foreach (var line in lines)
            {
                if (count < linesOnPage)
                {
                    strinBuilder.Append(line);
                    strinBuilder.Append("<p>");
                    count++;
                }
                else
                {
                    lineResult = strinBuilder.ToString();
                    listLines.Add(lineResult);
                    count = 0;
                    strinBuilder.Clear();
                }
            }

            return listLines;
        }

        public BookModel AddNewGenresAndAuthors(BookModel book, IList<int> genresIds, IList<int> authorsIds)
        {
            if (genresIds != null)
            {
                foreach (var id in genresIds)
                {
                    book.Genres.Add(new GenreModel { Id = id });
                }
            }
            if (authorsIds != null)
            {
                foreach (var id in authorsIds)
                {
                    book.Authors.Add(new AuthorModel { Id = id });
                }
            }

            return book;
        }

        public BookModel AddLoadedFiles(BookModel book, IEnumerable<HttpPostedFileBase> uploads, string localPath)
        {
            foreach (var file in uploads)
            {
                if (file != null)
                {
                    string fileName = Path.GetFileName(file.FileName);
                 
                    var pathBody = localPath + fileName;
                    file.SaveAs(pathBody);

                    var textFile = file.ContentType;

                    if (textFile == "text/plain")
                    {
                        book.Body = "/Content/Files/" + fileName;
                    }
                    else
                    {
                        book.Cover = "/Content/Files/" + fileName;
                    }
                }
            }

            return book;
        }

        public IList<BookModel> GetBooksByName(string name)
        {
            var books = _bookRepository.GetAllBooks();
            List<Book> booksResult = new List<Book>();

            foreach (var book in books)
            {
                if (book.Name.ToLower().Contains(name.ToLower()))
                {
                    booksResult.Add(book);
                }
            }

            var booksModelResult = _mapper.Map<IList<BookModel>>(booksResult);

            return booksModelResult;
        }
    }
}
