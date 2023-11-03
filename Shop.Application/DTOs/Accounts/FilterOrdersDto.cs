using Shop.Domain.Enums;
using Shop.Domain.Models.BaseEntities;
using Shop.Domain.Models.OrderEntities;

namespace Shop.Application.DTOs.Accounts
{
    public class FilterOrdersDto:BasePaging
    {
        public long? UserId { get; set; }
        public OrderStateFilter OrderStateFilter { get; set; }
        public List<Order> Orders { get; set; }


        #region methods
        public FilterOrdersDto SetOrders(List<Order> orders)
        {
            this.Orders = orders;
            return this;
        }

        public FilterOrdersDto SetPaging(BasePaging paging)
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
