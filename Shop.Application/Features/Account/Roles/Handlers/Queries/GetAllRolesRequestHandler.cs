using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;
using Shop.Application.Features.Account.Roles.Requests.Queries;
using Shop.Domain.Models.Account;

namespace Shop.Application.Features.Account.Roles.Handlers.Queries
{
    public class GetAllRolesRequestHandler : IRequestHandler<GetAllRolesRequest, List<Role>>
    {
        private readonly IRoleRepository _roleRepository;

        public GetAllRolesRequestHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<List<Role>> Handle(GetAllRolesRequest request, CancellationToken cancellationToken)
        {
            return await _roleRepository.GetAllAsync();
        }
    }
}
