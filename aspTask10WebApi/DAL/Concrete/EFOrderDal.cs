using aspTask10WebApi.DAL.Abstract;
using aspTask10WebApi.Data;
using aspTask10WebApi.Entities.Concrete;
using aspTask10WebApi.Repository.Concrete;

namespace aspTask10WebApi.DAL.Concrete;
public class EFOrderDal : EFEntityRepositoryBase<Order,ECommerceDBContext>,IOrderDal
{
    // parametric constructor for injecting : 
    public EFOrderDal(ECommerceDBContext context) : base(context) { }
}
