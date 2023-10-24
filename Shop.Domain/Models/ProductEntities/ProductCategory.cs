using Shop.Domain.Models.BaseEntities;

namespace Shop.Domain.Models.ProductEntities
{
    public class ProductCategory:BaseEntity
    {
        #region properties
        public long ProductId { get; set; }
        public long CategoryId { get; set; }
        #endregion

        #region relations
        public virtual Product? Product { get; set; }
        public virtual Category? Category { get; set; }
        #endregion
    }
}
