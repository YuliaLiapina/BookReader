﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookReader.Models
{
    public class ApplicationUserViewModel
    {
        public string Id { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public ICollection<WishListViewModel> WishLists { get; set; }
        public ICollection<BookViewModel> Books { get; set; }
    }
}