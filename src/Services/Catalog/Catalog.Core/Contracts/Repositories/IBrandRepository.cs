using Catalog.Core.Entities;

namespace Catalog.Core.Contracts.Repositories;

public interface IBrandRepository : IRepository
{
    Task<IEnumerable<ProductBrand>> GetAllBrandsAsync();
}