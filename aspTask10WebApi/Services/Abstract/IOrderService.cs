using aspTask10WebApi.Entities.Concrete;

namespace aspTask10WebApi.Services.Abstract;
public interface IOrderService
{
    // methods that will be implemented in classes : 
    public Task<ICollection<Order>> GetAllAsync();
    public Task<Order> GetByIdAsync(int id);
    public Task DeleteOrderAsync(int orderId);
    public Task UpdateOrderAsync(Order order);
    public Task AddOrderAsync(Order order);
}
