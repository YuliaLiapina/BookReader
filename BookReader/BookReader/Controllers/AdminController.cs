using AutoMapper;
using BookReader.Models;
using BookReaderManager.Business.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BookReader.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public AdminController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        // GET: Admin
        public ActionResult AdminPanel()
        {
            return View();
        }

        public ActionResult UsersInfo()
        {
            var users = _userService.GetAllUsers();
            var usersMapp = _mapper.Map<IList<ApplicationUserViewModel>>(users);

            var listUsers = new GetUsersViewModel();
            listUsers.Users = usersMapp;

            return View(listUsers);
        }
        public ActionResult Statistics()
        {
            return View();
        }     

        public ActionResult ChartArrayBasic()
        {
            var chart = _userService.GetUsersChartStatistics();

            var chartStatisticsModel = new ChartStatisticsViewModel();
            chartStatisticsModel.statistics = chart;

            return View(chartStatisticsModel);
        }

    }
}