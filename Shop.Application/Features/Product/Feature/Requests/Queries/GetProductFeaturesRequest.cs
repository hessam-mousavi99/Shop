using MediatR;
using Shop.Domain.Models.ProductEntities;

namespace Shop.Application.Features.Product.Feature.Requests.Queries
{
    public class GetProductFeaturesRequest:IRequest<List<ProductFeature>>
    {
        public long ProductId { get; set; }
    }
}
