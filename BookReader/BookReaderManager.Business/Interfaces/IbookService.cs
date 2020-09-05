using BookReaderManager.Business.Models;
using System.Collections.Generic;
using System.Web;

namespace BookReaderManager.Business.Interfaces
{
    public interface IBookService
    {
        IList<BookModel> GetAllBooks();
        void AddBook(BookModel book);
        void DeleteBook(int id);
        BookModel GetBookById(int id);
        void UpdateBook(BookModel book);
        List<string> /*void */GetBookBody(string bookfilePath);
        BookModel AddNewGenresAndAuthors(BookModel book, IList<int> genresIds, IList<int> authorsIds);
        BookModel AddLoadedFiles(BookModel book, IEnumerable<HttpPostedFileBase> uploads, string localPath);
        IList<BookModel> GetBooksByName(string name);
    }
}
