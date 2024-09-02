using aspTask10WebApi.Entities.Abstraction;
using System.ComponentModel.DataAnnotations;
namespace aspTask10WebApi.Entities.Concrete;
public class Product : IEntity
{
    // public properties : 
    public int Id { get; set; }

    [Required]
    public string? ProductName { get; set; }

    [Required]
    public double Discount { get; set; }

    [Required]
    public double Price { get; set; }
}
