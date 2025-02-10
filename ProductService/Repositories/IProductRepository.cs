using ProductService.Data;

namespace ProductService.Repositories;

public interface IProductRepository
{
    public Task<List<Product?>> GetAllAsync();
    public Task<Product?> GetByIdAsync(int id);
    public Task CreateAsync(Product product);
    public Task UpdateAsync(Product product);
    public Task DeleteAsync(int id);
}