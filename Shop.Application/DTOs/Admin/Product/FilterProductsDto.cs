using Shop.Domain.Enums;
using Shop.Domain.Models.BaseEntities;

namespace Shop.Application.DTOs.Admin.Product
{
    public class FilterProductsDto : BasePaging
    {
        public string ProductName { get; set; } = string.Empty;
        public string FilterByCategory { get; set; } = string.Empty;
        public List<Shop.Domain.Models.ProductEntities.Product> Products { get; set; }
        public ProductState ProductState { get; set; }
        public ProductOrder ProductOrder { get; set; }
        public ProductBox ProductBox { get; set; }
        #region methods
        public FilterProductsDto SetProducts(List<Shop.Domain.Models.ProductEntities.Product> products)
        {
            this.Products = products;
            return this;
        }

        public FilterProductsDto SetPaging(BasePaging paging)
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
