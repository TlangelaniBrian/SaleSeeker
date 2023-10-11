using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaleSeeker_DAL.Models;

public class Stock
{
    [Key]
    public int Id { get; set; }
    public DateTime CreatedDatetime { get; set; } = DateTime.Now;
    public DateTime UpdatedDatetime { get; set; } = DateTime.Now;
    
    [Display(Name = "Product")]
    public int ProductId { get; set; }
    [ForeignKey("ProductId")]
    public virtual Product? Product { get; set; }
    public int AvailableQuantity { get; set; }
    public int SoldQuantity { get; set; }
    public bool IsActive { get; set; } = true;
}
