using System.ComponentModel.DataAnnotations;

namespace BookReader.Models
{
    public class CreateGenrePostModel
    {
        [Required (ErrorMessage ="Поле должно быть установлено")]
        public string Name { get; set; }
    }
}