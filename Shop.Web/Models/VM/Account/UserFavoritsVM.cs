using Shop.Domain.Models.Account;
using Shop.Domain.Models.BaseEntities;

namespace Shop.Web.Models.VM.Account
{
    public class UserFavoritsVM : BasePaging
    {
        public List<UserFavorite> UserFavorites { get; set; }
 
    }
}
