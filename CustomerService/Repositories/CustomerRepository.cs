using CustomerService.Data;
using CustomerService.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.Repositories;

public class CustomerRepository(CustomerContext context) : ICustomerRepository
{
    public async Task<IEnumerable<Customer?>> GetAllAsync()
    {
        return await context.Customers.ToListAsync();
    }

    public async Task<Customer?> GetByIdAsync(int id)
    {
        return await context.Customers.FindAsync(id);
    }

    public async Task CreateAsync(Customer customer)
    {
        await context.Customers.AddAsync(customer);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Customer customer)
    {
        context.Customers.Update(customer);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var customer = await context.Customers.FindAsync(id);
        if (customer == null) return;
        
        context.Customers.Remove(customer);
        await context.SaveChangesAsync();
    }
}