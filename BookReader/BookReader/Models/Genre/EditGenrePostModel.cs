using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookReader.Models
{
    public class EditGenrePostModel
    {
        public int Id { get; set; }

       [Required (ErrorMessage ="Поле должно быть установлено")]
       [RegularExpression(@"^[А-Я]+[а-яА-Я''-'\s]*$", ErrorMessage = "Формат ввода: кириллица с заглавной буквы")]
        public string Name { get; set; }
    }
}