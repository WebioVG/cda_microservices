using MongoDB.Driver;
using OrderService.Models;

namespace OrderService.Repositories;

public interface IOrderRepository
{
    public Task<IEnumerable<Order>> GetAllAsync();
    public Task<IAsyncCursor<Order>> GetById(int id);
    public Task CreateAsync(Order order);
    public Task UpdateAsync(Order order);
    public Task DeleteAsync(int id);
}