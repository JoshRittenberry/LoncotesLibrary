using System.ComponentModel.DataAnnotations;
namespace LoncotesLibrary.Models;

public class MaterialDTO
{
    public int Id { get; set; }
    [Required]
    public string MaterialName { get; set; }
    [Required]
    public int MaterialTypeId { get; set; }
    [Required]
    public MaterialTypeDTO MaterialType { get; set; }
    [Required]
    public int GenreId { get; set; }
    [Required]
    public GenreDTO Genre { get; set; }
    public DateTime? OutOfCirculationSince { get; set; }
    public List<CheckoutDTO> Checkouts { get; set; }
}