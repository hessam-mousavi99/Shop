using MediatR;

namespace Shop.Application.Features.Product.Feature.Requests.Commands
{
    public class DeleteFeatureCommandRequest:IRequest
    {
        public long Id { get; set; }
    }
}
