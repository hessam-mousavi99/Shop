using Shop.Domain.Models.BaseEntities;
using Shop.Domain.Models.OrderEntities;
using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.Models.ProductEntities
{
    public class Product:BaseEntity
    {
        #region properties

        [Display(Name = "نام محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Name { get; set; }=string.Empty;

        [Display(Name = "توضیحات کوتاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(800, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string ShortDescription { get; set; } = string.Empty;

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "قیمت محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Price { get; set; }

        [Display(Name = "تصویر محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string ProductImageName { get; set; } = string.Empty;

        [Display(Name = "فعال / غیر فعال")]
        public bool IsActive { get; set; }
        #endregion

        #region Relations
        public virtual ICollection<ProductCategory>? ProductCategories { get; set; }
        public virtual ICollection<ProductFeature>? ProductFeatures { get; set; }
        public virtual ICollection<ProductGallery>? ProductGalleries { get; set; }
        public virtual ICollection<ProductComment>? ProductComments { get; set; }
        public virtual ICollection<OrderDetail>? OrderDetails { get; set; }

        #endregion
    }
}
