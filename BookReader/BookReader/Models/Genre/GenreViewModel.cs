using System.Collections.Generic;

namespace BookReader.Models
{
    public class GenreViewModel
    {
        public GenreViewModel()
        {
            Books = new List<BookViewModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<BookViewModel> Books { get; set; }
    }
}