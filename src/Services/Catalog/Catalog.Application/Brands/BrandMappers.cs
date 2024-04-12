using Catalog.Core.Entities;

namespace Catalog.Application.Brands;

public static class BrandMappers
{
    public static BrandResponse ToResponse(this ProductBrand entity) => new BrandResponse
    {
        Id = entity.Id,
        Name = entity.Name
    };
}