using Shop.Domain.Models.Account;
using Shop.Domain.Models.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.Models.ProductEntities
{
    public class Category:BaseEntity
    {

        #region properties
        public long? ParentId { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Title { get; set; }=string.Empty;

        [Display(Name = "عنوان url")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string UrlName { get; set; }=string.Empty;

        [Display(Name = "تصویر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string ImageName { get; set; }=string.Empty;
        #endregion

        #region relations
        public virtual Category? ParentCategory { get; set; }
        public virtual ICollection<Category>? Categories { get; set; }
        public virtual ICollection<ProductCategory>? ProductCategories { get; set; }
        #endregion
    }
}
