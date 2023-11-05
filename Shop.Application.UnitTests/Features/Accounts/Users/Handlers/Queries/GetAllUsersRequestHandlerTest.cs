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
    public class GetAllUsersRequestHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUserRepository> _mockRepository;
        public GetAllUsersRequestHandlerTest()
        {
            _mockRepository = MockUserRepository.GetUserRepository();
            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile<MappingProfile>();
            });
            _mapper=mapperConfig.CreateMapper();
        }
        [Fact]
        public async Task GetUserListAsyncTest()
        {
            var handler=new GetAllUsersRequestHandler(_mockRepository.Object,_mapper);
            var result = await handler.Handle(new GetAllUsersRequest(), CancellationToken.None);
            result.ShouldBeOfType<List<UserDto>>();
            result.Count.ShouldBe(2);
        }
    }
}
