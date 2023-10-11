using System.ComponentModel.DataAnnotations;

namespace SaleSeeker_Api.Models.Stock;

public class StockBase
{
    public int Id { get; set; }
    public int AvailableQuantity { get; set; } = 0;
    public int SoldQuantity { get; set; } = 0;
    public decimal PricePerUnit { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    [Display(Name = "Category")]
    public int CategoryId { get; set; }
    public string Images { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public string Variant { get; set; } = string.Empty;
}
