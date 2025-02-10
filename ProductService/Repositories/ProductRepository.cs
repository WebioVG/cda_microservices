using Microsoft.EntityFrameworkCore;
using ProductService.Data;

namespace ProductService.Repositories;

public class ProductRepository(ProductContext context) : IProductRepository
{
    public async Task<List<Product?>> GetAllAsync()
    {
        return await context.Products.ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await context.Products.FindAsync(id);
    }

    public async Task CreateAsync(Product product)
    {
        await context.Products.AddAsync(product);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        context.Products.Update(product);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var product = await context.Products.FindAsync(id);
        if (product == null) return;
        
        context.Products.Remove(product);
        await context.SaveChangesAsync();
    }
}