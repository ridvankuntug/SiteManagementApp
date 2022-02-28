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

        public IActionResult AddUser(ChangeUserModel userModel)
        {
            if (userModel.UserName is null) { return View(); }
            UserService.PostUser(userModel);
            return View();
        }

        public IActionResult EditUser(int id)
        {
            //TODO: AutoMapper kullan
            GetUserModel userModel = UserService.GetUser(id);
            ChangeUserModel changeUserModel = new ChangeUserModel();
            changeUserModel.Id = userModel.Id;
            changeUserModel.UserName = userModel.UserName;
            changeUserModel.UserFullName = userModel.UserFullName;
            changeUserModel.UserTc = userModel.UserTc;
            changeUserModel.Email = userModel.Email;
            changeUserModel.PhoneNumber = userModel.PhoneNumber;
            changeUserModel.UserVehicle = userModel.UserVehicle;
            changeUserModel.PasswordHash = "";
            changeUserModel.IsAdmin = userModel.IsAdmin;
            
            return View(changeUserModel);
        }
        [HttpPost]
        public IActionResult EditUser(ChangeUserModel userModel)
        {
            UserService.PutUser(userModel.Id, userModel);
            return View();
        }
    }
}
