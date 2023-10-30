using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Contracts.Infrastructure.IServices;
using Shop.Application.DTOs.Admin.SiteSetting.Slider;
using Shop.Domain.Enums;
using Shop.Web.Models.VM.Site.Slider;

namespace Shop.Web.Areas.Admin.Controllers
{
    public class SliderController : AdminBaseController
    {
        #region constractor
        private readonly ISiteSettingService _siteSettingService;
        private readonly IMapper _mapper;

        public SliderController(ISiteSettingService siteSettingService,IMapper mapper)
        {
            _siteSettingService = siteSettingService;
            _mapper = mapper;
        }
        #endregion

        #region sliders
        public async Task<IActionResult> FilterSlider(FilterSlidersVM filterVM)
        {
            var filterDto = _mapper.Map<FilterSlidersDto>(filterVM);
            var filter = await _siteSettingService.FilterSliders(filterDto);
            return View(_mapper.Map<FilterSlidersVM>(filter));
        }
        #endregion

        #region create-slider
        [HttpGet]
        public IActionResult CreateSlider()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSlider(CreateSliderVM createSlider)
        {
            var sliderDto = _mapper.Map<CreateSliderDto>(createSlider);
            if (ModelState.IsValid)
            {
                var result = await _siteSettingService.CreateSlider(sliderDto);

                switch (result)
                {
                    case CreateSliderResult.ImageNotFound:
                        TempData[WarningMessage] = "عکسی برای ثبت بارگذاری نکردید.";
                        break;
                    case CreateSliderResult.Success:
                        TempData[SuccessMessage] = "اسلایدر شما با موفقیت ایجاد شد.";
                        return RedirectToAction("FilterSlider");
                }
            }

            return View(createSlider);
        }
        #endregion

        #region edit-slider
        [HttpGet]
        public async Task<IActionResult> EditSlider(long sliderId)
        {
            var data = await _siteSettingService.GetEditSlider(sliderId);
            if (data == null)
                return NotFound();
            var dataVM=_mapper.Map<EditSliderVM>(data);
            return View(dataVM);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSlider(EditSliderVM editSlider)
        {
            var sliderDto = _mapper.Map<EditSliderDto>(editSlider);

            if (ModelState.IsValid)
            {
                var result = await _siteSettingService.EditSlider(sliderDto);
                switch (result)
                {
                    case EditSliderResult.NotFound:
                        TempData[WarningMessage] = "اسلایدری یاف نشد.";
                        break;
                    case EditSliderResult.Success:
                        TempData[SuccessMessage] = "اسلایدر با موفقیت ویرایش شد.";
                        return RedirectToAction("FilterSlider");
                }
            }

            return View(editSlider);
        }
        #endregion

        #region Delete Slider
        public async Task<IActionResult> DeleteSlider(long sliderId)
        {
            await _siteSettingService.DeleteSlider(sliderId);
            return RedirectToAction("FilterSlider");
        }
        #endregion
    }
}
