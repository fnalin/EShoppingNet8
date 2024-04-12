namespace Catalog.Application.Products;

public class ProductResponse
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Summary { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageFile { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public ProductBrand Brand { get; set; } = null!;
    public ProductType Type { get; set; } = null!;


    public class ProductBrand { 
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
    }

    public class ProductType { 
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}

