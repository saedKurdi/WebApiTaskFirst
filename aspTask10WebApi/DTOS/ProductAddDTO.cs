using System.ComponentModel.DataAnnotations;

namespace aspTask10WebApi.DTOS;
public class ProductAddDTO
{
    // public properties : 
    [Required]
    public string? ProductName { get; set; }

    [Required]
    public double Discount { get; set; }

    [Required]
    public double Price { get; set; }
}
