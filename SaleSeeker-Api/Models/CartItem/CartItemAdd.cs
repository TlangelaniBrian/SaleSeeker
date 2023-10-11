
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SaleSeeker_Api.Repositories;
using SaleSeeker_Api.Utils.Logging;
using SaleSeeker_Api.Utils.Validators;
using SaleSeeker_DAL.Models;
using ILogger = Serilog.ILogger;

namespace SaleSeeker_Api.Models.CartItem;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public class CartItemAdd
{
    private readonly IDbService _db;
    private readonly ILogger _logger;
    private readonly LogGeneralObject _logDetail = new LogGeneralObject { Service = nameof(CartItemAdd) };

    public int CartId { get; set; }
    public string UserId { get; set; }
    public int ProductId { get; set; }
    public DateTime CreatedDatetime { get; set; }
    public string Errors { get; set; }
    public CartItemAdd()
    {
    }

    public CartItemAdd(IDbService db, ILogger logger)
    {
        _db = db;
        _logger = logger;
    }
    public async Task<CartItemAdd> AddItem(CartItemAdd item)
    {
        var activeItem = _db.GetCartItem(item.UserId, item.ProductId).FirstOrDefault();
        if (activeItem is null)
        {
            item.Errors = "Error occured, item already exists in cart.";
            _logDetail.LogLabel = $"Item Error: {item.Errors}";
            _logger.Error(LogWrapper.LogError(_logDetail));
            return item;
        }

        var results = new CartValidator().Validate(item);
        if (!results.IsValid)
        {
            item.Errors = results.ToString();

            _logDetail.LogLabel = $"Cart Validation Error: {item.Errors}";
            _logger.Error(LogWrapper.LogError(_logDetail));
            return item;
        }

        activeItem = new Item
        {
            UserId = item.UserId,
            CartId = item.CartId,
            IsSold = false,
            ProductId = item.ProductId,
            CreatedDatetime = DateTime.Now
        };

        var isSuccessful = await _db.AddCartItem(activeItem);
        if (isSuccessful < 1)
        {
            item.Errors = "Error occured, while saving cart.";
            _logDetail.LogLabel = $"Cart Error: {item.Errors}";
            _logger.Error(LogWrapper.LogError(_logDetail));
        }

        return item;
    }

}
