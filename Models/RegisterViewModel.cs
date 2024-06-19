using System.ComponentModel.DataAnnotations;

namespace CPT231_Assignment06_LeviNoell_Baba.Models
{
    public class RegisterViewModel
    {
        [Required]//make the username required
        public String UserName { get; set; }
        [Required]//make the password required
        [DataType(DataType.Password)]//hide the input data
        [Compare("ConfirmPassword")]//compare password with confirm password
        public String Password { get; set; }
        [Required]//make confirm password required
        [DataType(DataType.Password)]//hide the input data
        public String ConfirmPassword { get; set; }
    }
}
