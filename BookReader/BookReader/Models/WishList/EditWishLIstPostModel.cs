using System.ComponentModel.DataAnnotations;

namespace BookReader.Models.WishList
{
    public class EditWishListPostModel
     {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Name { get; set; }
    }
}