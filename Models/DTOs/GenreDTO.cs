using System.ComponentModel.DataAnnotations;
namespace LoncotesLibrary.Models;

public class GenreDTO
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
}