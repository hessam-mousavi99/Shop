namespace Shop.Application.Contracts.Infrastructure.IServices
{
    public interface ISmsService
    {
        Task SendVerificationCodeAsync(string mobile,string activeCode);
    }
}
