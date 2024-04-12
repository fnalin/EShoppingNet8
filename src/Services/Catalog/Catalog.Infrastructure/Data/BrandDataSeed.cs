using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public static class BrandDataSeed
{
    public static void SeedData(IMongoCollection<ProductBrand> brandCollection)
    {
        var existBrand = brandCollection.Find(p => true).Any();
        if (existBrand) return;
        var data = GetPreconfiguredBrands();
        brandCollection.InsertMany(data);
    }

    private static IEnumerable<ProductBrand> GetPreconfiguredBrands()
    {
        //var path = Path.Combine("Data", "SeedData", "brands.json");
        var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "SeedData", "brands.json");
        var brandsData = File.ReadAllText(path);
        var response =  JsonSerializer.Deserialize<List<ProductBrand>>(brandsData) ?? Enumerable.Empty<ProductBrand>();
        return response;
    }
}