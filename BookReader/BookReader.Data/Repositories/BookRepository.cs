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
                book.Genres = book.Genres.Select(bookGenre => context.Genres.First(genre => genre.Id == bookGenre.Id)).ToList();
                book.Authors = book.Authors.Select(bookAuthor => context.Authors.First(author => author.Id == bookAuthor.Id)).ToList(); 
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
                var currentBook = context.Books.Include(b=>b.Genres).Include(b=>b.Authors).FirstOrDefault(b => b.Id == book.Id);
                
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

                    foreach(var author in book.Authors)
                    {
                        var selectedAuthor = context.Authors.FirstOrDefault(a => a.Id == author.Id);
                        if(selectedAuthor!=null && currentBook.Authors.All(a=>a.Id!=selectedAuthor.Id))
                        {
                            currentBook.Authors.Add(selectedAuthor);
                        }
                    }

                    currentBook.Name = book.Name;
                    currentBook.Annotation = book.Annotation;
                    currentBook.Cover = book.Cover;
                    currentBook.Body = book.Body;
                    
                    context.Books.Attach(currentBook);
                    context.Entry(currentBook).State = EntityState.Modified;
                }

                context.SaveChanges();
            }
        }

        //public Book GetBookByName(string name)
        //{
        //    using(var context = new BookReaderDbContext())
        //    {
        //        var book = context.Books.FirstOrDefault(b => b.Name == name);

        //        return book;
        //    }
        //}
    }
}
