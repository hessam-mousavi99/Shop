using Shop.Domain.Models.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.Models.ProductEntities
{
    public class ProductFeature: BaseEntity
    {
        #region properties
        public long ProductId { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string FeatuerTitle { get; set; } = string.Empty;

        [Display(Name = "مقدار")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string FeatureValue { get; set; } = string.Empty;
        #endregion

        #region relations
        public virtual Product? Product { get; set; }
        #endregion
    }
}
