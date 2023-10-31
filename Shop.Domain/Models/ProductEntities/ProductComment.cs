using Shop.Domain.Models.Account;
using Shop.Domain.Models.BaseEntities;

namespace Shop.Domain.Models.ProductEntities
{
    public class ProductComment:BaseEntity
    {
        public long ProductId { get; set; }
        public long UserId { get; set; }
        public string Text { get; set; }=string.Empty;

        #region relation
        public virtual Product? Product { get; set; }
        public virtual User? User { get; set; }
        #endregion
    }
}
