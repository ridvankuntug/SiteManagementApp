using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SiteManagementUi.Entities;
using SiteManagementUi.Services;
using System.Collections.Generic;
using System.Linq;

namespace SiteManagementUi.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            List<string> bag = new List<string>();
            UserService.GetAllUsers().ToList().ForEach(p => bag.Add($"{p.Id} {p.UserName} {p.Role}"));
            ViewBag.Title = "Index";
            ViewBag.Message = bag;


            return View();

        }
    }
}
