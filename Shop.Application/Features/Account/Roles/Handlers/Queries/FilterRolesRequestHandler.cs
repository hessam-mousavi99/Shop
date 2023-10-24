using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;
using Shop.Application.DTOs.Admin.Account;
using Shop.Application.Features.Account.Roles.Requests.Queries;

namespace Shop.Application.Features.Account.Roles.Handlers.Queries
{
    internal class FilterRolesRequestHandler : IRequestHandler<FilterRolesRequest, FilterRolesDto>
    {
        private readonly IRoleRepository _roleRepository;

        public FilterRolesRequestHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<FilterRolesDto> Handle(FilterRolesRequest request, CancellationToken cancellationToken)
        {
            return await _roleRepository.FilterRolesAsync(request.FilterRolesDto);
        }
    }
}
