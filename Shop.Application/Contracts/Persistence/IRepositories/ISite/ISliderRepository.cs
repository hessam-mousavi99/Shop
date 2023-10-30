using Shop.Application.Contracts.Persistence.IRepositories.IGenerics;
using Shop.Application.DTOs.Admin.SiteSetting.Slider;
using Shop.Domain.Models.Site;

namespace Shop.Application.Contracts.Persistence.IRepositories.ISite
{
    public interface ISliderRepository: IGenericRepository<Slider>
    {
        Task<FilterSlidersDto> FliterSliders(FilterSlidersDto filterSlidersDto); 
        Task SaveChanges();
    }
}
