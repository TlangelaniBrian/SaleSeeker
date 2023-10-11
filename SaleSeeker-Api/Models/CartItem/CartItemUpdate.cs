using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SaleSeeker_Api.Repositories;
using SaleSeeker_Api.Utils.Logging;
using SaleSeeker_Api.Utils.Validators;
using ILogger = Serilog.ILogger;

namespace SaleSeeker_Api.Models.CartItem;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public class CartItemUpdate : ItemBase
{
    public string Action { get; set; }

    private readonly IDbService _db;
    private readonly ILogger _logger;
    private readonly LogGeneralObject _logDetail = new LogGeneralObject { Service = nameof(CartItemAdd) };

    public CartItemUpdate()
    {
    }

    public CartItemUpdate(IDbService db, ILogger logger)
    {
        _db = db;
        _logger = logger;
    }
    public async Task<CartItemUpdate> UpdateCart(CartItemUpdate item)
    {
        var activeCart = _db.GetActiveCart(item.UserId).FirstOrDefault();
        if (activeCart == null)
        {
            item.Errors = "Error occured, cart does not exists for user.";
            _logDetail.LogLabel = $"Cart Error: {item.Errors}";
            _logger.Error(LogWrapper.LogError(_logDetail));
            return item;
        }

        // var results = new ItemValidator().Validate(item);
        // if (!results.IsValid)
        // {
        //     item.Errors = results.ToString();
        //
        //     _logDetail.LogLabel = $"Cart Validation Error: {item.Errors}";
        //     _logger.Error(LogWrapper.LogError(_logDetail));
        //     return item;
        // }

        activeCart.Balance = item.Balance;

        activeCart.UpdatedDatetime = DateTime.Now;

        var isSuccessful = 0;//await _db.UpdateCartItems(activeCart);

        if (isSuccessful < 1)
        {
            item.Errors = "Error occured, while saving cart.";
            _logDetail.LogLabel = $"Cart Error: {item.Errors}";
            _logger.Error(LogWrapper.LogError(_logDetail));
        }
        return item;
    }

    public bool RemoveCartItem(int userId, int itemId)
    {
        return true;
    }

}