using MediatR;

namespace Catalog.Application.Brands.GetAll;

public class GetAllBrandsQuery : IRequest<IEnumerable<BrandResponse>>
{
    
}