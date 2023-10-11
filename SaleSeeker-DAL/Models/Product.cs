using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaleSeeker_DAL.Models;

public class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Brand { get; set; } = string.Empty;
    public string Variant { get; set; }

    public DateTime CreatedDatetime { get; set; } = DateTime.Now;
    public DateTime UpdatedDatetime { get; set; } = DateTime.Now;
    public string Description { get; set; } = string.Empty;
    public decimal PricePerUnit { get; set; }
    public int Quantity { get; set; }
    [Display(Name = "Category")]
    public int CategoryId { get; set; }
    [ForeignKey("CategoryId")]
    public virtual Category? Category { get; set; }

    [Required]
    public string Images { get; set; } = string.Empty;

    [Required]
    [DefaultValue(true)]
    public bool IsActive { get; set; }
}