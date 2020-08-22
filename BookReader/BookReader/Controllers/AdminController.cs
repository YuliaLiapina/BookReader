using AutoMapper;
using BookReader.Models;
using BookReaderManager.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.DataVisualization.Charting;

namespace BookReader.Controllers
{
    public class AdminController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public AdminController(IBookService bookService, IMapper mapper, IUserService userService)
        {
            _bookService = bookService;
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
            var chart = _userService.GetChartStatistics();

            var chartStatisticsModel = new ChartStatisticsViewModel();
            chartStatisticsModel.statistics = chart;

            return View(chartStatisticsModel);
        }

    }
}