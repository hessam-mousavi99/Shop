using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;
using Shop.Application.Features.Account.Permissions.Requests.Queries;
using Shop.Domain.Models.Account;

namespace Shop.Application.Features.Account.Permissions.Handlers.Queries
{
    public class GetAllActivePermissionsRequestHandler : IRequestHandler<GetAllActivePermissionsRequest, List<Permission>>
    {
        private readonly IPermissionRepository _permissionRepository;

        public GetAllActivePermissionsRequestHandler(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }
        public async Task<List<Permission>> Handle(GetAllActivePermissionsRequest request, CancellationToken cancellationToken)
        {
            return await _permissionRepository.GetAllAsync();
        }
    }
}
