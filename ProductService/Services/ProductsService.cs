using ProductService.Data;
using ProductService.Repositories;

namespace ProductService.Services;

public class ProductsService(IProductRepository productRepository) : IProductsService
{
    public async Task<List<Product?>> GetAllAsync()
    {
        return await productRepository.GetAllAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await productRepository.GetByIdAsync(id);
    }

    public async Task CreateAsync(Product product)
    {
        await productRepository.CreateAsync(product);
    }

    public async Task UpdateAsync(Product product)
    {
        await productRepository.UpdateAsync(product);
    }

    public async Task DeleteAsync(int id)
    {
        await productRepository.DeleteAsync(id);
    }
}