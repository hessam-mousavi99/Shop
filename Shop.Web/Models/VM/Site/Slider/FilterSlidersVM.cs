using Shop.Domain.Models.BaseEntities;

namespace Shop.Web.Models.VM.Site.Slider
{
    public class FilterSlidersVM : BasePaging
    {
        public string SliderTitle { get; set; }

        public List<Shop.Domain.Models.Site.Slider> Sliders { get; set; }
    }
}
