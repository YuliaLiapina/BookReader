using BookReader.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReader.Data.Interfaces
{
    public interface IBookRepository
    {
        IList<Book> GetAllBooks();
        void AddBook(Book book);
        void DeleteBook(int id);
        Book GetBookById(int id);
        void UpdateBook(Book book);
    }
}
