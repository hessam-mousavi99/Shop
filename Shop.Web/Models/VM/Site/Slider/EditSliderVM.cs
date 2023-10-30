namespace Shop.Web.Models.VM.Site.Slider
{
    public class EditSliderVM:CreateSliderVM
    {
        public long Id { get; set; }

        public string SliderImage { get; set; } = string.Empty;
    }
}
