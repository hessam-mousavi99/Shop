using Shop.Domain.Models.BaseEntities;
using System.Buffers.Text;
using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.Models.Account
{
    public class Role:BaseEntity
    {
        #region properties

        [Display(Name = "عنوان نقش")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string RoleTitle { get; set; }
        #endregion

        #region relations
        public virtual ICollection<UserRole>? UserRoles { get; set; }
        public virtual ICollection<RolePermission>? RolePermissions { get; set; }

        #endregion
    }
}
