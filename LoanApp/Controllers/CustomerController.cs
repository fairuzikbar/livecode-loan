using LoanApp.Entities.Loan;
using LoanApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LoanApp.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomerController:ControllerBase
{
    private readonly IRepository<Customer> _customerRepository;
    private readonly IPersistence _persistence;

    public CustomerController(IRepository<Customer> customerRepository, IPersistence persistence)
    {
        _customerRepository = customerRepository;
        _persistence = persistence;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateNewCustomer([FromBody] Customer payload)
    {
        var customer = await _customerRepository.SaveAsync(payload);
        await _persistence.SaveChangesAsync();
        return Created("/api/customers", customer);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateCustomer([FromBody] Customer payload)
    {
        var customer = _customerRepository.Update(payload);
        await _persistence.SaveChangesAsync();
        return Ok(customer);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(string id)
    {
        try
        {
            var customer = await _customerRepository.FindByIdAsync(int.Parse(id));
            if (customer is null) return NotFound("Customer not found");
            _customerRepository.Delete(customer);
            await _persistence.SaveChangesAsync();
            return Ok();
        }
        catch (Exception e)
        {
            return new StatusCodeResult(500);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomerName(string id)
    {
        var customer = await _customerRepository
            .FindAsync(customer => customer.Id.Equals(int.Parse(id)));
        return Ok(customer);
    }
}