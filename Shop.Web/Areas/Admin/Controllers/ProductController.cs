using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.DTOs.Admin.Product;
using Shop.Application.Features.Product.Category.Requests.Commands;
using Shop.Application.Features.Product.Category.Requests.Queries;
using Shop.Application.Features.Product.Gallery.Requests.Command;
using Shop.Application.Features.Product.Gallery.Requests.Queries;
using Shop.Application.Features.Product.Product.Requests.Commands;
using Shop.Application.Features.Product.Product.Requests.Queries;
using Shop.Domain.Enums;
using Shop.Web.Extentions;
using Shop.Web.Models.VM.Admin.Product;

namespace Shop.Web.Areas.Admin.Controllers
{
    public class ProductController : AdminBaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        #region Category

        #region Create category
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory(CreateCategoryVM createCategory, IFormFile? image)
        {
            var mapCategory = _mapper.Map<CreateCategoryDto>(createCategory);
            if (ModelState.IsValid)
            {
                var command = new CreateCategoryCommandRequest() { CreateCategoryDto = mapCategory, Image = image };
                var response = await _mediator.Send(command);
                switch (response)
                {
                    case CreateCategoryResult.IsExistUrlName:
                        TempData[WarningMessage] = "اسم Url تکراری است";
                        break;
                    case CreateCategoryResult.Success:
                        TempData[SuccessMessage] = "دسته بندی با موفقیت ثبت شد";
                        return RedirectToAction("FilterCategories");
                }
            }

            return View(createCategory);
        }
        #endregion

