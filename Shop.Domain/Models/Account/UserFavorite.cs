using Shop.Domain.Models.BaseEntities;
using Shop.Domain.Models.ProductEntities;

namespace Shop.Domain.Models.Account
{
    public class UserFavorite:BaseEntity
    {
        public long UserId { get; set; }
        public long ProductId { get; set; }

        #region relations
        public virtual User? User { get; set; }
        public virtual Product? Product { get; set; }
        #endregion
    }
}
