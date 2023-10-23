using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;
using Shop.Application.DTOs.Accounts;
using Shop.Application.Features.Account.Users.Requests.Queries;

namespace Shop.Application.Features.Account.Users.Handlers.Queries
{
    public class GetEditUserProfileRequestHandler : IRequestHandler<GetEditUserProfileRequest, EditUserProfileDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetEditUserProfileRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
           _userRepository = userRepository;
           _mapper = mapper;
        }
        public async Task<EditUserProfileDto> Handle(GetEditUserProfileRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.Id);
            if (user == null)
            {
                return null;
            }
            var edituser= _mapper.Map<EditUserProfileDto>(user);
            return edituser;
        }
    }
}
