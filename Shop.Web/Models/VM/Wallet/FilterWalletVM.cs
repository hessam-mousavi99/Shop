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

        #region methods
        public FilterWalletVM SetWallets(List<UserWallet> userWallets)
        {
            this.UserWallets = userWallets;
            return this;
        }

        public FilterWalletVM SetPaging(BasePaging paging)
        {
            this.PageId = paging.PageId;
            this.AllEntityCount = paging.AllEntityCount;
            this.StartPage = paging.StartPage;
            this.EndPage = paging.EndPage;
            this.TakeEntity = paging.TakeEntity;
            this.CountForShowAfterAndBefor = paging.CountForShowAfterAndBefor;
            this.SkipEntitiy = paging.SkipEntitiy;
            this.PageCount = paging.PageCount;

            return this;
        }

        #endregion
    }
}
