using System.ComponentModel.DataAnnotations;


namespace SaleSeeker_Web.ViewModel.CartItem;

public class CartItemGet
{
    public int CartId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string Variant { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal PricePerUnit { get; set; }
    public int Quantity { get; set; }
    public int CategoryId { get; set; }
    [Display(Name = "Category")] public string CategoryName { get; set; }
    public string SupplierName { get; set; }
    public string Images { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public string UserId { get; set; }
    public string UserName { get; set; }
}