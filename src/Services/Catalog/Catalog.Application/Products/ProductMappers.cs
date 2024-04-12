using Catalog.Application.Products.Create;
using Catalog.Application.Products.Update;
using Catalog.Core.Entities;

namespace Catalog.Application.Products;

public static class ProductMappers
{
    public static ProductResponse ToResponse(this Product entity)
    {
        return new ProductResponse
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Price = entity.Price,
            Brand = new ProductResponse.ProductBrand(){ Id = entity.Brands.Id, Name = entity.Brands.Name },
            Type = new ProductResponse.ProductType() {Id= entity.Types.Id, Name = entity.Types.Name}
        };
    }
    
    public static Product ToEntity(this UpdateProductCommand command)
    {
        return new Product
        {
            Id = command.Id,
            Name = command.Name,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price,
            Summary = command.Summary,
            Brands = new ProductBrand() { Id = command.Brand.Id, Name = command.Brand.Name },
            Types = new ProductType() { Id = command.Type.Id, Name = command.Type.Name }
        };
    }
    
    public static Product ToEntity(this CreateProductCommand command)
    {
        return new Product
        {
            
            Name = command.Name,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price,
            Summary = command.Summary,
            Brands = new ProductBrand() { Id = command.Brand.Id, Name = command.Brand.Name },
            Types = new ProductType() { Id = command.Type.Id, Name = command.Type.Name }
        };
    }
}