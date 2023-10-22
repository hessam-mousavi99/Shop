using Kavenegar;
using Shop.Application.Contracts.Infrastructure.IServices;

namespace Shop.Infrastructure.Services
{
    public class SmsService : ISmsService
    {
        public string ApiKey = "6466666A38394F692B66724A5A682F41487430466B505A577A5643426A634D6438385545616E63496F32453D";
        public async Task SendVerificationCodeAsync(string mobile, string activeCode)
        {
            KavenegarApi api = new KavenegarApi(ApiKey);
            await api.VerifyLookup(mobile, activeCode,"Shop");
        }
    }
}
