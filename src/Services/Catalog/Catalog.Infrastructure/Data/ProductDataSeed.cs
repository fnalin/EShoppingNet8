using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public static class ProductDataSeed
{
    public static void SeedData(IMongoCollection<Product> productCollection)
    {
        var existProduct = productCollection.Find(p => true).Any();
        if (!existProduct)
        {
            productCollection.InsertMany(GetPreconfiguredProducts());
        }
    }

    private static IEnumerable<Product> GetPreconfiguredProducts()
    {
        //var path = Path.Combine("Data", "SeedData", "products.json");
        var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "SeedData", "products.json");
        var productsData = File.ReadAllText(path);
        return JsonSerializer.Deserialize<List<Product>>(productsData) ?? Enumerable.Empty<Product>();
    }
}