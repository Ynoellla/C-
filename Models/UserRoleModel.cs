using Microsoft.AspNetCore.Identity;

namespace CPT231_Assignment06_LeviNoell_Baba.Models
{
    public class UserRoleModel//model used for managing user roles
    {
        public List<User> Users { get; set; }//property to store a list of users
        public List<IdentityRole> identityRoles { get; set; }//property to store a list of identity roles
    }
}
