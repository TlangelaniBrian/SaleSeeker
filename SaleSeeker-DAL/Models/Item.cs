using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaleSeeker_DAL.Models;
public class Item
{
    public int Id { get; set; }
    [Display(Name = "User")]
    public string? UserId { get; set; }
    [ForeignKey("UserId")]
    public User? User { get; set; }
    [Display(Name = "Cart")]
    public int? CartId { get; set; }
    [ForeignKey("CartId")]
    public Cart? Cart { get; set; }
    [Display(Name = "Product")]
    public int? ProductId { get; set; }
    [ForeignKey("ProductId")]
    public virtual Product? Product { get; set; }
    public DateTime CreatedDatetime { get; set; }
    public bool IsSold { get; set; }
}
