using MediatR;

namespace Catalog.Application.Products.DeleteById;

public class DeleteProductByIdCommand (string id) : IRequest<bool>
{
    public string Id { get; set; } = id;
}