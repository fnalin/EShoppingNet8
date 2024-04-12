using Catalog.Core.Contracts.Repositories;
using MediatR;

namespace Catalog.Application.Brands.GetAll;

public class GetAllBrandsHandler (IBrandRepository brandRepository) : IRequestHandler<GetAllBrandsQuery, IEnumerable<BrandResponse>>
{
    public async Task<IEnumerable<BrandResponse>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
    {
        var brandList = await brandRepository.GetAllBrandsAsync();
        var response = brandList.Select(brand => brand.ToResponse());
        return response;
    }
}