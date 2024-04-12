using MediatR;

namespace Catalog.Application.Products.GetByBrand;

public class GetByBrandProductQuery (string brand) : IRequest<IEnumerable<ProductResponse>>
{
    public string Brand { get; set; } = brand;
}