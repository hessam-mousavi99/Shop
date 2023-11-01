using Shop.Domain.Enums;
using Shop.Domain.Models.Account;
using Shop.Domain.Models.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.Models.OrderEntities
{
    public class Order:BaseEntity
    {
        #region properties
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public long UserId { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int OrderSum { get; set; }
       
        public bool IsFinaly { get; set; }
       
        public OrderState OrderState { get; set; }
        #endregion


        #region relations
        public virtual User? User { get; set; }
        public virtual ICollection<OrderDetail>? OrderDetails { get; set; }
        #endregion
    }
}
