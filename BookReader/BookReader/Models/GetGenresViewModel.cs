using System.Collections.Generic;

namespace BookReader.Models
{
    public class GetGenresViewModel
    {
        public IList<GenreViewModel> Genres { get; set; }
    }
}