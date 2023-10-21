namespace Shop.Application.Contracts.Infrastructure.IServices
{
    public interface IPasswordHelper
    {
        string EncodePasswordMd5(string password);
    }
}
