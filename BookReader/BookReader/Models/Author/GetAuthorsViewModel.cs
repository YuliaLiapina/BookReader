using System.Collections.Generic;

namespace BookReader.Models
{
    public class GetAuthorsViewModel
    {
        public IList<AuthorViewModel> Authors { get; set; }
    }
}