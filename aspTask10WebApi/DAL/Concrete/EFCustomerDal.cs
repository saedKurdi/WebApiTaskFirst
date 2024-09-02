using aspTask10WebApi.DAL.Abstract;
using aspTask10WebApi.Data;
using aspTask10WebApi.Entities.Concrete;
using aspTask10WebApi.Repository.Concrete;

namespace aspTask10WebApi.DAL.Concrete;
public class EFCustomerDal : EFEntityRepositoryBase<Customer,ECommerceDBContext>,ICustomerDal
{
    // parametric constructor for injecting :
    public EFCustomerDal(ECommerceDBContext context) : base(context) { }
}
