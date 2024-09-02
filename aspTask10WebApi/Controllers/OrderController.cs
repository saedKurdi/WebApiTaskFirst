using aspTask10WebApi.DTOS;
using aspTask10WebApi.Entities.Concrete;
using aspTask10WebApi.Services.Abstract;
using aspTask10WebApi.Services.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace aspTask10WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    // private readonly fields for injecting :
    private readonly IOrderService _orderService;

    // parametric constructor for injecting : 
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    // GET: api/<OrderController>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var orders = await _orderService.GetAllAsync();
        return Ok(orders);
    }

    // GET api/<OrderController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var order = await _orderService.GetByIdAsync(id);
        if (order == null) return NotFound("The order id was not found in DB !");
        return Ok(order);
    }

    // POST api/<OrderController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] OrderAddDTO orderAddDTO)
    {
        if (orderAddDTO.ProductId.ToString().IsNullOrEmpty() || orderAddDTO.OrderDate.ToString().IsNullOrEmpty() || orderAddDTO.CustomerId.ToString().IsNullOrEmpty())
            return BadRequest("Please fill all fields of order !");
        var order = new Order { OrderDate = orderAddDTO.OrderDate, ProductId = orderAddDTO.ProductId,CustomerId = orderAddDTO.CustomerId };
        await _orderService.AddOrderAsync(order);
        return Ok(order);
    }

    // PUT api/<OrderController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] OrderUpdateDTO orderUpdateDTO)
    {
        var order = await _orderService.GetByIdAsync(id);
        if (order == null) return NotFound("The Order you have been looking was not found in our Database !");
        order.OrderDate = orderUpdateDTO.OrderDate;
        order.ProductId = orderUpdateDTO.ProductId;
        order.CustomerId = orderUpdateDTO.CustomerId;
        await _orderService.UpdateOrderAsync(order);
        return Ok(order);
    }

    // DELETE api/<OrderController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var order = await _orderService.GetByIdAsync(id);
        if (order == null) return NotFound("The Order you have been looking was not found in our Database !");
        await _orderService.DeleteOrderAsync(id);
        return NoContent();
    }
}
