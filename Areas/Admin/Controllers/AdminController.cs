using CPT231_Assignment06_LeviNoell_Baba.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CPT231_Assignment06_LeviNoell_Baba.Areas.Admin.Controllers //Changed namespace to refer to area Admin
{
    //controller for handling admin actions within the admin area
    [Authorize(Roles = "Admin")]//requires users to be in the admin role to access actions in this controller
    [Area("Admin")] //specifying the area the controller applies to
    public class AdminController : Controller
    {
        //action method for the index page of the admin area
        [Route("[area]/[controller]/[action]")] //defining a route for the index action
        public IActionResult Index()
        {
            return View();
        }
        //action method for handling cancellation within the admin area
        [Route("[area]/[controller]/[action]")] //defining a route for the cancel action
        public IActionResult Cancel()
        {
            return RedirectToAction("Index", "Home", new { area = "", controller = "Home" }); //redirecting to specified location not in an area
        }

    }
}
