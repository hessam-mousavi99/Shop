using AutoMapper;
using Shop.Application.DTOs.Accounts;
using Shop.Domain.Models.Account;
using Shop.Web.VM.Account;

namespace Shop.Web.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region User Mapping

            CreateMap<CreateUserDto, RegisterVM>().ReverseMap();
            CreateMap<LoginDto, LoginVm>().ReverseMap();
           
            #endregion
        }
    }
}
