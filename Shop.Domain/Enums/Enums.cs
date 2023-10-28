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
    public enum EditUserFromAdminResult
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
    public enum CreateOrEditRoleResult
    {
        NotFound,
        Success,
        NotExistPermissions
    }
    public enum CreateCategoryResult
    {
        IsExistUrlName,
        Success
    }
    public enum EditCategoryResult
    {
        IsExistUrlName,
        NotFound,
        Success
    }
    public enum ProductState
    {
        [Display(Name = "همه")]
        All,

        [Display(Name = "فعال")]
        IsActice,

        [Display(Name = "حذف شده")]
        Delete
    }
    public enum ProductOrder
    {
        [Display(Name = "همه")]
        All,

        [Display(Name = "جدیدترین ها")]
        ProductNewss,

        [Display(Name = "گران ترین ها")]
        ProductExp,

        [Display(Name = "ارزان ترین ها")]
        ProductInExpensive
    }
    public enum ProductBox
    {
        Default,
        ItemBoxInSite
    }
    public enum CreateProductResult
    {
        NotImage,
        Success
    }
}
