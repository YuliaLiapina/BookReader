using BookReader.Data.Models;
using System.Collections.Generic;

namespace BookReader.Data.Interfaces
{
    public interface IUserRepository
    {
        IList<ApplicationUser> GetAll();
        void Edit(ApplicationUser user);
        ApplicationUser GetUserById(string id);
    }
}
