using BookReader.Data.Interfaces;
using BookReader.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace BookReader.Data.Repositories
{
    public class UserRepository:IUserRepository
    {
        public IList<ApplicationUser>GetAll()
        {
            using (var context = new BookReaderDbContext())
            {
                var users = context.Users.ToList();
                return users;
            }
        }

        public void Edit (ApplicationUser user)
        {
            using (var context = new BookReaderDbContext())
            {
                var currentUser = context.Users.FirstOrDefault(u => u.Id == user.Id);
                currentUser.UserName = user.UserName;
                currentUser.Age = user.Age;
                currentUser.PhoneNumber = user.PhoneNumber;

                context.Users.AddOrUpdate(currentUser);
                context.SaveChanges();
            }
        }

        public ApplicationUser GetUserById(string id)
        {
            using(var context = new BookReaderDbContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Id == id);
                return user;
            }
        }
    }
}
