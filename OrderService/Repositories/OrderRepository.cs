using MongoDB.Driver;
using OrderService.Models;

namespace OrderService.Repositories;

public class OrderRepository(IMongoDatabase database) : IOrderRepository
{
    private readonly IMongoCollection<Order> _orderCollection = database.GetCollection<Order>("Orders");

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await _orderCollection.Find(_ => true).ToListAsync();
    }

    public async Task<IAsyncCursor<Order>> GetById(int id)
    {
        return await _orderCollection.FindAsync(o => o.Id == id);
    }

    public async Task CreateAsync(Order order)
    {
        await _orderCollection.InsertOneAsync(order);
    }

    public async Task UpdateAsync(Order updatedOrder)
    {
        await _orderCollection.ReplaceOneAsync(o => o.Id == updatedOrder.Id, updatedOrder);
    }

    public async Task DeleteAsync(int id)
    {
        await _orderCollection.DeleteOneAsync(o => o.Id == id);
    }
}