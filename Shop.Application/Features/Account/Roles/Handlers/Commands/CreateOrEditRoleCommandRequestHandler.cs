﻿using AutoMapper;
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
        private readonly IRolePermissionRepository _rolePermissionRepository;
        private readonly IMapper _mapper;

        public CreateOrEditRoleCommandRequestHandler(IRoleRepository roleRepository, IRolePermissionRepository rolePermissionRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _rolePermissionRepository = rolePermissionRepository;
            _mapper = mapper;
        }
        public async Task<CreateOrEditRoleResult> Handle(CreateOrEditRoleCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.CreateOrEditRoleDto.Id != 0)
            {
                //Edit
                var role = await _roleRepository.GetEditRoleById(request.CreateOrEditRoleDto.Id);
                if (role == null) { return CreateOrEditRoleResult.NotFound; }
                Role finalRole = new Role();
                finalRole.Id = request.CreateOrEditRoleDto.Id;
                finalRole.RoleTitle = request.CreateOrEditRoleDto.RoleTitle;
                await _roleRepository.UpdateAsync(finalRole);

                await _rolePermissionRepository.RemoveAllPermissionSelectedroleAsync(request.CreateOrEditRoleDto.Id);
               
                if (request.CreateOrEditRoleDto.SelectedPermission==null)
                {
                    return CreateOrEditRoleResult.NotExistPermissions;
                }
               
                await _rolePermissionRepository.AddPermissionToRoleAsync(request.CreateOrEditRoleDto.SelectedPermission, request.CreateOrEditRoleDto.Id);
                
                await _roleRepository.SaveChangesAsync();
                return CreateOrEditRoleResult.Success;
            }
            else
            {
                //Create
                Role role = new Role();
                var newRole = _mapper.Map(request.CreateOrEditRoleDto, role);
                await _roleRepository.AddAsync(newRole);
                if (request.CreateOrEditRoleDto.SelectedPermission == null)
                {
                    return CreateOrEditRoleResult.NotExistPermissions;
                }
                await _rolePermissionRepository.AddPermissionToRoleAsync(request.CreateOrEditRoleDto.SelectedPermission,newRole.Id);
                await _roleRepository.SaveChangesAsync();
                return CreateOrEditRoleResult.Success;
            }
        }
    }
}
