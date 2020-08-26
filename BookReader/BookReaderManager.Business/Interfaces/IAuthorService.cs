using BookReaderManager.Business.Models;
using System.Collections.Generic;

namespace BookReaderManager.Business.Interfaces
{
    public interface IAuthorService
    {
        IList<AuthorModel> GetAllAuthors();
        void AddAuthor(AuthorModel author);
        void DeleteAuthor(int? id);
        AuthorModel GetAuthorById(int? id);
        void UpdateAuthor(AuthorModel author);
    }
}
