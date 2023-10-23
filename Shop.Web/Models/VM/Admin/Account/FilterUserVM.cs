using Shop.Domain.Models.Account;
using Shop.Domain.Models.BaseEntities;

namespace Shop.Web.Models.VM.Admin.Account
{
    public class FilterUserVM:BasePaging
    {
        public string PhoneNumber { get; set; }
        public List<User> Users { get; set; }
    }
}
