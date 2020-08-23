using BookReaderManager.Business.Models;
using System.Collections.Generic;

namespace BookReaderManager.Business.Interfaces
{
    public interface IAuthorService
    {
        IList<AuthorModel> GetAllAuthors();
    }
}
