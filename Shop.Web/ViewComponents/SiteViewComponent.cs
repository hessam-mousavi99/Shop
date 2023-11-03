using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Contracts.Infrastructure.IServices;
using Shop.Application.Contracts.Persistence.IRepositories.IProductEntities;
using Shop.Application.DTOs.Admin.Product;
using Shop.Application.DTOs.Admin.SiteSetting.Slider;
using Shop.Application.Features.Account.Users.Requests.Queries;
using Shop.Application.Features.Product.Category.Requests.Queries;
using Shop.Application.Features.Product.Comment.Requests.Queries;
using Shop.Domain.Models.Account;

namespace Shop.Web.ViewComponents
{
    #region Header
    public class SiteHeaderViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public SiteHeaderViewComponent(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
       
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _mediator.Send(new GetUserByPhoneNumRequest() { PhoneNumber = User.Identity.Name });
                var map = _mapper.Map<User>(user);
                ViewBag.User = map;

            }
            return View("SiteHeader");
        }
    }
    #endregion

    #region Footer
    public class SiteFooterViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("SiteFooter");
        }
    }
    #endregion

    #region Slider
    public class SiteSliderViewComponent : ViewComponent
    {
        private readonly ISiteSettingService _siteSettingService;

        public SiteSliderViewComponent(ISiteSettingService siteSettingService)
        {
            _siteSettingService = siteSettingService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var filterslider = new FilterSlidersDto
            {
                TakeEntity = 5
            };
            var data = await _siteSettingService.FilterSliders(filterslider);
            return View("SiteSlider",data);
        }
    }
    #endregion
    
    #region popular Category
    public class PopularCategoryViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;
        public PopularCategoryViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var filterCategory = new FilterCategoryDto();
            filterCategory.TakeEntity = 2;
            var data =await _mediator.Send(new FilterCategoryRequest() { FilterCategoryDto=filterCategory});
            return View("PopularCategory", data);
        }
    }
    #endregion

    #region  Category
    public class NavbarCategoryViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;
        public NavbarCategoryViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var filterCategory = new FilterCategoryDto();
            var data = await _mediator.Send(new FilterCategoryRequest() { FilterCategoryDto = filterCategory });
            return View("NavbarCategory", data);
        }
    }
    #endregion

    #region  AllProductInSlider
    public class AllProductInSliderViewComponent : ViewComponent
    {
        private readonly ISiteSettingService _siteSettingService;

        public AllProductInSliderViewComponent(ISiteSettingService siteSettingService)
        {
            _siteSettingService = siteSettingService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
        var data =await _siteSettingService.ShowAllProductsInSlider();
            return View("AllProductInSlider", data);
        }
    }
    #endregion
    #region  AllProductInCategoryWomen
    public class AllProductInCategoryWomenViewComponent : ViewComponent
    {
        private readonly ISiteSettingService _siteSettingService;

        public AllProductInCategoryWomenViewComponent(ISiteSettingService siteSettingService)
        {
            _siteSettingService = siteSettingService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _siteSettingService.ShowAllProductsInCategory("Women");
            return View("AllProductInCategoryWomen", data);
        }
    }
    #endregion
    #region  AllProductInCategoryMen
    public class AllProductInCategoryMenViewComponent : ViewComponent
    {
        private readonly ISiteSettingService _siteSettingService;

        public AllProductInCategoryMenViewComponent(ISiteSettingService siteSettingService)
        {
            _siteSettingService = siteSettingService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _siteSettingService.ShowAllProductsInCategory("Men");
            return View("AllProductInCategoryMen", data);
        }
    }
    #endregion

    #region All-productInCategoryPc - home
    public class ProductCommentsViewComponent : ViewComponent
    {
        #region constractor
      
        private readonly IMediator _mediator;

        public ProductCommentsViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        public async Task<IViewComponentResult> InvokeAsync(long productId)
        {

            var data = await _mediator.Send(new GetAllCommentsByIdRequest() { ProductId = productId });

            return View("ProductComments", data);
        }
    }
    #endregion
}
