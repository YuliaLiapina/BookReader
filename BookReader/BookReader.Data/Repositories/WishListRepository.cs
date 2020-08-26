﻿using BookReader.Data.Interfaces;
using BookReader.Data.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BookReader.Data.Repositories
{
    public class WishListRepository : IWishListRepository
    {
        public void AddWishList(WishList wishList)
        {
            using (var context = new BookReaderDbContext())
            {
                context.WishLists.Add(wishList);
                context.SaveChanges();
            }
        }

        public void DeleteWishList(int? id)
        {
            using (var context = new BookReaderDbContext())
            {
                var wishListDelete = context.WishLists.FirstOrDefault(w => w.Id == id);
                context.WishLists.Remove(wishListDelete);
                context.SaveChanges();
            }
        }

        public IList<WishList> GetAllWishLists()
        {
            using (var context = new BookReaderDbContext())
            {
                var wishLists = context.WishLists.Include(w => w.Books).ToList();

                return wishLists;
            }
        }

        public WishList GetWishListById(int? id)
        {
            using (var context = new BookReaderDbContext())
            {
                var wishList = context.WishLists.Include(w => w.Books).FirstOrDefault(w => w.Id == id);
                return wishList;
            }
        }

        public void UpdateWishList(WishList wishList)
        {
            using (var context = new BookReaderDbContext())
            {
                var currentWishList = context.WishLists.Include(w => w.Books).FirstOrDefault(w => w.Id == wishList.Id);

                currentWishList.Name = wishList.Name;

                context.SaveChanges();
            }
        }
    }
}
