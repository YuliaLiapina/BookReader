using System.ComponentModel.DataAnnotations;

namespace BookReader.Models.WishList
{
    public class CreateWishListPostModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Name { get; set; }
        public string ReturnUrl { get; set; }
    }
}