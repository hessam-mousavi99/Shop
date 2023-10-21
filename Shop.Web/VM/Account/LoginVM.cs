using System.ComponentModel.DataAnnotations;

namespace Shop.Web.VM.Account
{
    public class LoginVm
    {
        public class LoginUserViewModel 
        {
            [Display(Name = "شماره تلفن همراه")]
            [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
            [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
            public string PhoneNumber { get; set; } = string.Empty;

            [Display(Name = "گذرواژه")]
            [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
            [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
            public string Password { get; set; } = string.Empty;

            [Display(Name = "مرا بخاطر بسپار")]
            public bool RememberMe { get; set; }
        }
    }
}
