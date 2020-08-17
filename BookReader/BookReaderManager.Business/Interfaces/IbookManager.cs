using BookReaderManager.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReaderManager.Business.Interfaces
{
    public interface IbookManager
    {
        IList<BookModel> GetAllBooks();
        void AddBook(BookModel book);
        void DeleteBook(int? id);
        BookModel GetBookById(int? id);
        void UpdateBook(BookModel book);
    }
}
