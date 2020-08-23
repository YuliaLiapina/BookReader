using BookReader.Data.Interfaces;
using BookReader.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookReader.Data.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        public IList<Author> GetAll()
        {
            using(var context = new BookReaderDbContext())
            {
                var authors = context.Authors.ToList();

                return authors;
            }
        }
    }
}
