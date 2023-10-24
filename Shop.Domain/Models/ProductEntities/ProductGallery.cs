using Shop.Domain.Models.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.Models.ProductEntities
{
    public class ProductGallery:BaseEntity
    {
        #region properties
        public long ProductId { get; set; }

        [Display(Name = "تصویر محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string ImageName { get; set; } = string.Empty;
        #endregion

        #region relations
        public  virtual Product? Product { get; set; }
        #endregion
    }
}
