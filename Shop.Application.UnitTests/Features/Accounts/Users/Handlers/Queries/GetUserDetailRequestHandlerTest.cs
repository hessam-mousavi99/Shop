using AutoMapper;
using Moq;
using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;
using Shop.Application.DTOs.Accounts;
using Shop.Application.Features.Account.Users.Handlers.Queries;
using Shop.Application.Features.Account.Users.Requests.Queries;
using Shop.Application.Profiles;
using Shop.Application.UnitTests.Mocks.Accounts;
using Shouldly;

namespace Shop.Application.UnitTests.Features.Accounts.Users.Handlers.Queries
{
    public class GetUserDetailRequestHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUserRepository> _mockRepository;
        public GetUserDetailRequestHandlerTest()
        {
            _mockRepository = MockUserRepository.GetUserRepository();
            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }
        [Theory]
        [InlineData(20)]
        public async Task GetUserDetailAsyncTest(long Id)
        {
            var handler = new GetUserDetailRequestHandler(_mockRepository.Object, _mapper);
            var resault = await handler.Handle(new GetUserDetailRequest() { Id = Id }, CancellationToken.None);
            resault.ShouldBeNull<UserDto>("The Model is Null");
        }
        [Theory]
        [InlineData("09118898014")]
        public async Task GetUserbyPhoneNumberAsyncTest(string phoneNumber)
        {
            var handler = new GetUserByPhoneNumRequestHandler(_mockRepository.Object, _mapper);
            var resault = await handler.Handle(new GetUserByPhoneNumRequest() { PhoneNumber = phoneNumber }, CancellationToken.None);
            resault.ShouldBeNull<UserDto>("The Model is Null");
        }
    }
}
