using MediatR;

namespace Shop.Application.Features.Product.Gallery.Requests.Command
{
    public class DeleteImageCommandRequest:IRequest<bool>
    {
        public long Id { get; set; }
    }
}
