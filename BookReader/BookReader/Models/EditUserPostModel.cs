using System.ComponentModel.DataAnnotations;

namespace BookReader.Models
{
    public class EditUserPostModel
    {

        [Required]
        [Range(1, 100, ErrorMessage = "Недопустимый возраст")]
        public int Age { get; set; }

        [Required]
        [RegularExpression(@"^\+[1-9]\d{3}-\d{3}-\d{4}$", ErrorMessage = "Номер телефона должен иметь формат +xxxx-xxx-xxxx")]
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
    }
}