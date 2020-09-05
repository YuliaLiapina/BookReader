using BookReader.Models.Book;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BookReader.Models
{
    public class EditBookPostModel
    {
        public int Id { get; set; }
        public BookPostModel Book { get; set; }
        public IList<int> GenresIds { get; set; }
        public IList<int> AuthorsIds { get; set; }
        public IEnumerable<SelectListItem> Genres { get; set; }
        public IEnumerable<SelectListItem> Authors { get; set; }
    }
}