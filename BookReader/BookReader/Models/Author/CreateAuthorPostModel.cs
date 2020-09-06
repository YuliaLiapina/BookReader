using System.ComponentModel.DataAnnotations;

namespace BookReader.Models
{
    public class CreateAuthorPostModel
    {
        [Required(ErrorMessage ="Поле должно быть установлено")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "Недопустимый формат")]
        public string FirstName{get;set;}


        [Required(ErrorMessage = "Поле должно быть установлено")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "Недопустимый формат")]
        public string LastName { get; set; }
    }
}