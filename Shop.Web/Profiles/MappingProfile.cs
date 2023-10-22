using AutoMapper;
using Shop.Application.DTOs.Accounts;
using Shop.Web.Models.VM.Account;

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
           
            #endregion
        }
    }
}
