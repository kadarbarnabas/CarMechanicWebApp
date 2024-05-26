using CarMechanic.Shared;
using Microsoft.AspNetCore.Mvc;

namespace CarMechanic.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
    {
        var existingCustomer = await _customerService.GetCustomer(customer.Ugyfelszam);

        if (existingCustomer is not null)
        {
            return Conflict();
        }

        await _customerService.CreateCustomer(customer);

        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCustomer(Guid id)
    {
        var customer = await _customerService.GetCustomer(id);

        if (customer is null)
        {
            return NotFound();
        }

        await _customerService.DeleteCustomer(id);

        return Ok();
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Customer>> GetCustomer(Guid id)
    {
        var customer = await _customerService.GetCustomer(id);

        if (customer is null)
        {
            return NotFound();
        }

        return Ok(customer);
    }

    [HttpGet]
    public async Task<ActionResult<List<Customer>>> GetAllCustomers()
    {
        return Ok(await _customerService.GetAllCustomers());
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateCustomer(Guid id, [FromBody] Customer newCustomer)
    {
        if (id != newCustomer.Ugyfelszam)
        {
            return BadRequest();
        }

        var existingCustomer = await _customerService.GetCustomer(id);

        if (existingCustomer is null)
        {
            return NotFound();
        }

        await _customerService.UpdateCustomer(newCustomer);

        return Ok();
    }
}