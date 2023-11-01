using Shop.Domain.Models.BaseEntities;
using Shop.Domain.Models.ProductEntities;
using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.Models.OrderEntities
{
    public class OrderDetail : BaseEntity
    {
        #region properties
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public long OrderId { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public long ProductId { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Count { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Price { get; set; }
        #endregion

        #region relations
        public virtual Order? Order { get; set; }
        public virtual Product? Product { get; set; }
        #endregion
    }
}
