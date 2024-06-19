//Levi Noell-Baba
//CPT 231-W17
//Assignment 11 & 12
//April 18, 2024
using CPT231_Assignment06_LeviNoell_Baba.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CPT231_Assignment06_LeviNoell_Baba.Areas.Admin.Controllers //changed namespace to refer to Admin Area
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]//specifying what area the code applies to
    public class MagicController : Controller
    {
        private NoellBabaContext context {  get; set; }

        public MagicController(NoellBabaContext context) 
        {
            this.context = context;
        }

        //add get
        [Route("[area]/[controller]/[action]")]//added route that speicfies it should work in an area
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.AddEdit = "Add";
            return View("AddEdit", new Magic());
        }
        //Edit get
        [Route("[area]/[controller]/[action]")]//added route that speicfies it should work in an area
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.AddEdit = "Edit";
            Magic magic = context.Magics.Find(id);
            return View("AddEdit", magic);
        }

        //addedit post
        [Route("[area]/[controller]/[action]")]//added route that speicfies it should work in an area
        [HttpPost]
        public IActionResult AddEdit(Magic magic)
        {
            if (ModelState.IsValid)
            {
                string message; //declaration of the message
                if (magic.MagicId ==0)
                {
                    context.Magics.Add(magic);
                    message = $"{magic.CardName} was added to the database..."; //Tempdata message for an added card

                }
                else
                {
                    context.Magics.Update(magic);
                    message = $"{magic.CardName} was edited in the database...";//Tempdata message for an edited card
                }
                context.SaveChanges();
                TempData["Message"] = message;
                TempData["Type"] = "success";
                return RedirectToAction("Index", "Home", new { area = ""});
            }
            else
            {
                ViewBag.AddEdit = (magic.MagicId == 0) ? "Add" : "Edit";
                return View(magic);
            }
        }
        //Delete get
        [Route("[area]/[controller]/[action]")]//added route that speicfies it should work in an area
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Magic magic = context.Magics.Find(id);
            return View("Delete", magic);
        }
        //delete post
        [Route("[area]/[controller]/[action]")]//added route that speicfies it should work in an area
        [HttpPost]
        public IActionResult Delete(Magic magic)
        {
            context.Magics.Remove(magic);
            context.SaveChanges();
            TempData["Message"] = $"{magic.CardName} was deleted from the database..."; //TempData message added for when a card is deleted
            TempData["Type"] = "warning"; //Tempdata formatting to change the color of the message to warning
            return RedirectToAction("Index", "Home", new { area = ""});
        }

        public IActionResult Index() 
        { 
            return View(); 
        }
        public IActionResult Admin()
        {
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
