using Shop.Domain.Models.Account;
using Shop.Domain.Models.BaseEntities;

namespace Shop.Application.DTOs.Accounts
{
    public class UserFavoriteDto:BasePaging
    {
        public List<UserFavorite> UserFavorites { get; set; }

        #region methods
        public UserFavoriteDto SetFavorites(List<UserFavorite> userFavorites)
        {
            this.UserFavorites = userFavorites;
            return this;
        }

        public UserFavoriteDto SetPaging(BasePaging paging)
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
