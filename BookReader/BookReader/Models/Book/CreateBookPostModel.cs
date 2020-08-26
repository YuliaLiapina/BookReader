using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookReader.Models
{
    public class CreateBookPostModel
    {
        public CreateBookPostModel()
        {
            Authors = new List<AuthorViewModel>();
            Genres = new List<GenreViewModel>();
        }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        //public int Pages { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Аннотация")]
        public string Annotation { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Обложка")]
        public string Cover { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Кника")]
        public string Body { get; set; }
                
        public List<int> GenresIds { get; set; }
        public List<int> AuthorsIds { get; set; }
        public AuthorViewModel NewAuthor { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Автор/Авторы")]
        public ICollection<AuthorViewModel> Authors { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Жанр/Жанры")]
        public ICollection<GenreViewModel> Genres { get; set; }
    }
}