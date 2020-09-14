using System.ComponentModel.DataAnnotations;

namespace BookReader.Models
{
    public class CreateGenrePostModel
    {
        [Required (ErrorMessage ="Поле должно быть установлено")]
        [RegularExpression(@"^[А-Я]+[а-яА-Я''-'\s]*$", ErrorMessage = "Формат ввода: кириллица с заглавной буквы")]
        public string Name { get; set; }
    }
}