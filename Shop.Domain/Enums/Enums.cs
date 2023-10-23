using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.Enums
{
    public enum UserGender
    {
        [Display(Name = "آقا")]
        Male,
        [Display(Name = "خانوم")]
        Female,
        [Display(Name = "نامشخص")]
        None 
    }
    public enum EditUserProfileResult
    {
        NotFound,
        Success
    }
    public enum ActiveAccountResult
    {
        Error,
        Success,
        NotFound
    }
    public enum RegisterUserResult
    {
        MobileExists,
        Success
    }
    public enum LoginUserResult
    {
        NotFound,
        NotActive,
        Success,
        IsBlocked
    }
    public enum ChangePasswordResult
    {
        NotFound,
        PasswordEqual,
        Success
    }
    public enum FinallyOrderResult
    {
        HasNotUser,
        NotFound,
        Error,
        Suceess
    }
    public enum WalletType
    {
        [Display(Name = "واریز")]
        Variz = 1,
        [Display(Name = "برداشت")]
        Bardasht = 2
    }
}
