using Catalog.Core.Contracts.Repositories;
using MediatR;

namespace Catalog.Application.Products.GetAll;

public class GetAllProductsHandler(IProductRepository productRepository) : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductResponse>>
{
    public async Task<IEnumerable<ProductResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var productList = await productRepository.GetAllProductsAsync();
        var response = productList.Select(product => product.ToResponse());
        return response;
    }
}