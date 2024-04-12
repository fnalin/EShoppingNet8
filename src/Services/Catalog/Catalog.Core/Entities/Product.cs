using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Core.Entities;

public class Product : BaseEntity
{
    [BsonElement("Name")]
    public string Name { get; set; } = null!;
    public string Summary { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageFile { get; set; } = string.Empty;
    public ProductBrand Brands { get; set; } = null!;
    public ProductType Types { get; set; } = null!;
    [BsonRepresentation(BsonType.Decimal128)]
    public decimal Price { get; set; }
}