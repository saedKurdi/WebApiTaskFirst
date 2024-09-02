using aspTask10WebApi.Entities.Abstraction;
using System.ComponentModel.DataAnnotations;
namespace aspTask10WebApi.Entities.Concrete;
public class Order : IEntity
{
    // public properties : 
    public int Id { get; set; }

    [Required]
    public DateTime OrderDate { get; set; }

    // foreign keys : 
    [Required]
    public int CustomerId { get; set; }

    [Required]  
    public int ProductId { get; set; }

    // navigation properties : 
    public virtual Customer ? Customer { get; set; }
    public virtual Product ? Product { get; set; }
}
