using Shop.Domain.Models.Account;
using Shop.Domain.Models.BaseEntities;

namespace Shop.Application.DTOs.Admin.Account
{
    public class FilterRolesDto:BasePaging
    {
        public string RoleName { get; set; } = string.Empty;
        public List<Role>? Roles { get; set; }

        #region methods
        public FilterRolesDto SetRoles(List<Role> roles)
        {
            this.Roles = roles;
            return this;
        }

        public FilterRolesDto SetPaging(BasePaging paging)
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
