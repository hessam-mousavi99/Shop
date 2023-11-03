using Shop.Domain.Enums;
using Shop.Domain.Models.BaseEntities;
using Shop.Domain.Models.OrderEntities;

namespace Shop.Web.Models.VM.Account
{
    public class FilterOrdersVM : BasePaging
    {
        public long? UserId { get; set; }
        public OrderStateFilter OrderStateFilter { get; set; }
        public List<Order> Orders { get; set; }
    }
}
