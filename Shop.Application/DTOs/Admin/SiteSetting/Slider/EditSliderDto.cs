namespace Shop.Application.DTOs.Admin.SiteSetting.Slider
{
    public class EditSliderDto:CreateSliderDto
    {
        public long Id { get; set; }

        public string SliderImage { get; set; } = string.Empty;
    }
}
