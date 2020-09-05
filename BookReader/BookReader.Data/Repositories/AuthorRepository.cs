using BookReader.Data.Interfaces;
using BookReader.Data.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BookReader.Data.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        public void AddAuthor(Author author)
        {
            using (var context = new BookReaderDbContext())
            {
                context.Authors.Add(author);
                context.SaveChanges();
            }
        }

        public void DeleteAuthor(int id)
        {
            using (var context = new BookReaderDbContext())
            {
                var authorDelete = context.Authors.FirstOrDefault(a => a.Id == id);
                context.Authors.Remove(authorDelete);
                context.SaveChanges();
            }
        }

        public IList<Author> GetAllAuthors()
        {
            using (var context = new BookReaderDbContext())
            {
                var authors = context.Authors.Include(a => a.Books).ToList();

                return authors;
            }
        }

        public Author GetAuthorById(int id)
        {
            using (var context = new BookReaderDbContext())
            {
                var author = context.Authors.Include(a => a.Books).FirstOrDefault(a => a.Id == id);
                return author;
            }
        }
        
        public void UpdateAuthor(Author author)
        {
            using (var context = new BookReaderDbContext())
            {
                var currentAuthor = context.Authors.Include(g => g.Books).FirstOrDefault(a => a.Id == author.Id);

                currentAuthor.FirstName = author.FirstName;
                currentAuthor.LastName = author.LastName;

                context.SaveChanges();
            }
        }
        public Author GetAuthorByName(Author author)
        {
            using (var context = new BookReaderDbContext())
            {
                var currentAuthor = context.Authors.FirstOrDefault(a => a.FirstName == author.FirstName && a.LastName==author.LastName);
                return currentAuthor;
            }
        }
    }
}

