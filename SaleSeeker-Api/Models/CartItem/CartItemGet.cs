using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SaleSeeker_Api.Repositories;
using System.ComponentModel.DataAnnotations;
using ILogger = Serilog.ILogger;

namespace SaleSeeker_Api.Models.CartItem;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
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
    [Display(Name = "Category")]
    public string CategoryName { get; set; }
    public string SupplierName { get; set; }
    public string Images { get; set; } = string.Empty;
    public bool IsActive { get; set; }

    private readonly IDbService _db;
    private readonly ILogger _logger;
    public CartItemGet()
    {
    }

    public CartItemGet(IDbService db, ILogger logger)
    {
        _db = db;
        _logger = logger;
    }

    public CartItemGet? GetCartItem(string userId, int productId)
    {
        var item = _db.GetCartItem(userId, productId)
                      .Include(p => p.Product)
                      .ThenInclude(c => c.Category)
                      .FirstOrDefault();

        if (item == null)
        {
            return null;
        }

        if (item.Product == null)
        {
            return null;
        }

        var cartItem = new CartItemGet
        {
            CartId = item.CartId ?? 0,
            Brand = item?.Product?.Brand ?? string.Empty,
            CategoryId = item?.Product?.CategoryId ?? 0,
            CategoryName = item?.Product?.Category?.Name ?? string.Empty,
            Description = item?.Product?.Description ?? string.Empty,
            Images = item?.Product?.Images ?? string.Empty,
            IsActive = item?.Product?.IsActive ?? false,
            Name = item?.Product?.Name ?? string.Empty,
            PricePerUnit = item?.Product?.PricePerUnit ?? 0,
            Quantity = item?.Product?.Quantity ?? 0,
            Variant = item?.Product?.Variant ?? string.Empty
        };

        return cartItem;
    }

    public List<CartItemGet>? GetCartItems(string userId, int cartId)
    {
        var items = _db.GetCartItems(userId, cartId)
                      .Include(p => p.Product)
                      .ThenInclude(c => c.Category)
                      .ToList();

        if (!items.Any())
        {
            return null;
        }

        var cartItems = items.Select(i => new CartItemGet
        {
            CartId = i.CartId ?? 0,
            Brand = i?.Product?.Brand ?? string.Empty,
            CategoryId = i?.Product?.CategoryId ?? 0,
            CategoryName = i?.Product?.Category?.Name ?? string.Empty,
            Description = i?.Product?.Description ?? string.Empty,
            Images = i?.Product?.Images ?? string.Empty,
            IsActive = i?.Product?.IsActive ?? false,
            Name = i?.Product?.Name ?? string.Empty,
            PricePerUnit = i?.Product?.PricePerUnit ?? 0,
            Quantity = i?.Product?.Quantity ?? 0,
            Variant = i?.Product?.Variant ?? string.Empty
        }).ToList();

        return cartItems;
    }
}