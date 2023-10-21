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
}
