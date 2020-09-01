using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BookReader.Models
{
    
    public class CreateBookPostModel
    {
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(30)]
        public string Name { get; set; }

        ////public int Pages { get; set; }
        
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Annotation { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Cover { get; set; }

        public IList<int> GenresIds { get; set; }
        public IList<int> AuthorsIds { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public IEnumerable<SelectListItem> Genres { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public IEnumerable<SelectListItem> Authors { get; set; }
    }
}