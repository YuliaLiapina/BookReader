using BookReader.Models.Author;
using BookReader.Models.Genre;
using BookReader.Models.WishList;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookReader.Models.Book
{
    public class BookPostModel
    {
        public BookPostModel()
        {
            Authors = new List<AuthorPostModel>();
            Genres = new List<GenrePostModel>();
            WishLists = new List<WishListPostModel>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage ="Поле должно быть установлено")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Annotation { get; set; }
        public string Cover { get; set; }
        public string Body { get; set; }

        public IList<AuthorPostModel> Authors { get; set; }
        public ICollection<GenrePostModel> Genres { get; set; }
        public ICollection<WishListPostModel> WishLists { get; set; }
    }
}