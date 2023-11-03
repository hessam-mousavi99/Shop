using MediatR;
using Shop.Application.DTOs.Accounts;

namespace Shop.Application.Features.Product.Product.Requests.Queries
{
    public class FilterFavoritesRequest : IRequest<UserFavoriteDto>
    {
        public UserFavoriteDto UserFavoriteDto { get; set; }
    }
}
