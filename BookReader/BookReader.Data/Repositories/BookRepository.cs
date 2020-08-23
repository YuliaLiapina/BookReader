using BookReader.Data.Interfaces;
using BookReader.Data.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BookReader.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        public void AddBook(Book book)
        {
            using(var context = new BookReaderDbContext())
            {
                context.Books.Add(book);
                context.SaveChanges();
            }
        }

        public void DeleteBook(int? id)
        {
            using(var context = new BookReaderDbContext())
            {
                var bookDelete = context.Books.FirstOrDefault(b => b.Id == id);
                context.Books.Remove(bookDelete);
                context.SaveChanges();
            }
        }

        public IList<Book> GetAllBooks()
        {
            using(var context = new BookReaderDbContext())
            {
                var books = context.Books.Include(b => b.Authors).Include(b => b.Genres).ToList();
                return books;
            }
        }

        public Book GetBookById(int? id)
        {
            using (var context = new BookReaderDbContext())
            {
                var book = context.Books.Include(b=>b.Authors).Include(b=>b.Genres).FirstOrDefault(b => b.Id == id);
                return book;
            }
        }

        public void UpdateBook(Book book)
        {
            using(var context = new BookReaderDbContext())
            {
                var currentBook = context.Books.Include(b=>b.Genres).FirstOrDefault(b => b.Id == book.Id);
                
                if (currentBook == null)
                {
                    context.Books.Add(book);
                }

                else
                {
                    foreach (var genre in book.Genres)
                    {
                        var selectedGenre = context.Genres.FirstOrDefault(g => g.Id == genre.Id);
                        if (selectedGenre != null && currentBook.Genres.All(g => g.Id != selectedGenre.Id))
                        {
                            currentBook.Genres.Add(selectedGenre);
                        }
                    };

                    context.Books.Attach(currentBook);
                    context.Entry(currentBook).State = EntityState.Modified;
                }

                context.SaveChanges();
            }
        }
    }
}
