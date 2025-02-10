using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OrderService.Models;
using OrderService.Services;

namespace OrderService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController(IOrdersService ordersService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
    {
        var orders = await ordersService.GetAllAsync();
        return Ok(orders);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> GetOrder(int id)
    {
        var order = await ordersService.GetByIdAsync(id);
        if (order == null) return NotFound();
        return Ok(order);
    }
    
    [HttpPost]
    public async Task<ActionResult> CreateOrder(Order order)
    {
        await ordersService.CreateAsync(order);
        return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateOrder(int id, Order order)
    {
        if (id != order.Id) return BadRequest();
        await ordersService.UpdateAsync(order);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteOrder(int id)
    {
        await ordersService.DeleteAsync(id);
        return NoContent();
    }
}