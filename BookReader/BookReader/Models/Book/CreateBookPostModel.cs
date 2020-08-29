using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BookReader.Models
{
    public class CreateBookPostModel
    {
        
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        ////public int Pages { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Аннотация")]
        public string Annotation { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Обложка")]
        public string Cover { get; set; }
        public IList<int> GenresIds { get; set; }
        public IList<int> AuthorsIds { get; set; }
        public IEnumerable<SelectListItem> Genres { get; set; }
        public IEnumerable<SelectListItem> Authors { get; set; }
    }
}