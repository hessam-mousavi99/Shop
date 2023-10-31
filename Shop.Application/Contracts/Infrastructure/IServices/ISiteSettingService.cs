using Shop.Application.DTOs.Admin.SiteSetting.Slider;
using Shop.Application.DTOs.Site;
using Shop.Domain.Enums;

namespace Shop.Application.Contracts.Infrastructure.IServices
{
    public interface ISiteSettingService
    {
        #region slider
        Task<FilterSlidersDto> FilterSliders(FilterSlidersDto filterSlidersDto);
        Task<CreateSliderResult> CreateSlider(CreateSliderDto createSliderDto);
        Task<EditSliderDto> GetEditSlider(long sliderId);
        Task<EditSliderResult> EditSlider(EditSliderDto editSliderDto);
        Task DeleteSlider(long sliderId);
        Task<List<ProductItemDto>> ShowAllProductsInSlider();
        Task<List<ProductItemDto>> ShowAllProductsInCategory(string hrefName);
        #endregion 
    }
}
