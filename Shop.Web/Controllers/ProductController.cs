using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.DTOs.Admin.Product;
using Shop.Application.Features.Product.Category.Requests.Queries;
using Shop.Application.Features.Product.Product.Requests.Queries;
using Shop.Domain.Enums;
using Shop.Web.Models.VM.Admin.Product;

namespace Shop.Web.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        #region constractor
        public ProductController(IMediator mediator ,IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        #endregion


        #region products
        [HttpGet("products")]
        public async Task<IActionResult> Products(FilterProductsDto filter)
        {
            
            filter.TakeEntity = 12;
            filter.ProductBox = ProductBox.ItemBoxInSite;

            ViewData["Categories"] = await _mediator.Send(new GetAllCategoriesRequest());
            var FinalFilter= await _mediator.Send(new FilterProductsRequest() { filterProductsDto = filter });
            return View(FinalFilter);
        }
        #endregion

        #region show-product
        //[HttpGet("showDetail/{productId}")]
        //public async Task<IActionResult> ProductDetail(long productId)
        //{
        //    var data = await _productService.ShowProductDetail(productId);
        //    if (data == null)
        //    {
        //        return NotFound();
        //    }


        //    TempData["relatedProduct"] = await _productService.GetRelatedProduct(data.ProductCategory.UrlName, productId);
        //    return View(data);
        //}
        #endregion
    }
}
