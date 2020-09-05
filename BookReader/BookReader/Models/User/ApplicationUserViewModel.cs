using System;
using System.Collections.Generic;

namespace BookReader.Models
{
    public class ApplicationUserViewModel
    {
        public ApplicationUserViewModel()
        {
            WishLists = new List<WishListViewModel>();
            Books = new List<BookViewModel>();
        }
        public string Id { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }      
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public ICollection<WishListViewModel> WishLists { get; set; }
        public ICollection<BookViewModel> Books { get; set; }
    }
}