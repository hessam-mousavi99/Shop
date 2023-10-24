using Shop.Domain.Models.Account;
using Shop.Domain.Models.BaseEntities;

namespace Shop.Web.Models.VM.Admin.Account
{
    public class FilterRolesVM : BasePaging
    {
        public string RoleName { get; set; }
        public List<Role> Roles { get; set; }

    }
}
