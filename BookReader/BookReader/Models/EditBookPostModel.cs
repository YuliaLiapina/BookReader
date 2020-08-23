using System.Collections.Generic;
using System.Web.Mvc;

namespace BookReader.Models
{
    public class EditBookPostModel
    {
        public BookViewModel Book { get; set; }
        public IList<int> SelectedIds { get; set; }
        public IEnumerable<SelectListItem> Genres { get; set; }
    }
}