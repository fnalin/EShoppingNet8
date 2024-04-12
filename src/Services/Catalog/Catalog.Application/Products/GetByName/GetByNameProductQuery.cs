using MediatR;

namespace Catalog.Application.Products.GetByName;

public class GetByNameProductQuery (string name) : IRequest<IEnumerable<ProductResponse>>
{
    public string Name { get; set; } = name;
}