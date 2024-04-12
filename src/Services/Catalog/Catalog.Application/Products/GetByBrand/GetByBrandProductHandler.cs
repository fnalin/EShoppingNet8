using Catalog.Core.Contracts.Repositories;
using MediatR;

namespace Catalog.Application.Products.GetByBrand;

public class GetByBrandProductHandler (IProductRepository productRepository) : IRequestHandler<GetByBrandProductQuery, IEnumerable<ProductResponse>>
{
    public async Task<IEnumerable<ProductResponse>> Handle(GetByBrandProductQuery request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetProductsByBrandAsync(request.Brand);
        var response = product.Select(p => p.ToResponse());
        return response;
    }
}