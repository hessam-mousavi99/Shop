using Shop.Domain.Models.Account;
using Shop.Domain.Models.BaseEntities;

namespace Shop.Application.DTOs.Admin.Account
{
    public class FilterUserDto : BasePaging
    {
        #region Properties
        public string PhoneNumber { get; set; }
        public List<User> Users { get; set; }
        #endregion

        #region methods
        public FilterUserDto SetUsers(List<User> users)
        {
            this.Users = users;
            return this;
        }

        public FilterUserDto SetPaging(BasePaging paging)
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
