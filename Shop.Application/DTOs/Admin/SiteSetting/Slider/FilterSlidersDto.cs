using Shop.Domain.Models.BaseEntities;

namespace Shop.Application.DTOs.Admin.SiteSetting.Slider
{
    public class FilterSlidersDto:BasePaging
    {
        public string SliderTitle { get; set; }

        public List<Shop.Domain.Models.Site.Slider> Sliders { get; set; }

        #region methods
        public FilterSlidersDto SetSilders(List<Shop.Domain.Models.Site.Slider> sliders)
        {
            this.Sliders = sliders;
            return this;
        }

        public FilterSlidersDto SetPaging(BasePaging paging)
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
