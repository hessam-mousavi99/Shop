using Microsoft.AspNetCore.Http;

namespace Shop.Application.DTOs.Admin.SiteSetting.Slider
{
    public class CreateSliderDto
    {
        public string SliderTitle { get; set; } = string.Empty;
        public string SliderText { get; set; } = string.Empty;
        public int Price { get; set; }
        public string Href { get; set; } = string.Empty;
        public string TextBtn { get; set; } = string.Empty;
        public IFormFile ImageFile { get; set; }
    }
}
