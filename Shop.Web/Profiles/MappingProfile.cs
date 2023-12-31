﻿using AutoMapper;
using Shop.Application.DTOs.Accounts;
using Shop.Application.DTOs.Admin.Account;
using Shop.Application.DTOs.Admin.Order;
using Shop.Application.DTOs.Admin.Product;
using Shop.Application.DTOs.Admin.SiteSetting.Slider;
using Shop.Application.DTOs.Site;
using Shop.Application.DTOs.Wallet;
using Shop.Web.Models.VM.Account;
using Shop.Web.Models.VM.Admin.Account;
using Shop.Web.Models.VM.Admin.Order;
using Shop.Web.Models.VM.Admin.Product;
using Shop.Web.Models.VM.Site.Products;
using Shop.Web.Models.VM.Site.Slider;
using Shop.Web.Models.VM.Wallet;

namespace Shop.Web.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region User Mapping

            CreateMap<CreateUserDto, RegisterVM>().ReverseMap();
            CreateMap<LoginDto, LoginVm>().ReverseMap();
            CreateMap<ActiveAccountDto, ActiveAccountVM>().ReverseMap();
            CreateMap<UserDto, UserVM>().ReverseMap();
            CreateMap<EditUserProfileDto, EditUserProfileVM>().ReverseMap();
            CreateMap<ChangePasswordDto, ChangePasswordVM>().ReverseMap();
            CreateMap<FinalyOrderDto, FinallyOrderVM>().ReverseMap();
            CreateMap<FilterOrdersDto, FilterOrdersVM>().ReverseMap();
            CreateMap<UserCompareDto, UserComparesVM>().ReverseMap();
            CreateMap<UserFavoriteDto, UserFavoritsVM>().ReverseMap();

            #endregion

            #region Wallet Mapping

            CreateMap<ChargeWalletDto, ChargeWalletVM>().ReverseMap();
            CreateMap<WalletDto, WalletVM>().ReverseMap();
            CreateMap<FilterWalletDto, FilterWalletVM>().ReverseMap();

            #endregion

            #region Admin
            
            #region User
            CreateMap<FilterUserDto, FilterUserVM>().ReverseMap();
            CreateMap<FilterRolesDto, FilterRolesVM>().ReverseMap();
            CreateMap<EditUserFromAdminDto, EditUserFromAdminVM>().ReverseMap();
            CreateMap<CreateOrEditRoleDto, CreateOrEditRoleVM>().ReverseMap();
            #endregion

            #region Product
            CreateMap<CreateCategoryDto, CreateCategoryVM>().ReverseMap();
            CreateMap<FilterProductsDto, FilterProductsVM>().ReverseMap();
            CreateMap<FilterCategoryDto, FilterCategoryVM>().ReverseMap();
            CreateMap<EditCategoryDto, EditCategoryVM>().ReverseMap();
            CreateMap<CreateProductDto, CreateProductVM>().ReverseMap();
            CreateMap<EditProductDto, EditProductVM>().ReverseMap();
            CreateMap<CreateFeatureDto, CreateFeatureVM>().ReverseMap();
            #endregion

            #region SiteSetting
            CreateMap<FilterSlidersDto, FilterSlidersVM>().ReverseMap();
            CreateMap<CreateSliderDto, CreateSliderVM>().ReverseMap();
            CreateMap<EditSliderDto, EditSliderVM>().ReverseMap();
            CreateMap<ProductDetailDto, ProductDetailVM>().ReverseMap();
            CreateMap<CreateProductCommentDto, CreateProductCommentVM>().ReverseMap();
            #endregion

            #region Order
            CreateMap<OrderStateResaultDto, OrderStateResaultVM>().ReverseMap();
            #endregion
            #endregion
        }
    }
}
