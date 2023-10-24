using System.ComponentModel.DataAnnotations;

namespace Shop.Application.DTOs.Admin.Account
{
    public class CreateOrEditRoleDto
    {
        public long Id { get; set; }

        [Display(Name = "عنوان نقش")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string RoleTitle { get; set; }

        public List<long>? SelectedPermission { get; set; }
    }
}
