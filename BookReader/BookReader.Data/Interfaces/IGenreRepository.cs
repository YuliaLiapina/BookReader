using BookReader.Data.Models;
using System.Collections.Generic;

namespace BookReader.Data.Interfaces
{
    public interface IGenreRepository
    {
        IList<Genre> GetAllGenres();
        void AddGenre(Genre genre);
        void DeleteGenre(int? id);
        Genre GetGenreById(int? id);
        void UpdateGenre(Genre genre);
    }
}
