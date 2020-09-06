using System.ComponentModel.DataAnnotations;

namespace BookReader.Models
{
    public class EditUserPostModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Возраст")]
        [Range(1, 100, ErrorMessage = "Недопустимый возраст")]
        public int Age { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Телефон")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Недопустимый формат, введите телефон в формате xxxxxxxxxx")]
        public string PhoneNumber { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Недопустимая длина имени")]
        public string UserName { get; set; }

    }
}