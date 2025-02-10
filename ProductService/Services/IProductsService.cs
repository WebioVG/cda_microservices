using ProductService.Data;

namespace ProductService.Services;

public interface IProductsService
{
    public Task<List<Product?>> GetAllAsync();
    public Task<Product?> GetByIdAsync(int id);
    public Task CreateAsync(Product product);
    public Task UpdateAsync(Product product);
    public Task DeleteAsync(int id);
}