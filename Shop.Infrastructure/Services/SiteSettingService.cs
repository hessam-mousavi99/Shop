using AutoMapper;
using Shop.Application.Contracts.Infrastructure.IServices;
using Shop.Application.Contracts.Persistence.IRepositories.ISite;
using Shop.Application.DTOs.Admin.SiteSetting.Slider;
using Shop.Application.Extentions;
using Shop.Application.Utils;
using Shop.Domain.Enums;
using Shop.Domain.Models.Site;

namespace Shop.Infrastructure.Services
{
    public class SiteSettingService : ISiteSettingService
    {
        private readonly ISliderRepository _sliderRepository;
        private readonly IMapper _mapper;

        public SiteSettingService(ISliderRepository sliderRepository, IMapper mapper)
        {
            _sliderRepository = sliderRepository;
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
            var slider = await GetEditSlider(editSliderDto.Id);
            if (slider == null) { return EditSliderResult.NotFound; }
            slider.SliderText = editSliderDto.SliderText;
            slider.Price = editSliderDto.Price;
            slider.Href = editSliderDto.Href;
            slider.SliderTitle = editSliderDto.SliderTitle;
            slider.TextBtn = editSliderDto.TextBtn;
            if (editSliderDto.ImageFile != null && editSliderDto.ImageFile.IsImage())
            {
                var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(editSliderDto.ImageFile.FileName);
                editSliderDto.ImageFile.AddImageToServer(imageName, PathExtensions.SliderOrginServer, 255, 255, PathExtensions.SliderThumbServer,slider.SliderImage);
                slider.SliderImage = imageName;
            }
            else
            {
                return EditSliderResult.ImageNotFound;
            }
            var editSlider=_mapper.Map<Slider>(slider);
            await _sliderRepository.UpdateAsync(editSlider);
            return EditSliderResult.Success;
        }

        public async Task DeleteSlider(long sliderId)
        {
            var slider = await _sliderRepository.GetAsync(sliderId);
            slider.IsDelete = true;
            await _sliderRepository.UpdateAsync(slider);
        }
    }
}
