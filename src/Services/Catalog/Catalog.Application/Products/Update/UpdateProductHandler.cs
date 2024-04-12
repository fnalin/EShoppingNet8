using Catalog.Core.Contracts.Repositories;
using MediatR;

namespace Catalog.Application.Products.Update;

public class UpdateProductHandler (IProductRepository productRepository) : IRequestHandler<UpdateProductCommand, bool>
{
    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = request.ToEntity();
        var response = await productRepository.UpdateProductAsync(entity);
        return response;
    }
}