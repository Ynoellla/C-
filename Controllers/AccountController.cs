using CPT231_Assignment06_LeviNoell_Baba;
using CPT231_Assignment06_LeviNoell_Baba.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
//My Admin account has the username "Administrator" and the password "pass"
namespace CPT231_Assignment06_LeviNoell_Baba.Controllers
{
    public class AccountController : Controller
    {
        //Defining fields of UserManager and SignInManager
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        //contructor to initialize usermanager and signinmanager
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        //get action for displaying the login view
        [HttpGet]
        public IActionResult LogIn()
        {
            //return login view with a new instance of Loginviewmodel
            return View(new LoginViewModel());
        }
        //post action for handling login form submission
        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel model)
        {
            //if statement checking if modelstate is valid
            if (ModelState.IsValid)
            {
                //attempt to sign in the user using the provided username and password
                Microsoft.AspNetCore.Identity.SignInResult signInResult = await
                    signInManager.PasswordSignInAsync(model.UserName, model.Password
                    , isPersistent: model.RememberMe, lockoutOnFailure: false);
                //if sign-in succeeds, redirect to the home page
                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            return View(model);
        }
        //post action for handling logout
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            
            await this.signInManager.SignOutAsync();//sign out the current user
            return RedirectToAction("Index", "Home"); //redirect to the home page
        }
        //get action for displaying the registration view
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        //post action for handling registration form submission
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            //if statement used to check if the model state is valid
            if(ModelState.IsValid)
            {
                //create a new user object with the provided username
                User user = new User
                {
                    UserName = model.UserName
                };
                //attempt to create the user with the provided password
                IdentityResult identityResult = await userManager.CreateAsync(user, model.Password);
                //if statement used to check if the user creation succeeds. if so, signs the user in and redirects to the home page
                if (identityResult.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        public IActionResult AccessDenied()//action that redirects unathorized users to the AccessDenied View
        {
            return View();
        }
        [HttpGet]
        public IActionResult ChangePassword()
        {
            ChangePasswordViewModel model = new ChangePasswordViewModel //new instance of changepasswordviewmodel created and sets Username to the current user's name
            {
                UserName = User.Identity?.Name ?? ""
            };
            return View(model);//return the changepassword view
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid) //if statement that checks if the model state is valid
            {
                User user = await userManager.FindByNameAsync(model.UserName);//find the user by their username
                IdentityResult identityResult = await userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);//change the user's password
                if (identityResult.Succeeded) //if statement that checks if the password change was successful
                {
                    return RedirectToAction("Index", "Home"); //redirects to the home page

                }
                else
                {
                    foreach(IdentityError identityError in identityResult.Errors)//if the password was not successfully changed go through the errors
                    {
                        ModelState.AddModelError("", identityError.Description);//display the errors encountered
                    }
                }
            }
            return View(model);
        }

    }
}
