using System.ComponentModel.DataAnnotations;
namespace LoncotesLibrary.Models;

public class MaterialTypeDTO
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int CheckoutDays { get; set; }
}