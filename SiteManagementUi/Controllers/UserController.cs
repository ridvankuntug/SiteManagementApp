using Microsoft.AspNetCore.Mvc;
using SiteManagementUi.Models.UserModels;
using SiteManagementUi.Services;
using System.Collections.Generic;

namespace SiteManagementUi.Controllers
{
    public class UserController : Controller
    {
        public IActionResult GetAllUser()
        {
            List<GetUserModel> userModel = UserService.GetAllUsers();
            return View(userModel);
        }
        [Route("EditUser/{id}")]
        public IActionResult EditUser(int id)
        {
            GetUserModel userModel = UserService.GetUser(id);
            return View(userModel);
        }
    }
}
