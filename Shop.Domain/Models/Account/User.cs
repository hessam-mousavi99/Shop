using Shop.Domain.Enums;
using Shop.Domain.Models.BaseEntities;
using Shop.Domain.Models.Wallet;
using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.Models.Account
{
    public class User: BaseEntity
    {
        #region Properties
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string FirstName { get; set; } = string.Empty;
        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string LastName { get; set; } = string.Empty;
        [Display(Name = "شماره تلفن همراه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string PhoneNumber { get; set; } = string.Empty;
        [Display(Name = "گذرواژه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Password { get; set; } = string.Empty;
        [Display(Name = "آواتار")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Avatar { get; set; } = string.Empty;
        [Display(Name = "جنسیت")]
        public UserGender Gender { get; set; }
        [Display(Name = "مسدود شده / نشده")]
        public bool IsBlocked { get; set; }
        [Display(Name = "کد احرازهویت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string ActiveCode { get; set; } = string.Empty;
        [Display(Name = "تایید شده / نشده")]
        public bool IsActive { get; set; }
        #endregion

        #region Relations
        public ICollection<UserWallet>? UserWallets { get; set; }
        #endregion
    }
}