        #region edit product category
        [HttpGet]
        public async Task<IActionResult> EditCategory(long categoryId)
        {
            var data = await _mediator.Send(new GetEditCategoryRequest() { CategoryId = categoryId });

            if (data == null) return NotFound();
            var mapCategory = _mapper.Map<EditCategoryVM>(data);
            return View(mapCategory);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategory(EditCategoryVM editCategoryVM, IFormFile? image)
        {
            var mapCategory = _mapper.Map<EditCategoryDto>(editCategoryVM);
            if (ModelState.IsValid)
            {
                var command = new EditCategoryCommandRequest() { EditCategoryDto = mapCategory, Image = image };
                var response= await _mediator.Send(command);
                switch (response)
                {
                    case EditCategoryResult.IsExistUrlName:
                        TempData[WarningMessage] = "اسم Url تکراری است";
                        break;
                    case EditCategoryResult.NotFound:
                        TempData[ErrorMessage] = "دسته بندی با مشخصات وارد شده یافت نشد";
                        break;
                    case EditCategoryResult.Success:
                        TempData[SuccessMessage] = "دسته بندی با موفقیت ویرایش شد";
                        return RedirectToAction("FilterCategories");
                }
            }
            return View(editCategoryVM);
        }
        #endregion

        #region Filter Category
        public async Task<IActionResult> FilterCategories(FilterCategoryVM filter)
        {
            var mapRequest = _mapper.Map<FilterCategoryDto>(filter);
            var response = await _mediator.Send(new FilterCategoryRequest() { FilterCategoryDto = mapRequest });
            var mapResponse = _mapper.Map<FilterCategoryVM>(response);
            return View(mapResponse); 
        }
        #endregion

        #endregion

        #region Product
        #region filter-products
        public async Task<IActionResult> FilterProducts(FilterProductsVM filter)
        {
           // filter.ProductState = ProductState.All;
            var mapRequest = _mapper.Map<FilterProductsDto>(filter);
            var response = await _mediator.Send(new FilterProductsRequest() { filterProductsDto = mapRequest });
            var mapResponse = _mapper.Map<FilterProductsVM>(response);
            return View(mapResponse);
        }
        #endregion

        #region create-product
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            TempData["Categories"] = await _mediator.Send(new GetAllCategoriesRequest());
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(CreateProductVM createProduct, IFormFile productImage)
        {
            var mapProduct = _mapper.Map<CreateProductDto>(createProduct);
          
            if (ModelState.IsValid)
            {
                var command=new CreateProductCommandRequest() { CreateProductDto = mapProduct,Image=productImage };
                var response= await _mediator.Send(command);
                switch (response)
                {
                    case CreateProductResult.NotImage:
                        TempData[WarningMessage] = "لطفا برای محصول یک تصویر انتخاب کنید";
                        break;
                    case CreateProductResult.Success:
                        TempData[SuccessMessage] = "عملیات ثبت محصول با موفقیت انجام شد";
                        return RedirectToAction("FilterProducts");
                }
            }
            return View(createProduct);
        }
        #endregion

        #region edit-product
        [HttpGet]
        public async Task<IActionResult> EditProduct(long productId)
        {
            var data = await _mediator.Send(new GetEditProductRequest() { Id = productId });
            if (data == null)
            {
                return NotFound();
            }
            TempData["Categories"] = await _mediator.Send(new GetAllCategoriesRequest());
            var dataVM = _mapper.Map<EditProductVM>(data);
            return View(dataVM);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(EditProductVM editProduct)
        {
            var productDto = _mapper.Map<EditProductDto>(editProduct);
            if (ModelState.IsValid)
            {
                var command = new EditProductCommandRequest() { EditProductDto = productDto };
                var response= await _mediator.Send(command);
                switch (response)
                {
                    case EditProductResult.NotFound:
                        TempData[WarningMessage] = "محصولی با مشخصات وارد شده یافت نشد";
                        break;
                    case EditProductResult.NotProductSelectedCategoryHasNull:
                        TempData[WarningMessage] = "لطفا دسته بندی محصول را وارد کنید";
                        break;
                    case EditProductResult.Success:
                        TempData[SuccessMessage] = ".ویرایش محصول با موفقیت انجام شد";
                        return RedirectToAction("FilterProducts");
                }
            }
            TempData["Categories"] = await _mediator.Send(new GetAllCategoriesRequest());

            return View(editProduct);
        }
        #endregion

        #region delete product
        public async Task<IActionResult> DeleteProduct(long productId)
        {
            var result = await _mediator.Send(new DeleteProductCommandRequest() { Id = productId });
            if (result)
            {
                TempData[SuccessMessage] = "محصول شما با موفقیت حذف شد";
                return RedirectToAction("FilterProducts");
            }

            TempData[WarningMessage] = "در حذف محصول خطایی رخ داده است";
            return RedirectToAction("FilterProducts");
        }
        #endregion

        #region recover producr
        public async Task<IActionResult> RecoverProduct(long productId)
        {
            var result = await _mediator.Send(new RecoveryProductCommandRequest() { Id = productId });

            if (result)
            {
                TempData[SuccessMessage] = "محصول شما با موفقیت بازگردانی شد";
                return RedirectToAction("FilterProducts");

            }

            TempData[WarningMessage] = "در بازگردانی محصول خطایی رخ داده است";
            return RedirectToAction("FilterProducts");
        }
        #endregion


        #endregion

        #region Gallery
        #region create
        public IActionResult GalleryProduct(long productId)
        {
            ViewBag.productId = productId;
            return View();
        }


        public async Task<IActionResult> AddImageToProduct(List<IFormFile> images, long productId)
        {
            var command=new AddProductGalleryCommandRequest() { Id=productId ,Images=images};
            var response =await _mediator.Send(command);
            if (response)
            {
                return JsonResponseStatus.Success();
            }
            return JsonResponseStatus.Error();
        }
        #endregion
        #region list product galleries
        public async Task<IActionResult> ProductGalleries(long productId)
        {
            var data = await _mediator.Send(new GetAllProductGalleriesRequest() { Id = productId });

            return View(data);
        }
        #endregion

        #region delete image
        public async Task<IActionResult> DeleteImage(long galleryId)
        {
            var command=new DeleteImageCommandRequest() { Id=galleryId };
            var response=await _mediator.Send(command);
            if (response)
            {
                TempData[InfoMessage] = "حذف با موفقیت انجام شد";
            }
            return RedirectToAction("FilterProducts");
        }
        #endregion
        #endregion
    }
}
