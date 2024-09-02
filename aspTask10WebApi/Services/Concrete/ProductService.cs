using aspTask10WebApi.DAL.Abstract;
using aspTask10WebApi.Entities.Concrete;
using aspTask10WebApi.Services.Abstract;

namespace aspTask10WebApi.Services.Concrete;
public class ProductService : IProductService
{
    // private fields for injecting : 
    private readonly IProductDal _productDal;

    // parametric constructor for injecting : 
    public ProductService(IProductDal productDal)
    {
        _productDal = productDal;
    }

    // implemented methods from interface :
    public async Task AddProductAsync(Product product)
        => await _productDal.AddAsync(product);
    public async Task DeleteProductAsync(int productId)
    {
        var product = await _productDal.GetAsync(p => p.Id == productId);
        await _productDal.DeleteAsync(product);
    }

    public async Task<ICollection<Product>> GetAllAsync()
        => await _productDal.GetListAsync();

    public async Task<Product> GetByIdAsync(int id)
     => await _productDal.GetAsync(p => p.Id == id);

    public async Task<Product> GetHigherDiscount()
    {
        var products = await _productDal.GetListAsync();
        return products.MaxBy(p => p.Discount);
    }

    public async Task<Product> GetHigherPrice()
    {
        var products = await _productDal.GetListAsync();
        return products.MaxBy(p => p.Price);
    }

    public async Task UpdateProductAsync(Product product)
       => await _productDal.UpdateAsync(product);
}
