using aspTask10WebApi.DTOS;
using aspTask10WebApi.Entities.Concrete;
using aspTask10WebApi.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace aspTask10WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    // private readonly fields for injecting :
    private readonly IProductService _productService;
    
    // parametric constructor for injecting : 
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    // GET: api/<ProductController>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var products = await _productService.GetAllAsync();
        return Ok(products);
    }

    // GET api/<ProductController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var product = await _productService.GetByIdAsync(id);
        if (product == null) return NotFound("The product id was not found in DB !");
        return Ok(product);
    }

    // POST api/<ProductController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ProductAddDTO productAddDTO)
    {
        if (productAddDTO.ProductName.IsNullOrEmpty() || productAddDTO.Discount.ToString().IsNullOrEmpty() || productAddDTO.Price.ToString().IsNullOrEmpty())
            return BadRequest("Please fill the product name ; discount and price of product !");
        var product = new Product { ProductName = productAddDTO.ProductName, Price = productAddDTO.Price,Discount = productAddDTO.Discount };
        await _productService.AddProductAsync(product);
        return Ok(product);
    }

    // PUT api/<ProductController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] ProductUpdateDTO productUpdateDTO)
    {
        var product = await _productService.GetByIdAsync(id);
        if (product == null) return NotFound("The Product you have been looking was not found in our Database !");
        product.ProductName = productUpdateDTO.ProductName;
        product.Price = productUpdateDTO.Price;
        product.Discount = productUpdateDTO.Discount;
        await _productService.UpdateProductAsync(product);
        return Ok(product);
    }

    // DELETE api/<ProductController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _productService.GetByIdAsync(id);
        if (product == null) return NotFound("The Product you have been looking was not found in our Database !");
        await _productService.DeleteProductAsync(id);
        return NoContent();
    }


    // other custom methods with endpoints :
    [HttpGet("GetHigher")]
    public async Task<IActionResult> GetHeighestPriceFromService()
    {
        var product = await _productService.GetHigherPrice();
        if (product == null) return NotFound("No product found in DB !");
        return Ok(product);
    }

    [HttpGet("GetHigherDiscount")]
    public async Task<IActionResult> GetHeighestDiscountFromService()
    {
        var product = await _productService.GetHigherDiscount();
        if (product == null) return NotFound("No product found in DB !");
        return Ok(product);
    }
}
