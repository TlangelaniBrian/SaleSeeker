using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SaleSeeker_Api.Repositories;
using ILogger = Serilog.ILogger;

namespace SaleSeeker_Api.Models.Stock;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public class StockItemDelete
{

    private readonly IDbService _db;
    private readonly ILogger _logger;

    public StockItemDelete()
    {
    }

    public StockItemDelete(IDbService db, ILogger logger)
    {
        _db = db;
        _logger = logger;
    }
    public bool? RemoveStock(int stockId)
    {
        var stock = _db.GetStock(stockId).FirstOrDefault();
        
        if (stock is not null)
        {
          return _db.DisableStockItem(stock);
        }

        return null;
    }
}