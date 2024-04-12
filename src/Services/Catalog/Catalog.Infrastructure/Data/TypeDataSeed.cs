using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public static class TypeDataSeed
{
    public static void SeedData(IMongoCollection<ProductType> typeCollection)
    {
        var existType = typeCollection.Find(p => true).Any();
        if (!existType)
        {
            typeCollection.InsertMany(GetPreconfiguredTypes());
        }
    }

    private static IEnumerable<ProductType> GetPreconfiguredTypes()
    {
        // var path = Path.Combine("Data", "SeedData", "types.json");
        var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "SeedData", "types.json");
        var typesData = File.ReadAllText(path);
        return JsonSerializer.Deserialize<List<ProductType>>(typesData) ?? Enumerable.Empty<ProductType>();
    }
}