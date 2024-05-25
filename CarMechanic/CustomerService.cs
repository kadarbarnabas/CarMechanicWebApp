using CarMechanic.Shared;
using Microsoft.EntityFrameworkCore;

namespace CarMechanic;

public class CustomerService : ICustomerService
{
    private readonly CarMechanicContext _context;
    private readonly ILogger<CustomerService> _logger;

    public CustomerService(ILogger<CustomerService> logger, CarMechanicContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task CreateCustomer(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Customer added");
    }

    public async Task DeleteCustomer(Guid id)
    {
        var customer = await GetCustomer(id);

        _context.Customers.Remove(customer);

        await _context.SaveChangesAsync();
    }

    public async Task<Customer> GetCustomer(Guid id)
    {
        var customer = await _context.Customers.FindAsync(id);
        _logger.LogInformation("Customer retrieved: {@Customer}", customer);
        return customer;
    }

    public async Task<List<Customer>> GetAllCustomers()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task UpdateCustomer(Customer newCustomer)
    {
        var customer = await GetCustomer(newCustomer.Ugyfelszam);
        customer.Nev = newCustomer.Nev;
        customer.Email = newCustomer.Email;
        customer.Lakcim = newCustomer.Lakcim;

        await _context.SaveChangesAsync();
    }


}