using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SaleSeeker_Api.Repositories;
using SaleSeeker_Api.Utils.Logging;
using SaleSeeker_Api.Utils.Validators;
using ILogger = Serilog.ILogger;

namespace SaleSeeker_Api.Models.Stock;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public class StockItemAdd : StockBase
{
    public string Errors { get; set; }
    public int ProductId { get; set; }
    private readonly IDbService _db;
    private readonly ILogger _logger;
    private readonly LogGeneralObject _logDetail = new LogGeneralObject { Service = nameof(StockItemAdd) };
    public StockItemAdd()
    {
    }

    public StockItemAdd(IDbService db, ILogger logger)
    {
        _db = db;
        _logger = logger;
    }
    public StockItemAdd? AddStock(StockItemAdd stock)
    {
        // Add validation here
        var results = new AddStockValidator().Validate(stock);
        if (!results.IsValid)
        {
            stock.Errors = results.ToString();
            _logDetail.LogLabel = $"Stock Validation Error: {stock.Errors}";
            _logger.Error(LogWrapper.LogError(_logDetail));
            return stock;
        }

        var newStock = _db.GetStock(stock.Id).FirstOrDefault();

        if (newStock is not null)
        {
            stock.Errors = "Error occured, stock item already exists.";
            return stock;
        }

        newStock = new SaleSeeker_DAL.Models.Stock
        {
            AvailableQuantity = stock.AvailableQuantity,
            CreatedDatetime = DateTime.Now,
            IsActive = stock.IsActive,
            ProductId = stock.ProductId,
            SoldQuantity = stock.SoldQuantity,
            UpdatedDatetime = DateTime.Now,
        };

        var isSuccess = _db.AddStock(newStock).Result;
        if (isSuccess > 0)
        {
            return null;
        }
        return stock;
    }
}