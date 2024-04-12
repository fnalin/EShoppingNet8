using Catalog.Core.Entities;

namespace Catalog.Core.Contracts.Repositories;

public interface ITypeRepository : IRepository
{
    Task<IEnumerable<ProductType>> GetAllTypesAsync();
}