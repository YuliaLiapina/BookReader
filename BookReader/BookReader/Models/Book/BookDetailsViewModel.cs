﻿using System.Collections.Generic;

namespace BookReader.Models.Book
{
    public class BookDetailsViewModel
    {
        public BookDetailsViewModel()
        {
           // Users = new List<ApplicationUserViewModel>();
            Authors = new List<AuthorViewModel>();
            Genres = new List<GenreViewModel>();
           // WishLists = new List<WishListViewModel>();
        }
        public int? Id { get; set; }
        public string Name { get; set; }
        public int Pages { get; set; }
        public string Annotation { get; set; }
        public string Cover { get; set; }
        public string Body { get; set; }

        //public ICollection<ApplicationUserViewModel> Users { get; set; }
        public IList<AuthorViewModel> Authors { get; set; }
        public ICollection<GenreViewModel> Genres { get; set; }
       // public ICollection<WishListViewModel> WishLists { get; set; }
        public ICollection<WishListViewModel> UserWishLists { get; set; }
    }
}