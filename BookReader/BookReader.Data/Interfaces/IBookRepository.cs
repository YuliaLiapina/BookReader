using BookReader.Data.Models;
using System.Collections.Generic;

namespace BookReader.Data.Interfaces
{
    public interface IBookRepository
    {
        IList<Book> GetAllBooks();
        void AddBook(Book book);
        void DeleteBook(int id);
        Book GetBookById(int id);
        void UpdateBook(Book book);
        //Book GetBookByName(string name);
    }
}
