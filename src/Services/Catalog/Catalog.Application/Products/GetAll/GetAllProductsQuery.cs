using MediatR;

namespace Catalog.Application.Products.GetAll;

public class GetAllProductsQuery : IRequest<IEnumerable<ProductResponse>>
{
    
}