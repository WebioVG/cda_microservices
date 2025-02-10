using CustomerService.Models;
using CustomerService.Repositories; // Use the repository instead

namespace CustomerService.Services;

public class CustomersService(ICustomerRepository customerRepository) : ICustomersService
{
    private readonly ICustomerRepository _customerRepository = customerRepository;

    public async Task<IEnumerable<Customer?>> GetAllAsync()
    {
        return await _customerRepository.GetAllAsync(); // Fetch from the repository
    }

    public async Task<Customer?> GetByIdAsync(int id)
    {
        return await _customerRepository.GetByIdAsync(id);
    }

    public async Task CreateAsync(Customer customer)
    {
        await _customerRepository.CreateAsync(customer);
    }

    public async Task UpdateAsync(Customer customer)
    {
        await _customerRepository.UpdateAsync(customer);
    }

    public async Task DeleteAsync(int id)
    {
        await _customerRepository.DeleteAsync(id);
    }
}