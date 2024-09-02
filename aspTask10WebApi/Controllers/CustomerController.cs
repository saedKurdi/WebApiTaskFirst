using aspTask10WebApi.DTOS;
using aspTask10WebApi.Entities.Concrete;
using aspTask10WebApi.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace aspTask10WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    // private readonly fields for injecting :
    private readonly ICustomerService _customerService;

    // parametric constructor for injecting : 
    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    // GET: api/<CustomerController>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var customers = await _customerService.GetAllAsync();
        return Ok(customers);
    }

    // GET api/<CustomerController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var customer = await _customerService.GetByIdAsync(id);
        if (customer == null) return NotFound("The customer id was not found in DB !");
        return Ok(customer);
    }

    // POST api/<CustomerController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CustomerAddDTO customerAddDTO)
    {
        if (customerAddDTO.CustomerName.IsNullOrEmpty() || customerAddDTO.CustomerSurname.IsNullOrEmpty()) 
            return BadRequest("Please fill the name and surname of customer !");
        var customer = new Customer { CustomerName = customerAddDTO.CustomerName ,CustomerSurname = customerAddDTO.CustomerSurname};
        await _customerService.AddCustomerAsync(customer);
        return Ok(customer);
    }

    // PUT api/<CustomerController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] CustomerUpdateDTO customerUpdateDTO)
    {
        var customer = await _customerService.GetByIdAsync(id);
        if (customer == null) return NotFound("The Customer you have been looking was not found in our Database !");
        customer.CustomerName = customerUpdateDTO.CustomerName;
        customer.CustomerSurname=customerUpdateDTO.CustomerSurname;
        await _customerService.UpdateCustomerAsync(customer);
        return Ok(customer);
    }

    // DELETE api/<CustomerController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var customer = await _customerService.GetByIdAsync(id);
        if (customer == null) return NotFound("The Customer you have been looking was not found in our Database !");
        await _customerService.DeleteCustomerAsync(id);
        return NoContent();
    }
}
