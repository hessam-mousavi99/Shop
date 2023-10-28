using Shop.Domain.Enums;
using Shop.Domain.Models.BaseEntities;

namespace Shop.Web.Models.VM.Admin.Product
{
    public class FilterProductsVM : BasePaging
    {
        public string ProductName { get; set; } = string.Empty;
        public string FilterByCategory { get; set; } = string.Empty;
        public List<Shop.Domain.Models.ProductEntities.Product> Products { get; set; }
        public ProductState ProductState { get; set; }
        public ProductOrder ProductOrder { get; set; }
        public ProductBox ProductBox { get; set; }
    }
}
