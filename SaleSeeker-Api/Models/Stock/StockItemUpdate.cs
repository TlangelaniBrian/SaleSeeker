using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SaleSeeker_Api.Repositories;
using SaleSeeker_Api.Utils.Logging;
using SaleSeeker_Api.Utils.Validators;
using SaleSeeker_DAL.Models;
using ILogger = Serilog.ILogger;

namespace SaleSeeker_Api.Models.Stock;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public class StockItemUpdate : StockBase
{
    public string Errors { get; set; }
    private readonly IDbService _db;
    private readonly Serilog.ILogger _logger;
    private readonly LogGeneralObject _logDetail = new LogGeneralObject { Service = nameof(StockItemAdd) };
    public StockItemUpdate()
    {
    }

    public StockItemUpdate(IDbService db, ILogger logger)
    {
        _db = db;
        _logger = logger;
    }
    public StockItemUpdate? UpdateStock(StockItemUpdate stock)
    {
        // Add validation here
        var results = new UpdateStockValidator().Validate(stock);
        if (!results.IsValid)
        {
            stock.Errors = results.ToString();
            _logDetail.LogLabel = $"Stock Validation Error: {stock.Errors}";
            _logger.Error(LogWrapper.LogError(_logDetail));
            return stock;
        }
        
        var currentStock = _db.GetStock(stock.Id).FirstOrDefault();
        
        if (currentStock is null)
        {
            return null;
        }

        currentStock.AvailableQuantity = stock.AvailableQuantity;
        currentStock.IsActive = stock.IsActive;
        currentStock.SoldQuantity = stock.SoldQuantity;
        currentStock.Product = new Product
        {
            PricePerUnit = stock.PricePerUnit,
            IsActive = stock.IsActive,
            Images = stock.Images,
            Description = stock.Description,
            Name = stock.Name,
            Variant = stock.Variant
        };
        var isSuccess = _db.UpdateStock(currentStock);
        if (isSuccess > 0)
        {
            return null;
        }
        return stock;
    }
}