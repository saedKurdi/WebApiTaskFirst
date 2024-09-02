using aspTask10WebApi.DAL.Abstract;
using aspTask10WebApi.Data;
using aspTask10WebApi.Entities.Concrete;
using aspTask10WebApi.Repository.Concrete;

namespace aspTask10WebApi.DAL.Concrete;
public class EFProductDal : EFEntityRepositoryBase<Product,ECommerceDBContext> , IProductDal
{
    // parametric constructor : 
    public EFProductDal(ECommerceDBContext context) : base(context) { }
}
