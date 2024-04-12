using Catalog.Core.Contracts.Repositories;
using MediatR;

namespace Catalog.Application.Products.GetByName;

public class GetByNameProductHandler (IProductRepository productRepository) : IRequestHandler<GetByNameProductQuery, IEnumerable<ProductResponse>>
{
    public async Task<IEnumerable<ProductResponse>> Handle(GetByNameProductQuery request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetProductsByNameAsync(request.Name);
        var response = product.Select(p => p.ToResponse());
        return response;
    }
}