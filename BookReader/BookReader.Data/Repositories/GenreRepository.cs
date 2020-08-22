using BookReader.Data.Interfaces;
using BookReader.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookReader.Data.Repositories
{
    public class GenreRepository : IGenreRepository
    {

        IList<Genre> IGenreRepository.GetAll()
        {
            using(var context = new BookReaderDbContext())
            {
                var genres = context.Genres.ToList();
                return genres;
            }
        }
    }
}
