using Microsoft.EntityFrameworkCore;
using TP_SOMEI.Datas;
using TP_SOMEI.Model.DTOs;
using TP_SOMEI.Model.Entities;
using TP_SOMEI.Repositories.Interfaces;

namespace TP_SOMEI.Repositories.Implementations;

public class ProductRepository(ApplicationDbContext context) : IProductRepository
{
    private readonly ApplicationDbContext _context = context;
    
    public async Task<IEnumerable<Product?>?> GetAllProducts()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsByPageNumber(int pageNumber)
    {
        if (pageNumber < 1) pageNumber = 1;
        const int defaultPageSize = 20;
        var numberToSkip = (pageNumber - 1) * defaultPageSize;
        return await _context.Products.Skip(numberToSkip)
            .Take(defaultPageSize)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsByPageNumberAndPageSize(int pageNumber, int pageSize)
    {
        if (pageNumber < 1) pageNumber = 1;
        if (pageSize < 1) pageSize = 20;
        if (pageSize > 50) pageSize = 50;
        var numberToSkip = (pageNumber - 1) * pageSize;
        return await _context.Products.Skip(numberToSkip)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<Product?> FindProductById(int productId)
    {
        return await _context.Products.Where(product => product.ProductId == productId)
            .FirstOrDefaultAsync();
    }

    public async Task<Product?> AddProduct(ProductDto productDto)
    {
        var theProduct = ProductDto.FromProductDtoToProduct(productDto);
        await _context.Products.AddAsync(theProduct);
        await _context.SaveChangesAsync();
        return theProduct;
    }

    public async Task<Product?> UpdateProduct(int productId, ProductDto productDto)
    {
        await _context.Products.Where(product => product.ProductId == productId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(product => product.ProductName, productDto.ProductName)
                    .SetProperty(product => product.ProductDescription, productDto.ProductDescription)
                    .SetProperty(product=> product.ProductImageUrl, productDto.ProductImageUrl));
        await _context.SaveChangesAsync();
        return await _context.Products.Where(product => product.ProductId == productId).FirstOrDefaultAsync();
    }

    public async Task<bool?> DeleteProduct(int productId)
    {
        try
        {
            await _context.Products.Where(product => product.ProductId == productId).ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Une exception s'est produite dans ProductRepository::DeleteProduct" + exception);
            return false;
        }
        
    }
}