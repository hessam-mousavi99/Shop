using Shop.Application.Contracts.Infrastructure.IServices;
using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;

namespace Shop.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public  bool CheckPermission(long permissionId, string phoneNumber)
        {
            return _userRepository.CheckPermission(permissionId, phoneNumber);
        }
    }
}
