using Shop.Domain.Models.BaseEntities;
using Shop.Domain.Models.ProductEntities;

namespace Shop.Application.DTOs.Admin.Product
{
    public class FilterCategoryDto:BasePaging
    {
        public string Title { get; set; }

        public List<Category> Categories { get; set; }

        #region methods
        public FilterCategoryDto SetCategories(List<Category> Categories)
        {
            this.Categories = Categories;
            return this;
        }

        public FilterCategoryDto SetPaging(BasePaging paging)
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
