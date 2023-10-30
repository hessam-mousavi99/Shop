using System.ComponentModel.DataAnnotations;

namespace Shop.Web.Models.VM.Admin.Product
{
    public class CreateFeatureVM
    {
        public long ProductId { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string FeatuerTitle { get; set; } = string.Empty;

        [Display(Name = "مقدار")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string FeatureValue { get; set; } = string.Empty;
    }
}
