using AutoMapper;
using Shop.Application.Contracts.Infrastructure.IServices;
using Shop.Application.Contracts.Persistence.IRepositories.IProductEntities;
using Shop.Application.Contracts.Persistence.IRepositories.ISite;
using Shop.Application.DTOs.Admin.SiteSetting.Slider;
using Shop.Application.DTOs.Site;
using Shop.Application.Extentions;
using Shop.Application.Utils;
using Shop.Domain.Enums;
using Shop.Domain.Models.Site;

namespace Shop.Infrastructure.Services
{
    public class SiteSettingService : ISiteSettingService
    {
        private readonly ISliderRepository _sliderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public SiteSettingService(ISliderRepository sliderRepository, IProductRepository productRepository, IMapper mapper)
        {
            _sliderRepository = sliderRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<FilterSlidersDto> FilterSliders(FilterSlidersDto filterSlidersDto)
        {
            return await _sliderRepository.FliterSliders(filterSlidersDto);
        }

        public async Task<CreateSliderResult> CreateSlider(CreateSliderDto createSliderDto)
        {
            var newSlider = _mapper.Map<Slider>(createSliderDto);
            if (createSliderDto.ImageFile != null && createSliderDto.ImageFile.IsImage())
            {
                var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(createSliderDto.ImageFile.FileName);
                createSliderDto.ImageFile.AddImageToServer(imageName, PathExtensions.SliderOrginServer, 255, 255, PathExtensions.SliderThumbServer);
                newSlider.SliderImage = imageName;
            }
            else
            {
                return CreateSliderResult.ImageNotFound;
            }
            await _sliderRepository.AddAsync(newSlider);
            return CreateSliderResult.Success;
        }

        public async Task<EditSliderDto> GetEditSlider(long sliderId)
        {
            var slider = await _sliderRepository.GetAsync(sliderId);
            return _mapper.Map<EditSliderDto>(slider);
        }

        public async Task<EditSliderResult> EditSlider(EditSliderDto editSliderDto)
        {
            var slider = await _sliderRepository.GetAsync(editSliderDto.Id);
            if (slider == null) { return EditSliderResult.NotFound; }
            slider.Id = editSliderDto.Id;
            slider.SliderText = editSliderDto.SliderText;
            slider.Price = editSliderDto.Price;
            slider.Href = editSliderDto.Href;
            slider.SliderTitle = editSliderDto.SliderTitle;
            slider.TextBtn = editSliderDto.TextBtn;
            if (editSliderDto.ImageFile != null && editSliderDto.ImageFile.IsImage())
            {
                var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(editSliderDto.ImageFile.FileName);
                editSliderDto.ImageFile.AddImageToServer(imageName, PathExtensions.SliderOrginServer, 255, 255, PathExtensions.SliderThumbServer, slider.SliderImage);
                slider.SliderImage = imageName;
            }
            await _sliderRepository.UpdateAsync(slider);
            return EditSliderResult.Success;
        }

        public async Task DeleteSlider(long sliderId)
        {
            var slider = await _sliderRepository.GetAsync(sliderId);
            slider.IsDelete = true;
            await _sliderRepository.UpdateAsync(slider);
        }

        public async Task<List<ProductItemDto>> ShowAllProductsInSlider()
        {
            return await _productRepository.ShowAllProductsInSlider();
        }

        public async Task<List<ProductItemDto>> ShowAllProductsInCategory(string hrefName)
        {
            return await _productRepository.ShowAllProductsInCategory(hrefName);
        }

        public async Task<List<ProductItemDto>> LastProducts()
        {
            return await _productRepository.LastProducts();
        }
    }
}
