using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;
using Shop.Application.DTOs.Admin.Account;
using Shop.Application.Features.Account.Users.Requests.Queries;

namespace Shop.Application.Features.Account.Users.Handlers.Queries
{
    public class GetUserForEditInAdminRequestHandler : IRequestHandler<GetUserForEditInAdminRequest, EditUserFromAdminDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserForEditInAdminRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<EditUserFromAdminDto> Handle(GetUserForEditInAdminRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.Id);
            if (user == null)
            {
                return null;
            }
            var edituser = _mapper.Map<EditUserFromAdminDto>(user);
            return edituser;
        }
    }
}
