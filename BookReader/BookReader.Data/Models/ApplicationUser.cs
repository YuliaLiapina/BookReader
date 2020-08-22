using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class ApplicationUser: IdentityUser
    {
        public ApplicationUser()
        {
            WishLists = new List<WishList>();
            Books = new List<Book>();
        }
        public int Age { get; set; }
        public DateTime? RegistrationDate { get; set; }

        public ICollection<WishList> WishLists { get; set; }
        public ICollection<Book> Books { get; set; }
        
            public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
            {
                // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
                var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
                // Add custom user claims here
                return userIdentity;
            }

        
    }
}
