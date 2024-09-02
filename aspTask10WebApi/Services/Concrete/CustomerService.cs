using aspTask10WebApi.DAL.Abstract;
using aspTask10WebApi.Entities.Concrete;
using aspTask10WebApi.Services.Abstract;

namespace aspTask10WebApi.Services.Concrete;
public class CustomerService : ICustomerService
{
    // private fields for injecting : 
    private readonly ICustomerDal _customerDal;

    // parametric constructor for injecting : 
    public CustomerService(ICustomerDal customerDal)
    {
        _customerDal = customerDal;
    }

    // implemented methods from interface : 
    public async Task AddCustomerAsync(Customer customer) 
        => await _customerDal.AddAsync(customer);

    public async Task DeleteCustomerAsync(int customerId)
    { 
        var customers = await _customerDal.GetListAsync();
        var customer = customers.FirstOrDefault(p => p.Id == customerId);
        await _customerDal.DeleteAsync(customer);
    }

    public async Task<ICollection<Customer>> GetAllAsync() => await _customerDal.GetListAsync();

    public async Task<Customer> GetByIdAsync(int id)
        => await _customerDal.GetAsync(c=>c.Id == id);

    public async Task UpdateCustomerAsync(Customer customer)
        => await _customerDal.UpdateAsync(customer);
}
