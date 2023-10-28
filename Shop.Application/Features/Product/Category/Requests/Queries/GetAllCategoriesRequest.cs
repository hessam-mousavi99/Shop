using MediatR;

namespace Shop.Application.Features.Product.Category.Requests.Queries
{
    public class GetAllCategoriesRequest:IRequest<List<Shop.Domain.Models.ProductEntities.Category>>
    {
    }
}
