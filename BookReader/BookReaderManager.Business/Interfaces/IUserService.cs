﻿using BookReaderManager.Business.Models;
using System.Collections.Generic;
using System.Web.Helpers;

namespace BookReaderManager.Business.Interfaces
{
    public interface IUserService
    {
        IList<ApplicationUserModel> GetAllUsers();
        void EditUser(ApplicationUserModel user);
        ApplicationUserModel GetUserById(string id);
        Chart GetUsersChartStatistics();
    }
}
