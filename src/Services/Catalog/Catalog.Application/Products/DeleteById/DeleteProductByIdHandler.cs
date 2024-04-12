using Catalog.Core.Contracts.Repositories;
using MediatR;

namespace Catalog.Application.Products.DeleteById;

public class DeleteProductByIdHandler (IProductRepository productRepository) : IRequestHandler<DeleteProductByIdCommand, bool>
{
    public async Task<bool> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
    {
        var response = await productRepository.DeleteProductAsync(request.Id);
        return response;
    }
}