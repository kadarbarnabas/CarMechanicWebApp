namespace CarMechanic.Shared;

public interface ICustomerService
{
    Task CreateCustomer(Customer customer);
    Task DeleteCustomer(Guid id);
    Task<Customer> GetCustomer(Guid id);
    Task<List<Customer>> GetAllCustomers();
    Task UpdateCustomer(Customer customer);
}