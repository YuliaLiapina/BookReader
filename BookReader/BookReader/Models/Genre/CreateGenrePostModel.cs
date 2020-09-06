using System.ComponentModel.DataAnnotations;

namespace BookReader.Models
{
    public class CreateGenrePostModel
    {
        [Required (ErrorMessage ="Поле должно быть установлено")]
        [RegularExpression(@"^[А-Я]+[а-яА-Я''-'\s]*$", ErrorMessage = "Недопустимый формат")]
        public string Name { get; set; }
    }
}