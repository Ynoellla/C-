using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPT231_Assignment06_LeviNoell_Baba.Models
{
    public class User: IdentityUser //defining the user class that represents the user entity
    {
        //stuff to add later
        [NotMapped]//ensure it is not mapped to a database column
        public IList<string> RoleNames { get; set; }//property used to store role names assiciated with the user
    }
}
