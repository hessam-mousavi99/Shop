using Shop.Domain.Models.Account;
using Shop.Domain.Models.BaseEntities;

namespace Shop.Web.Models.VM.Account
{
    public class UserComparesVM : BasePaging
    {
        public List<UserCompare> UserCompares { get; set; }

    }
}
