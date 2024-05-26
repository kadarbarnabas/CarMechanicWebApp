using System.Net.Http.Json;
using CarMechanic.Shared;

namespace CarMechanic.UI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _httpClient;
        
        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCustomerAsync(Customer customer)
        {
            await _httpClient.PostAsJsonAsync("/Customers", customer);
        }

        public async Task DeleteCustomerAsync(Guid id)
        {
            await _httpClient.DeleteAsync($"/Customers/{id}");
        }

        public async Task<Customer> GetCustomerAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<Customer>($"Customers/{id}");
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Customer>>("/Customers");
        }

        public async Task UpdateCustomerAsync(Guid id, Customer customer)
        {
            await _httpClient.PutAsJsonAsync($"/Customers/{id}", customer);
        }
    }
}