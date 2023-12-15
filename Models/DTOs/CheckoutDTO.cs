using System.ComponentModel.DataAnnotations;
namespace LoncotesLibrary.Models;

public class CheckoutDTO
{
    public int Id { get; set; }
    [Required]
    public int MaterialId { get; set; }
    [Required]
    public MaterialDTO Material { get; set; }
    [Required]
    public int PatronId { get; set; }
    [Required]
    public PatronDTO Patron { get; set; }
    [Required]
    public DateTime CheckoutDate { get; set; }
    public DateTime? ReturnDate { get; set; }
}