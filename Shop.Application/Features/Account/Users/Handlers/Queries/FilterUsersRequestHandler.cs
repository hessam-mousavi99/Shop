using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;
using Shop.Application.DTOs.Admin.Account;
using Shop.Application.Features.Account.Users.Requests.Queries;

namespace Shop.Application.Features.Account.Users.Handlers.Queries
{
    public class FilterUsersRequestHandler : IRequestHandler<FilterUsersRequest, FilterUserDto>
    {
        private readonly IUserRepository _userRepository;
       

        public FilterUsersRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<FilterUserDto> Handle(FilterUsersRequest request, CancellationToken cancellationToken)
        {
            return await _userRepository.FilterUserAsync(request.FilterUserDto);
        }
    }
}
