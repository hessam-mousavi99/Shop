using Shop.Domain.Models.BaseEntities;
using Shop.Domain.Models.ProductEntities;

namespace Shop.Web.Models.VM.Admin.Product
{
    public class FilterCategoryVM:BasePaging
    {
        public string Title { get; set; }

        public List<Category> Categories { get; set; }
    }
}
