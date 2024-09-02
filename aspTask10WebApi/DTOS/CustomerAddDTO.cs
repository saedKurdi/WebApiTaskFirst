using System.ComponentModel.DataAnnotations;

namespace aspTask10WebApi.DTOS;
public class CustomerAddDTO
{
    // public properties : 
    [Required]
    public string? CustomerName { get; set; }

    [Required]
    public string? CustomerSurname { get; set; }
}
