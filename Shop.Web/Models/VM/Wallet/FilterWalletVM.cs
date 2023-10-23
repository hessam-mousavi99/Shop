using Shop.Domain.Models.BaseEntities;
using Shop.Domain.Models.Wallet;

namespace Shop.Web.Models.VM.Wallet
{
    public class FilterWalletVM : BasePaging
    {
        #region properties
        public long? UserId { get; set; }
        public List<UserWallet> UserWallets { get; set; }
        #endregion
    }
}
