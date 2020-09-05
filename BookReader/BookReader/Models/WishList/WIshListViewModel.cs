using System.Collections.Generic;

namespace BookReader.Models
{
    public class WishListViewModel
    {
        public WishListViewModel()
        {
            Books = new List<BookViewModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<BookViewModel> Books { get; set; }
    }
}