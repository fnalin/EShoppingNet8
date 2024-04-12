using Catalog.Core.Contracts.Repositories;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data.Repositories;

public class ProductRepository(ICatalogContext context) : IProductRepository, IBrandRepository, ITypeRepository
{
    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await context.Products.Find(p => true).ToListAsync();
    }

    public async Task<Product> GetProductByIdAsync(string id)
    {
        return await context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
    }

    public async  Task<IEnumerable<Product>> GetProductsByNameAsync(string name)
    {
        var filter = Builders<Product>.Filter.Eq(p => p.Name, name);
        return await context.Products.Find(filter).ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsByBrandAsync(string brand)
    {
        var filter = Builders<Product>.Filter.Eq(p => p.Brands.Name, brand);
        return await context.Products.Find(filter).ToListAsync();
    }

    public async Task<Product> CreateProductAsync(Product product)
    {
        await context.Products.InsertOneAsync(product);
        return product;
    }

    public async Task<bool> UpdateProductAsync(Product product)
    {
        var updateResult = 
            await context.Products.ReplaceOneAsync(filter: p => p.Id == product.Id, replacement: product);
        return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
    }

    public async Task<bool> DeleteProductAsync(string id)
    {
        var filter = Builders<Product>.Filter.Eq(p => p.Id, id);
        var deleteResult = await context.Products.DeleteOneAsync(filter);
        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }

    public async Task<IEnumerable<ProductBrand>> GetAllBrandsAsync()
    {
        return await context.Brands.Find(p => true).ToListAsync();
    }

    public async Task<IEnumerable<ProductType>> GetAllTypesAsync()
    {
        return await context.Types.Find(p => true).ToListAsync();
    }
}