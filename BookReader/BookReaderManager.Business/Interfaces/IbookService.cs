using BookReaderManager.Business.Models;
using System.Collections.Generic;
using System.Web;

namespace BookReaderManager.Business.Interfaces
{
    public interface IBookService
    {
        IList<BookModel> GetAllBooks();
        void AddBook(BookModel book);
        void DeleteBook(int? id);
        BookModel GetBookById(int? id);
        void UpdateBook(BookModel book);
        string GetBookBody(BookModel book);
        BookModel AddNewGenresAndAuthors(BookModel book, IList<int> genresIds, IList<int> authorsIds);
        BookModel AddLoadedFiles(BookModel book, IEnumerable<HttpPostedFileBase> uploads, string localPath);
    }
}
