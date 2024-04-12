using MediatR;

namespace Catalog.Application.Products.Create;

public class CreateProductCommand : IRequest<ProductResponse>
{
    public string Name { get; set; } = null!;
    public string Summary { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageFile { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public ProductBrandCommand Brand { get; set; } = null!;
    public ProductTypeCommand Type { get; set; } = null!;


    public class ProductBrandCommand { 
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
    }

    public class ProductTypeCommand { 
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}