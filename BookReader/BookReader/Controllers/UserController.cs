using AutoMapper;
using BookReader.Models;
using BookReaderManager.Business.Interfaces;
using BookReaderManager.Business.Models;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace BookReader.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userManager;
        private readonly IMapper _mapper;

        public UserController(IUserService userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        // GET: User
        public ActionResult UserInfo()
        {
            var id = User.Identity.GetUserId();
            var user = _userManager.GetUserById(id);
            var userViewModel = _mapper.Map<ApplicationUserViewModel>(user);
            return View(userViewModel);
        }

        public ActionResult Edit(string id)
        {

            var user = _userManager.GetUserById(id);
            var userViewModel = _mapper.Map<ApplicationUserViewModel>(user);

            return View(userViewModel);
        }
        [HttpPost]
        public ActionResult Edit(ApplicationUserViewModel user)
        {
            var userModel = _mapper.Map<ApplicationUserModel>(user);
            _userManager.EditUser(userModel);

            return RedirectToAction("Index","Home");
        }
    }
}