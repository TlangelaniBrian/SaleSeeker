
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SaleSeeker_Web.ViewModel.CartItem;

public class CartItemAdd
{

    public int CartId { get; set; }
    public string UserId { get; set; }
    public int ProductId { get; set; }
    public DateTime CreatedDatetime { get; set; }
    public string Errors { get; set; }

}
