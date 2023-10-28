using MediatR;
using Shop.Application.Contracts.Persistence.IRepositories.IProductEntities;
using Shop.Application.Features.Product.Category.Requests.Queries;

namespace Shop.Application.Features.Product.Category.Handlers.Queries
{
    public class GetAllCategoriesRequestHandler : IRequestHandler<GetAllCategoriesRequest, List<Shop.Domain.Models.ProductEntities.Category>>
    {
        private readonly ICategoryRepository _categoryRepository;
        public GetAllCategoriesRequestHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public Task<List<Domain.Models.ProductEntities.Category>> Handle(GetAllCategoriesRequest request, CancellationToken cancellationToken)
        {
            return _categoryRepository.GetAllAsync();
        }
    }
}
