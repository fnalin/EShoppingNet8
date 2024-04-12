using Catalog.Core.Entities;

namespace Catalog.Application.Types;

public static class TypeMappers
{
    public static TypeResponse ToTypeResponse(this ProductType entity) => 
        new TypeResponse
            {
                Id = entity.Id,
                Name = entity.Name
            };
}