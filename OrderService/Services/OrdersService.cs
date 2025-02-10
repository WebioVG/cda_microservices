using MongoDB.Driver;
using OrderService.Models;
using OrderService.Repositories;

namespace OrderService.Services;

public class OrdersService(IOrderRepository orderRepository) : IOrdersService
{
    public async Task<IEnumerable<Order?>> GetAllAsync()
    {
        return await orderRepository.GetAllAsync();
    }

    public async Task<IAsyncCursor<Order>> GetByIdAsync(int id)
    {
        return await orderRepository.GetById(id);
    }

    public async Task CreateAsync(Order order)
    {
        await orderRepository.CreateAsync(order);
    }

    public async Task UpdateAsync(Order order)
    {
        await orderRepository.UpdateAsync(order);
    }

    public async Task DeleteAsync(int id)
    {
        await orderRepository.DeleteAsync(id);
    }
}