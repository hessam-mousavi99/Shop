using Moq;
using Shop.Application.Contracts.Persistence.IRepositories.IAccounts;
using Shop.Domain.Models.Account;

namespace Shop.Application.UnitTests.Mocks.Accounts
{
    public static class MockUserRepository
    {
        public static Mock<IUserRepository> GetUserRepository()
        {
            var users = new List<User>()
            {
                new User
                {
                    Id = 1,
                    FirstName = "Hessam",
                    LastName="Mousavi",
                    PhoneNumber="09118898014",
                    Password="123456",
                    IsBlocked=false,
                    Avatar="Image1.jpg",
                    Gender=Domain.Enums.UserGender.Male,
                    ActiveCode="123abc",
                    IsActive=false,
                    IsDelete=false,
                    CreateDate=DateTime.Now,
                },
                new User
                {
                    Id = 2,
                    FirstName = "hasan",
                    LastName="Mousavi",
                    PhoneNumber="09361118858",
                    Password="654321",
                    IsBlocked=false,
                    Avatar="Image2.jpg",
                    Gender=Domain.Enums.UserGender.Male,
                    ActiveCode="abc123",
                    IsActive=false,
                    IsDelete=false,
                    CreateDate=DateTime.Now,
                }
            };
            var mockRepo=new Mock<IUserRepository>();

            mockRepo.Setup(x=>x.GetAllAsync()).ReturnsAsync(users);

            mockRepo.Setup(x => x.AddAsync(It.IsAny<User>())).ReturnsAsync((User user) =>
            {
                users.Add(user);
                return user;
            });
            return mockRepo;
        }
    }
}
