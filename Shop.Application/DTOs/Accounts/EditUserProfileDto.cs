using Shop.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Shop.Application.DTOs.Accounts
{
    public class EditUserProfileDto
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string LastName { get; set; }

        [Display(Name = "شماره تلفن همراه")]
        public string PhoneNumber { get; set; }

        [Display(Name = "جنسیت")]
        public UserGender UserGender { get; set; }
    }
   
}
