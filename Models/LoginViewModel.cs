using System.ComponentModel.DataAnnotations;

namespace CPT231_Assignment06_LeviNoell_Baba.Models
{
    public class LoginViewModel//loginviewmodel used to represent the datamodel for the login view
    {
        public String UserName { get; set; } //property for the username input field
        [Required] //make it required
        [Compare("ConfirmPassword")] //compares password with confirm password
        [DataType(DataType.Password)] //set datatype to password to hide the input characters
        public String Password { get; set; }
        [Required] //make confirmpassword required
        [DataType(DataType.Password)] //hide the input characters
        public string ConfirmPassword { get; set; }
        public bool RememberMe { get; set; }//property for the remember me checkbox
        //add return url if you want
    }
}
