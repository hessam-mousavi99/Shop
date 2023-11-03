using MediatR;
using Shop.Application.DTOs.Accounts;

namespace Shop.Application.Features.Product.Product.Requests.Queries
{
    public class FilterComparesRequest:IRequest<UserCompareDto>
    {
        public UserCompareDto UserCompareDto { get; set; }
    }
}
