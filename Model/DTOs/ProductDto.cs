using TP_SOMEI.Model.Entities;

namespace TP_SOMEI.Model.DTOs;

public class ProductDto
{
    public string? ProductName { get; set; }
    public string? UserId { get; set; }
    public string? ProductDescription { get; set; }
    public string? ProductImageUrl { get; set; }
    

    public static Product FromProductDtoToProduct(ProductDto productDto)
    {
        var product = new Product
        {
            ProductName = productDto.ProductName,
            UserId = productDto.UserId,
            ProductDescription = productDto.ProductDescription,
            ProductImageUrl = productDto.ProductImageUrl,
        };
        return product;
    }
}