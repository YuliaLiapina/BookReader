using System.Collections.Generic;

namespace BookReader.Models
{
    public class GetUsersViewModel
    {
        public IList<ApplicationUserViewModel> Users { get; set; }
    }
}