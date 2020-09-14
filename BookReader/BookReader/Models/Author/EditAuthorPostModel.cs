using System.ComponentModel.DataAnnotations;

namespace BookReader.Models
{
    public class EditAuthorPostModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Поле должно быть установлено")]
        [RegularExpression(@"^[А-Я]+[а-яА-Я''-'\s]*$", ErrorMessage = "Формат ввода: кириллица с заглавной буквы")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [RegularExpression(@"^[А-Я]+[а-яА-Я''-'\s]*$", ErrorMessage = "Формат ввода: кириллица с заглавной буквы")]
        public string LastName { get; set; }
    }
}