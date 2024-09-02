using aspTask10WebApi.DAL.Abstract;
using aspTask10WebApi.Entities.Concrete;
using aspTask10WebApi.Services.Abstract;

namespace aspTask10WebApi.Services.Concrete;
public class OrderService : IOrderService
{
    // private fields for injecting : 
    private readonly IOrderDal _orderDal;

    // parametric constructor for injecting : 
    public OrderService(IOrderDal orderDal)
    {
        _orderDal = orderDal;
    }

    // implemented methods from interface :
    public async Task AddOrderAsync(Order order)
      =>  await _orderDal.AddAsync(order);  

    public async Task DeleteOrderAsync(int orderId)
    {
        var orders = await _orderDal.GetListAsync();
        var order = orders.FirstOrDefault(o => o.Id == orderId);
        await _orderDal.DeleteAsync(order);
    }

    public async Task<ICollection<Order>> GetAllAsync()
        => await _orderDal.GetListAsync();

    public async Task<Order> GetByIdAsync(int id) 
        => await _orderDal.GetAsync(o => o.Id == id);

    public async Task UpdateOrderAsync(Order order)
        => await _orderDal.UpdateAsync(order);
}
