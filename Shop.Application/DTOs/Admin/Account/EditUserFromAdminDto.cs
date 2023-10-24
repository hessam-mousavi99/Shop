using Shop.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Shop.Application.DTOs.Admin.Account
{
    public class EditUserFromAdminDto
    {
        public long Id { get; set; }
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string LastName { get; set; } = string.Empty;

        [Display(Name = "شماره تلفن همراه")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Display(Name = "جنسیت")]
        public UserGender UserGender { get; set; }
        [Display(Name = "گذرواژه")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Password { get; set; } = string.Empty;

        public List<long>? RoleIds { get; set; }
    }
}
