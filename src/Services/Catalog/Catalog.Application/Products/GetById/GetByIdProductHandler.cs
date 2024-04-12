using Catalog.Core.Contracts.Repositories;
using MediatR;

namespace Catalog.Application.Products.GetById;

public class GetByIdProductHandler (IProductRepository productRepository) : IRequestHandler<GetByIdProductQuery, ProductResponse>
{
    public async Task<ProductResponse> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetProductByIdAsync(request.Id);
        var response = product.ToResponse();
        return response;
    }
}