using CPT231_Assignment06_LeviNoell_Baba.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CPT231_Assignment06_LeviNoell_Baba.Controllers
{
    public class HomeController : Controller
    {
        private NoellBabaContext context { get; set; }

        public HomeController(NoellBabaContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            MagicSession session = new MagicSession(HttpContext.Session);//create new instance of magicsession using the current session
            List<Magic> magics = context.Magics.ToList(); //retrieve all magic cards from the database
            int? count = session.GetMyMagicCount(); //get the count of magic cards stored in the session
            if (!count.HasValue)//if the count is null retrieve from cookies
            {
                var cookies = new MagicCookies(Request.Cookies);//create new instance of magiccookies using the request cookies
                string[] ids = cookies.GetMyMagicIds();//get the Ids of the magic cards sotred in cookies
                if(ids.Length > 0) //if there are magic cards stored in cookies, retrieve the magic cards corresponding to the ids from the database and sotre the retrieved magic cards in the session
                {
                    var mymagics = context.Magics
                        .Where(t => ids.Contains(t.MagicId.ToString()))
                        .ToList();
                    session.SetMyMagics(mymagics);
                }
            }
            return View(magics); //return the view with the list of magic cards
        }
        [Route("[controller]/[action]/{id}")]
        public IActionResult Favorite(int id)
        {
            var session = new MagicSession(HttpContext.Session);//create a new instance of magicsession using the current session
            var cookies = new MagicCookies(Response.Cookies); //create a new instance of MagicCookies using the response cookies
            List<Magic> magics = session.GetMyMagics(); //retireve the magic cards stored in the session
            return View(magics); //return the view with the list of favorite magic cards
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
