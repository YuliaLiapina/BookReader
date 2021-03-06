﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReaderManager.Business.Models
{
   public class ApplicationUserModel
    {
        public ApplicationUserModel()
        {
            WishLists = new List<WishListModel>();
            Books = new List<BookModel>();
        }
        public string Id { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public ICollection<WishListModel> WishLists { get; set; }
        public ICollection<BookModel> Books { get; set; }
    }
}
