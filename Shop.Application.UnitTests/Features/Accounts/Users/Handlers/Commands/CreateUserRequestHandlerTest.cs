using AutoMapper;
using Moq;
using Shop.Application.Contracts.Infrastructure.IServices;
using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;
using Shop.Application.DTOs.Accounts;
using Shop.Application.Features.Account.Users.Handlers.Commands;
using Shop.Application.Features.Account.Users.Requests.Commands;
using Shop.Application.Profiles;
using Shop.Application.UnitTests.Mocks.Accounts;
using Shop.Domain.Enums;
using Shop.Infrastructure.Services;
using Shouldly;

namespace Shop.Application.UnitTests.Features.Accounts.Users.Handlers.Commands
{
    public class CreateUserRequestHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUserRepository> _mockRepository;
        private readonly CreateUserDto _createUserDto;
        private readonly IPasswordHelper _passwordHelper;
        private readonly ISmsService _smsService;
        public CreateUserRequestHandlerTest()
        {
            _mockRepository = MockUserRepository.GetUserRepository();
            var mapperConfig = new MapperConfiguration(m =>
            {
                m.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _passwordHelper = new PasswordHelper();
            _smsService = new SmsService();
            _createUserDto=new CreateUserDto() 
            {
                FirstName = "hasan",
                LastName = "Mousavi",
                PhoneNumber = "09361118858",
                Password = "654321",
                IsBlocked = false,
                Avatar = "Image3.jpg",
                Gender = Domain.Enums.UserGender.Male,
                ActiveCode = "abc123",
                IsActive = false,
                IsDelete = false,
                CreateDate = DateTime.Now,
            };
        }
        [Fact]
        public async Task CreateUserAsyncTest()
        {
            var handler = new CreateUserRequestHandler(_mockRepository.Object, _mapper,_passwordHelper,_smsService);
            var result = await handler.Handle(new CreateUserRequest()
            {
                CreateUserDto = _createUserDto
            }, CancellationToken.None);
            //This test goes to fail because of SmsService
            result.ShouldBeOfType<RegisterUserResult>();
            
            var users = await _mockRepository.Object.GetAllAsync();

            users.Count.ShouldBe(3);
        }
    }
}
