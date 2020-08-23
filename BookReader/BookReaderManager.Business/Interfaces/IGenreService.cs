using BookReaderManager.Business.Models;
using System.Collections.Generic;

namespace BookReaderManager.Business.Interfaces
{
    public interface IGenreService
    {
        IEnumerable<GenreModel> GetAllGenres();
        void AddGenre(GenreModel genre);
        void DeleteGenre(int? id);
        GenreModel GetGenreById(int? id);
        void UpdateGenre(GenreModel genre);
    }
}
