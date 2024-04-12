using Catalog.Core.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public class CatalogContext : ICatalogContext
{
    public IMongoCollection<Product> Products { get; } = null!;
    public IMongoCollection<ProductType> Types { get; } = null!;
    public IMongoCollection<ProductBrand> Brands { get; } = null!;

    public CatalogContext(IConfiguration configuration)
    {
        var connectionString = configuration.GetValue<string>("DatabaseSettings:ConnectionString");
        if (connectionString is null) return;
        
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase("CatalogDb");

        Products = database.GetCollection<Product>("Products");
        Types = database.GetCollection<ProductType>("Types");
        Brands = database.GetCollection<ProductBrand>("Brands");
        
        BrandDataSeed.SeedData(Brands);
        TypeDataSeed.SeedData(Types);
        ProductDataSeed.SeedData(Products);
    }
}