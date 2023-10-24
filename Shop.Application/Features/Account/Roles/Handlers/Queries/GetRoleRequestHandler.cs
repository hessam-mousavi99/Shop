using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;
using Shop.Application.DTOs.Admin.Account;
using Shop.Application.Features.Account.Roles.Requests.Queries;

namespace Shop.Application.Features.Account.Roles.Handlers.Queries
{
    public class GetRoleRequestHandler : IRequestHandler<GetRoleRequest, CreateOrEditRoleDto>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public GetRoleRequestHandler(IRoleRepository roleRepository,IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }
        public async Task<CreateOrEditRoleDto> Handle(GetRoleRequest request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetAsync(request.Id);
            var mapRole = _mapper.Map<CreateOrEditRoleDto>(role);
            return mapRole;
        }
    }
}
