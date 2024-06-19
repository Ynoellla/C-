using System.ComponentModel.DataAnnotations;

namespace CPT231_Assignment06_LeviNoell_Baba.Models
{
    public class ChangePasswordViewModel
    {
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
        [DataType(DataType.Password)]
        [Compare("ConfirmNewPassword")]
        public string NewPassword { get; set; }
        [DataType(DataType.Password)]
        public string ConfirmNewPassword { get; set;}
    }
}
