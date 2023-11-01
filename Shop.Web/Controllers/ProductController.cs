using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.DTOs.Admin.Product;
using Shop.Application.DTOs.Site;
using Shop.Application.Extentions;
using Shop.Application.Features.Product.Category.Requests.Queries;
using Shop.Application.Features.Product.Comment.Requests.Commands;
using Shop.Application.Features.Product.Product.Requests.Queries;
using Shop.Domain.Enums;
using Shop.Web.Models.VM.Site.Products;

namespace Shop.Web.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        #region constractor
        public ProductController(IMediator mediator, IMapper mapper)
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
            var FinalFilter = await _mediator.Send(new FilterProductsRequest() { filterProductsDto = filter });
            return View(FinalFilter);
        }
        #endregion

        #region show-product
        [HttpGet("showDetail/{productId}")]
        public async Task<IActionResult> ProductDetail(long productId)
        {
            var data = await _mediator.Send(new GetProductDetailRequest() { ProductId = productId });
            if (data == null)
            {
                return NotFound();
            }

            TempData["relatedProduct"] = await _mediator.Send(new GetRelatedProductRequest() { CategoryName = data.Category.UrlName, ProductId = productId });

            return View(_mapper.Map<ProductDetailVM>(data));
        }
        #endregion

        #region create-product-comment
        [HttpPost("add-comment"), ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProductComment(CreateProductCommentVM createProductComment)
        {
            var comment = _mapper.Map<CreateProductCommentDto>(createProductComment);
            if (!string.IsNullOrEmpty(comment.Text))
            {
                var commend = new CreateProductCommentCommandRequest() { CreateProductCommentDto = comment, UserId = User.GetUserId() };
                var response = await _mediator.Send(commend);
                switch (response)
                {
                    case CreateProductCommentResult.CheckUser:
                        TempData[WarningMessage] = "کاربر مورد نظر یافت نشد";
                        break;
                    case CreateProductCommentResult.CheckProduct:
                        TempData[WarningMessage] = "محصولی یافت نشد";
                        break;
                    case CreateProductCommentResult.Success:
                        TempData[SuccessMessage] = "نظر شما با موفقیت ثبت شد";
                        return RedirectToAction("ProductDetail", new { productId = comment.ProductId });

                }
            }

            TempData[ErrorMessage] = "لطفا نظر خود را وارد نمایید";
            return RedirectToAction("ProductDetail", new { productId = createProductComment.ProductId });

        }
        #endregion
    }
}
