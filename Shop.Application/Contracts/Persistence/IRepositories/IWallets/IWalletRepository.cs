using Shop.Application.Contracts.Persistence.IRepositories.IGenerics;
using Shop.Domain.Models.Wallet;

namespace Shop.Application.Contracts.Persistence.IRepositories.IWallets
{
    public interface IWalletRepository: IGenericRepository<UserWallet>
    {
        Task SaveChangesAsync();
    }
}
