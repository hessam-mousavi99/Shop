using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;
using Shop.Application.Features.Account.Roles.Requests.Commands;
using Shop.Domain.Enums;
using Shop.Domain.Models.Account;

namespace Shop.Application.Features.Account.Roles.Handlers.Commands
{
    public class CreateOrEditRoleCommandRequestHandler : IRequestHandler<CreateOrEditRoleCommandRequest, CreateOrEditRoleResult>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public CreateOrEditRoleCommandRequestHandler(IRoleRepository roleRepository,IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }
        public async Task<CreateOrEditRoleResult> Handle(CreateOrEditRoleCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.CreateOrEditRoleDto.Id != 0)
            {
                //Edit
                var role = await _roleRepository.GetAsync(request.CreateOrEditRoleDto.Id);
                if (role == null) { return CreateOrEditRoleResult.NotFound; }

                role.RoleTitle = request.CreateOrEditRoleDto.RoleTitle;
                await _roleRepository.UpdateAsync(role);
                await _roleRepository.SaveChangesAsync();
                return CreateOrEditRoleResult.Success;
            }
            else
            {
                //Create
                Role role=new Role();
                var newRole = _mapper.Map(request.CreateOrEditRoleDto,role);
                await _roleRepository.AddAsync(newRole);
                await _roleRepository.SaveChangesAsync();
                return CreateOrEditRoleResult.Success;
            }
        }
    }
}
