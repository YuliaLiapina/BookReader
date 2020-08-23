using BookReader.Data.Models;
using System.Collections.Generic;

namespace BookReader.Data.Interfaces
{
    public interface IAuthorRepository
    {
        IList<Author> GetAll();
    }
}
