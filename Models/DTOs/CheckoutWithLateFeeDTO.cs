using System.ComponentModel.DataAnnotations;
namespace LoncotesLibrary.Models;

public class CheckoutWithLateFeeDTO
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
    private static decimal _LateFeePerDay = 0.50M;
    public decimal? LateFee 
    {
        get
        {
            DateTime dueDate = CheckoutDate.AddDays(Material.MaterialType.CheckoutDays);
            DateTime returnDate = ReturnDate ?? DateTime.Today;
            int daysLate = (returnDate - dueDate).Days;
            decimal fee = daysLate * _LateFeePerDay;
            return daysLate > 0 ? fee : null;
        }
    }
}