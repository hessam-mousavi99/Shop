namespace Shop.Application.Contracts.Infrastructure.IServices
{
    public interface IUserService
    {
        bool CheckPermission(long permissionId, string phoneNumber);
    }
}
