using aspTask10WebApi.Entities.Concrete;

namespace aspTask10WebApi.Services.Abstract;
public interface ICustomerService
{
    // methods that will be implemented in classes : 
    public Task<ICollection<Customer>> GetAllAsync();
    public Task<Customer> GetByIdAsync(int id);
    public Task DeleteCustomerAsync(int customerId);
    public Task UpdateCustomerAsync(Customer customer);
    public Task AddCustomerAsync(Customer customer);
}
