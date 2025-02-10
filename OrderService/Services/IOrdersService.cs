using MongoDB.Driver;
using OrderService.Models;

namespace OrderService.Services;

public interface IOrdersService
{
    public Task<IEnumerable<Order?>> GetAllAsync();
    public Task<IAsyncCursor<Order>> GetByIdAsync(int id);
    public Task CreateAsync(Order order);
    public Task UpdateAsync(Order order);
    public Task DeleteAsync(int id);
}