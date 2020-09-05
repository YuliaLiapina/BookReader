using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BookReader.Models
{
    
    public class CreateBookPostModel
    {
        [Required(ErrorMessage = "Поле должно быть установлено")]       
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Annotation { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Cover { get; set; }

        public IList<int> GenresIds { get; set; }
        public IList<int> AuthorsIds { get; set; }

        public IEnumerable<SelectListItem> Genres { get; set; }
        public IEnumerable<SelectListItem> Authors { get; set; }
    }
}