using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookReader.Models
{
    public class CreateBookPostModel
    {
        public CreateBookPostModel()
        {
            Authors = new List<AuthorViewModel>();
            Genres = new List<GenreViewModel>();
        }
        public string Name { get; set; }
        public int Pages { get; set; }
        public string Annotation { get; set; }
        public string Cover { get; set; }
        public string Body { get; set; }
        public ICollection<AuthorViewModel> Authors { get; set; }

        public ICollection<GenreViewModel> Genres { get; set; }
    }
}