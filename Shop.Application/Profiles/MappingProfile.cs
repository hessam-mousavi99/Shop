using AutoMapper;
using Shop.Application.DTOs.Accounts;
using Shop.Application.DTOs.Admin.Account;
using Shop.Application.DTOs.Admin.Product;
using Shop.Application.DTOs.Wallet;
using Shop.Domain.Models.Account;
using Shop.Domain.Models.ProductEntities;
using Shop.Domain.Models.Wallet;

namespace Shop.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region User Mapping

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, LoginDto>().ReverseMap();
            CreateMap<User, ActiveAccountDto>().ReverseMap();
            CreateMap<User, EditUserProfileDto>().ReverseMap();         
            CreateMap<User, ChangePasswordDto>().ReverseMap();

            #endregion

            #region Wallet Mapping

            CreateMap<UserWallet, ChargeWalletDto>().ReverseMap();
            CreateMap<UserWallet, WalletDto>().ReverseMap();
            CreateMap<User, EditUserFromAdminDto>().ReverseMap();

            #endregion

            #region Role Mapping

            CreateMap<Role, CreateOrEditRoleDto>().ReverseMap();

            #endregion

            #region Product Mapping

            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, EditCategoryDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();

            #endregion
        }
    }
}
