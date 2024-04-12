using Catalog.Core.Contracts.Repositories;
using MediatR;

namespace Catalog.Application.Products.Create;

public class CreateProductHandler (IProductRepository productRepository) : IRequestHandler<CreateProductCommand, ProductResponse>
{
    public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = request.ToEntity();
        var newProduct = await productRepository.CreateProductAsync(entity);
        var response = newProduct.ToResponse();
        return response;
    }
}