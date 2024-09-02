using aspTask10WebApi.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace aspTask10WebApi.Data;
public class ECommerceDBContext : DbContext
{
    // parametric constructor for injecting :
    public ECommerceDBContext(DbContextOptions<ECommerceDBContext>options) : base(options) { }

    // configurating method (overriding) : 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseLazyLoadingProxies(); // enable lazy loading proxies

    // tables for db : 
    public virtual DbSet <Order> Orders { get; set; }    
    public virtual DbSet <Product> Products { get; set; }
    public virtual DbSet <Customer> Customers { get; set; }
}
