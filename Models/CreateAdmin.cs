using Microsoft.AspNetCore.Identity;

namespace CPT231_Assignment06_LeviNoell_Baba.Models
{
    public class CreateAdmin
    {
        //asynchronously create an admin account
        public static async Task CreateAdminAccountAsyn(IServiceProvider serviceProvider)
        {
            //retrieve rolemanager and usermanager services
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            UserManager<User> userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            //define username, password, and role for the admin account
            String admin = "Administrator";
            String pass = "pass";
            String role = "Admin";
            //if statement used to check if the specified role already exists in the database
            if(await roleManager.FindByNameAsync(role) == null)
            {
                //create the admin
                await roleManager.CreateAsync(new IdentityRole(role));
            }
            //if statement used to check if the sp ecified admin user already exists in the database
            if(await userManager.FindByNameAsync(admin) == null)
            {
                //if the admin user doesn't exist, it is created
                User user = new User() { UserName = admin };
                IdentityResult result = await userManager.CreateAsync(user, pass);//(new User(), pass);
                if(result.Succeeded) //if statement used to check if user creation is successful and assigns the admin user to the specified role
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }
    }
}
