using BookReader.Data.Interfaces;
using BookReader.Data.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace BookReader.Data.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        public void AddGenre(Genre genre)
        {
            using (var context = new BookReaderDbContext())
            {
                context.Genres.Add(genre);
                context.SaveChanges();
            }
        }

        public void DeleteGenre(int? id)
        {
            using (var context = new BookReaderDbContext())
            {
                var genreDelete = context.Genres.FirstOrDefault(g => g.Id == id);
                context.Genres.Remove(genreDelete);
                context.SaveChanges();
            }
        }

        public Genre GetGenreById(int? id)
        {
            using (var context = new BookReaderDbContext())
            {
                var genre = context.Genres.Include(g=>g.Books).FirstOrDefault(b => b.Id == id);
                return genre;
            }
        }

        public void UpdateGenre(Genre genre)
        {
            using (var context = new BookReaderDbContext())
            {
                var currentGenre = context.Genres.Include(g => g.Books).FirstOrDefault(g => g.Id == genre.Id);

                currentGenre.Name = genre.Name;
                currentGenre.Books = genre.Books;

                context.Genres.AddOrUpdate(currentGenre);
                context.SaveChanges();
            }
        }

        IList<Genre> IGenreRepository.GetAllGenres()
        {
            using(var context = new BookReaderDbContext())
            {
                var genres = context.Genres.Include(g => g.Books).ToList();
                return genres;
            }
        }
    }
}
