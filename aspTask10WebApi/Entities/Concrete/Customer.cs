using aspTask10WebApi.Entities.Abstraction;
using System.ComponentModel.DataAnnotations;
namespace aspTask10WebApi.Entities.Concrete;
public class Customer : IEntity
{
    // public properties : 
    public int Id { get; set; }

    [Required]
    public string? CustomerName { get; set; }

    [Required]
    public string? CustomerSurname { get; set; }
}
