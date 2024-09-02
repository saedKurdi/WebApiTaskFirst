using System.ComponentModel.DataAnnotations;

namespace aspTask10WebApi.DTOS;
public class CustomerUpdateDTO
{
    // public properties : 
    [Required]
    public string? CustomerName { get; set; }

    [Required]
    public string? CustomerSurname { get; set; }
}
