using CarMechanic.Shared;

namespace CarMechanic.UI.Services;

public interface ICustomerService
{
    Task CreateCustomerAsync(Customer customer);
    Task DeleteCustomerAsync(Guid id);
    Task<Customer> GetCustomerAsync(Guid id);
    Task<IEnumerable<Customer>> GetAllCustomersAsync();
    Task UpdateCustomerAsync(Guid id, Customer customer);
}