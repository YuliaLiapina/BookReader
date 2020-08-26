using BookReader.Data.Models;
using System.Collections.Generic;

namespace BookReader.Data.Interfaces
{
    public interface IAuthorRepository
    {
        IList<Author> GetAllAuthors();
        void AddAuthor(Author author);
        void DeleteAuthor(int? id);
        Author GetAuthorById(int? id);
        void UpdateAuthor(Author author);
    }
}
