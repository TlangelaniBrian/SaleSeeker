using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SaleSeeker_Api.Repositories;
using SaleSeeker_Api.Utils.Logging;
using ILogger = Serilog.ILogger;

namespace SaleSeeker_Api.Models.CartItem;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public class CartItemDelete : ItemBase
{
    private readonly IDbService _db;
    private readonly ILogger _logger;
    private readonly LogGeneralObject _logDetail = new LogGeneralObject { Service = nameof(CartItemAdd) };

    public CartItemDelete()
    {
    }

    public CartItemDelete(IDbService db, ILogger logger)
    {
        _db = db;
        _logger = logger;
    }

    public bool RemoveCart(CartItemDelete cart)
    {
        var activeCart = _db.GetActiveCart(cart.UserId).FirstOrDefault();
        if (activeCart == null)
        {
            cart.Errors = "Error occured,cannot delete cart for user.";
            _logDetail.LogLabel = $"Cart Error: {cart.Errors}";
            _logger.Error(LogWrapper.LogError(_logDetail));
            return false;
        }

        return true;
    }
}