using MediatR;

namespace Catalog.Application.Products.GetById;

public class GetByIdProductQuery(string id) : IRequest<ProductResponse>
{
    public string Id { get; set; } = id;
}