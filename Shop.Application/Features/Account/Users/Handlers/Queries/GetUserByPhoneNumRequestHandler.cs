using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;
using Shop.Application.DTOs.Accounts;
using Shop.Application.Features.Account.Users.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.Account.Users.Handlers.Queries
{
    internal class GetUserByPhoneNumRequestHandler : IRequestHandler<GetUserByPhoneNumRequest, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByPhoneNumRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserDto> Handle(GetUserByPhoneNumRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserbyPhoneNumberAsync(request.PhoneNumber);
            return _mapper.Map<UserDto>(user);
        }
    }
}
