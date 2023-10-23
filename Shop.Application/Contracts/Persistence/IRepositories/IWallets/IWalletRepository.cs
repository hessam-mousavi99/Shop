using Shop.Application.Contracts.Persistence.IRepositories.IGenerics;
using Shop.Application.DTOs.Wallet;
using Shop.Domain.Models.Wallet;

namespace Shop.Application.Contracts.Persistence.IRepositories.IWallets
{
    public interface IWalletRepository: IGenericRepository<UserWallet>
    {
        Task<FilterWalletDto> FilterWallets(FilterWalletDto filter);
        Task SaveChangesAsync();
    }
}
