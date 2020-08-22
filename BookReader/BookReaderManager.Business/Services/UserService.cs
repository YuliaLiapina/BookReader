using AutoMapper;
using BookReader.Data.Interfaces;
using BookReader.Data.Models;
using BookReaderManager.Business.Interfaces;
using BookReaderManager.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using System.Web.UI.DataVisualization.Charting;

namespace BookReaderManager.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public void Edit(ApplicationUserModel user)
        {
            var userModel = _mapper.Map<ApplicationUser>(user);
            _userRepository.Edit(userModel);
        }

        public IList<ApplicationUserModel> GetAllUsers()
        {
            var users = _userRepository.GetAll();
            var usersModel = _mapper.Map<IList<ApplicationUserModel>>(users);

            return usersModel;
        }

        public ApplicationUserModel GetUserById(string id)
        {
            var user = _userRepository.GetUserById(id);

            var userModel = _mapper.Map<ApplicationUserModel>(user);
            return userModel;
        }

        public System.Web.Helpers.Chart GetChartStatistics()
        {
            var temp = new List<string>();
            var listUsers = new List<string>();
            var listDates = new List<string>();

            var users = _userRepository.GetAll();
            var usersModel = _mapper.Map<IList<ApplicationUserModel>>(users);

            foreach (var item in usersModel)
            {
                if (item.RegistrationDate != null)
                {
                    var itemString = item.RegistrationDate.Value.Date.ToString();
                    temp.Add(itemString);
                }
                listDates = temp.Distinct().ToList();
            }

            foreach (var item in temp.Distinct())
            {
                var itemString2 = temp.Where(b => b == item).Count().ToString();
                listUsers.Add(itemString2);
            }
            var myChart = new System.Web.Helpers.Chart(width: 400, height: 200, theme: ChartTheme.Green)
                   .AddTitle("Statistics")
                   .AddSeries(
                       name: "Statistics",                       
                       chartType: "Column",
                       xValue: listDates,
                       xField: "Date",
                   yValues: listUsers,
                   yFields: "CountUsers");

              return myChart;
        }
    }
}
