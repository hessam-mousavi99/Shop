﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.DTOs.Admin.Product;
using Shop.Application.Features.Product.Category.Requests.Commands;
using Shop.Application.Features.Product.Category.Requests.Queries;
using Shop.Application.Features.Product.Product.Requests.Commands;
using Shop.Application.Features.Product.Product.Requests.Queries;
using Shop.Domain.Enums;
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
            filter.ProductState = ProductState.All;
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
            //TempData["Categories"] = await _mediator.Send(new GetAllCategoriesRequest());
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
        #endregion
    }
}