using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookReader.Models
{
    public class EditGenrePostModel
    {
        public int Id { get; set; }

       [Required (ErrorMessage ="Поле должно быть установлено")]
        public string Name { get; set; }
    }
}