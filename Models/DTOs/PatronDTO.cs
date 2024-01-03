using System.ComponentModel.DataAnnotations;
namespace LoncotesLibrary.Models;

public class PatronDTO
{
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public bool IsActive { get; set; }
    public List<CheckoutDTO> Checkouts { get; set; }
    public List<CheckoutWithLateFeeDTO> CheckoutsWithLateFees { get; set; }
    public decimal? Balance
    {
        get
        {
            if (CheckoutsWithLateFees == null)
            {
                return null;
            }
            else
            {
                // get current checkouts
                var balance = CheckoutsWithLateFees
                // filter to only overdue checkouts
                    .Where(co => co.LateFee > 0)
                    .Where(co => !co.Paid)
                // add up the latefee
                    .Sum(co => co.LateFee);
                // return the total balance due
                return balance > 0 ? balance : null;
            }
        }
    }
}