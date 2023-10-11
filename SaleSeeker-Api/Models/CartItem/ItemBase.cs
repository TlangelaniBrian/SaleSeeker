using Microsoft.EntityFrameworkCore;

namespace SaleSeeker_Api.Models.CartItem;

public abstract class ItemBase
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public DateTime CreatedDatetime { get; set; }
    public DateTime UpdatedDatetime { get; set; }
    public bool IsCheckedOut { get; set; }

    [Precision(9, 2)]
    public decimal Balance { get; set; }
    public string Errors { get; set; } = string.Empty;
}
