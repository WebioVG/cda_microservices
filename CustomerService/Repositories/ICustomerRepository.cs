using CustomerService.Models;

namespace CustomerService.Repositories;

public interface ICustomerRepository
{
    public Task<IEnumerable<Customer?>> GetAllAsync();
    public Task<Customer?> GetByIdAsync(int id);
    public Task CreateAsync(Customer customer);
    public Task UpdateAsync(Customer customer);
    public Task DeleteAsync(int id);
}