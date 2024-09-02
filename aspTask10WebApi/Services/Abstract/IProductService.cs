using aspTask10WebApi.Entities.Concrete;

namespace aspTask10WebApi.Services.Abstract;
public interface IProductService
{
    // methods that will be implemented in classes : 
    public Task<ICollection<Product>> GetAllAsync();
    public Task<Product> GetByIdAsync(int id);
    public Task DeleteProductAsync (int productId);
    public Task UpdateProductAsync (Product product); 
    public Task AddProductAsync(Product product);
    public Task<Product> GetHigherPrice();
    public Task<Product> GetHigherDiscount();
}
