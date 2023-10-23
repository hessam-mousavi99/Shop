using System.ComponentModel.DataAnnotations;

namespace Shop.Application.DTOs.Accounts
{
    public class ChangePasswordDto
    {

        [Display(Name = "کلمه ی عبور فعلی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string CurrentPassword { get; set; }

        [Display(Name = "کلمه ی عبور جدید")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string NewPassword { get; set; }

        [Display(Name = "تکرار کلمه ی عبور جدید")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [Compare("NewPassword", ErrorMessage = "کلمه ی عبور جدید باهم مغایرت دارند")]
        public string ConfirmNewPassword { get; set; }

    }
}
