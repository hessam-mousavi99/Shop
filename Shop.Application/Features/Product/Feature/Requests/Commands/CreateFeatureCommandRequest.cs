using MediatR;
using Shop.Application.DTOs.Admin.Product;
using Shop.Domain.Enums;

namespace Shop.Application.Features.Product.Feature.Requests.Commands
{
    public class CreateFeatureCommandRequest:IRequest<CreateFeatuersResult>
    {
        public CreateFeatureDto CreateFeatureDto { get; set; }
    }
}
