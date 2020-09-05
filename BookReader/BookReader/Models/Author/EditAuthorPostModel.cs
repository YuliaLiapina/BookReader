using System.ComponentModel.DataAnnotations;

namespace BookReader.Models
{
    public class EditAuthorPostModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Поле должно быть установлено")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string LastName { get; set; }
    }
}