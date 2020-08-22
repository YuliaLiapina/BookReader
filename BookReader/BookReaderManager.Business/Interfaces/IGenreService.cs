using BookReaderManager.Business.Models;
using System.Collections.Generic;

namespace BookReaderManager.Business.Interfaces
{
    public interface IGenreService
    {
        IList<GenreModel> GetAll();
    }
}
