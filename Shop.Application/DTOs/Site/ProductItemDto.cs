using Shop.Domain.Models.ProductEntities;

namespace Shop.Application.DTOs.Site
{
    public class ProductItemDto
    {
        #region properties
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImageName { get; set; }
        public int Price { get; set; }
        public Category Category { get; set; }
        public int CommentCount { get; set; }
        #endregion

    }
}
