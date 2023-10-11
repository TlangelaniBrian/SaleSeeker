using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaleSeeker_DAL.Models;

public class Cart
{
    [Key]
    public int Id { get; set; }
    [Display(Name = "User")]
    public string UserId { get; set; }
    [ForeignKey("UserId")]
    public User? User { get; set; }
    public DateTime CreatedDatetime { get; set; } = DateTime.Now;
    public DateTime UpdatedDatetime { get; set; } = DateTime.Now;
    public bool IsCheckedOut { get; set; }
    [Precision(9, 2)]
    public decimal Balance { get; set; }
}