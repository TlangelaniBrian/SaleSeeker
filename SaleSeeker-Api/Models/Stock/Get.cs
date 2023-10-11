using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SaleSeeker_Api.Repositories;
using ILogger = Serilog.ILogger;

namespace SaleSeeker_Api.Models.Stock;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public class Get
{
    public StockBase Stock { get; set; }
    public List<StockBase> StockList { get; set; }

    private readonly IDbService _db;
    private readonly ILogger _logger;

    public Get()
    {
    }

    public Get(IDbService db, ILogger logger)
    {
        _db = db;
        _logger = logger;
    }

    public List<StockBase>? FetchStockList(int pageNumber, int pageSize)
    {
        StockList = _db.GetStockItems().Select(s => new StockBase
            {
                CategoryId = s.Product.CategoryId,
                IsActive = s.IsActive,
                Name = s.Product.Name,
                Brand = s.Product.Brand,
                Description = s.Product.Description,
                Images = s.Product.Images,
                Id = s.Id,
                PricePerUnit = s.Product.PricePerUnit,
                AvailableQuantity = s.AvailableQuantity
            })
            .OrderBy(n => n.Name)
            .ThenByDescending(p => p.AvailableQuantity)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return StockList;
    }

    public StockBase? FetchStock(int stockId)
    {
        Stock = _db.GetStockItems()
            .Where(s => s.Id == stockId)
            .Select(s => new StockBase
            {
                CategoryId = s.Product.CategoryId,
                IsActive = s.IsActive,
                Name = s.Product.Name,
                Brand = s.Product.Brand,
                Description = s.Product.Description,
                Images = s.Product.Images,
                Id = s.Id,
                PricePerUnit = s.Product.PricePerUnit,
                AvailableQuantity = s.AvailableQuantity
            })
            .FirstOrDefault();
        if (Stock is null)
        {
            
        }
        return Stock;
    }
}