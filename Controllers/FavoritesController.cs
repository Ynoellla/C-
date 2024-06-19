//Levi Noell-Baba
//CPT 231-W17
//Assignment 10
//April 9, 2024
//cookies and sessions used as in NFLTeams example to create a favorite list.
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CPT231_Assignment06_LeviNoell_Baba.Models;

namespace CPT231_Assignment06_LeviNoell_Baba.Controllers
{
    public class FavoritesController : Controller
    {
        private NoellBabaContext context;
        public FavoritesController(NoellBabaContext ctx) => context = ctx;

        [HttpGet]
        public ViewResult Index()
        {
            MagicSession session = new MagicSession(HttpContext.Session); //create new MagicSession session if not already available
            MagicsViewModel model = new MagicsViewModel
            {
                Magics = session.GetMyMagics()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Magic magic)
        {
            // Retrieve the Magic object from the database
            magic = context.Magics
                .Where(m => m.MagicId == magic.MagicId)
                .FirstOrDefault(m => m.MagicId == magic.MagicId);
             var session = new MagicSession(HttpContext.Session); //creates new MagicSession if not available
             var cookies = new MagicCookies(Response.Cookies); //Creates new MagicCookies if not already created
             var magics = session.GetMyMagics();
            if (magics.Any(m => m.MagicId == magic.MagicId))//check if the card is already in the favorites list and display tempdata message if it is
            {
                TempData["message"] = $"{magic.CardName} is already in your favorites!";
                return RedirectToAction("Index", "Home");
            }
            if (magics.Where(m => m.MagicId == magic.MagicId).FirstOrDefault() == null)//adds the card if not already in the list and displays tempdata message
            {
                magics.Add(magic);
                session.SetMyMagics(magics);
                cookies.SetMyMagicIds(magics);
                TempData["message"] = $"{magic.CardName} Has been added to your favorites!";
            }
            return RedirectToAction("Index", "Home");//return to home page
        }


        [HttpGet]
        public IActionResult Delete()//delete action method
        {
            // delete favorite teams from session and cookie
            var session = new MagicSession(HttpContext.Session);
            var cookies = new MagicCookies(Response.Cookies);

            session.RemoveMyMagics();
            cookies.RemoveMyMagicIds();

            // set delete message
            TempData["message"] = "Favorite Cards cleared";

            // redirect to Home page
            return RedirectToAction("Index", "Home");
        }
    }
}