using CPT231_Assignment06_LeviNoell_Baba.Models;
using CPT231_Assignment06_LeviNoell_Baba;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CPT231_Assignment06_LeviNoell_Baba.Areas.Admin.Controllers
{
    //controller for handling user actions in the admin area
    [Authorize(Roles = "Admin")]//requres users to be in the admin role to access this controller
    [Area("Admin")] //specifies area this controller belongs to
    public class UserController : Controller
    {
        private UserManager<User> userManager; //instance of usermanager for managing users
        private RoleManager<IdentityRole> roleManager; //instance of rolemanager for managing roles
        //constructor to initialize usermanager and rolemanager
        public UserController(UserManager<User> usermanager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = usermanager;
            this.roleManager = roleManager;
        }

        //action method for displaying a list of users with their roles
        public async Task<IActionResult> Index()
        {
            List<User> users = new List<User>();
            //iterate through each user and tetrieve their roles
            foreach(User user in userManager.Users)
            {
                user.RoleNames = await userManager.GetRolesAsync(user);
                users.Add(user);
            }
            //Make model containing the list of users and identity roles
            UserRoleModel model = new UserRoleModel
            {
                Users = users,//list of users with their roles
                identityRoles = this.roleManager.Roles.ToList()//list of all identity roles
            };
            return View(model);
        }
    }
}
