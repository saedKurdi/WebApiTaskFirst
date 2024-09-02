using System.ComponentModel.DataAnnotations;

namespace aspTask10WebApi.DTOS;
public class OrderUpdateDTO
{
    // public properties : 
    [Required]
    public DateTime OrderDate { get; set; }

    // foreign keys : 
    [Required]
    public int CustomerId { get; set; }

    [Required]
    public int ProductId { get; set; }

}
