using CPT231_Assignment06_LeviNoell_Baba.Models;
using Microsoft.AspNetCore.Mvc;

namespace CPT231_Assignment06_LeviNoell_Baba.Controllers
{
    public class MagicController : Controller
    {
        private NoellBabaContext context {  get; set; }

        public MagicController(NoellBabaContext context) 
        {
            this.context = context;
        }

        
        
    }
}
