using Microsoft.AspNetCore.Mvc;

namespace CPT231_Assignment06_LeviNoell_Baba.Areas.Help.Controllers
{
    [Area("Help")]//Defining area to Help
    public class HelpController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Help()
        {
            return RedirectToAction("Index", "Home", new {area = ""} );
        }

        public IActionResult Rule(int ruleNumber) //Action used to return the specified rule view page
        {
            string ruleViewName = "Rule" + ruleNumber; //set ruleViewName equal to Rule + specified ruleNumber
            return View(ruleViewName); //return the specified rule page
        }
        
    }
}
