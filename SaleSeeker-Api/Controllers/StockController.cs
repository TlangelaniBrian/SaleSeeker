using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaleSeeker_Api.Models.Stock;
using SaleSeeker_Api.Repositories;
using SaleSeeker_Api.Utils.Logging;
using SaleSeeker_Api.Utils.Response;
using System.Data.Common;
using static SaleSeeker_Api.Utils.Logging.LogWrapper;
using ILogger = Serilog.ILogger;

namespace SaleSeeker_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StockController : ControllerBase
{
    private const string _suffixSourceName = "stock";
    private readonly IDbService _db;
    private readonly ILogger _logger;
    private readonly LogObject _logDetail = new();

    public StockController(IDbService db, ILogger logger)
    {
        _db = db;
        _logger = logger;
    }

    [HttpGet("get-stock-list")]
    public async Task<WrapperResponse> GetStockList(int pageNumber, int pageSize)
    {
        var message = string.Empty;
        var source = $"{_suffixSourceName}-{nameof(GetStockList)}";

        try
        {
            message = "Successfully loaded stock";
            var stockList = new Get(_db, _logger).FetchStockList(pageNumber, pageSize);
            return await Task.FromResult(ResponseCreation.CreateSuccessResponse(source, stockList, message));
        }
        catch (Exception ex)
        {
            _logDetail.EventLabel = "Unsuccessful";
            _logDetail.LogLabel = "API Exception Occurred.";
            _logDetail.DateTimestamp = DateTime.Now;
            _logDetail.ExceptionMessage = ex.Message;
            _logDetail.ExceptionStackTrace = ex.StackTrace ?? string.Empty;
            _logDetail.InnerExceptionMessage = ex.InnerException?.Message ?? string.Empty;
            _logDetail.InnerExceptionStackTrace = ex.InnerException?.StackTrace ?? string.Empty;
            _logger.Error(ex, LogError(_logDetail));
            return await Task.FromResult(
                ResponseCreation.CreateInternalServerErrorResponse(_suffixSourceName, _logDetail.LogLabel));
        }
    }

    [HttpGet("get-stock-item")]
    public async Task<WrapperResponse> GetStockItem(int stockId)
    {
        var message = string.Empty;
        var source = $"{_suffixSourceName}-{nameof(GetStockItem)}";

        try
        {
            message = "Successfully loaded stock";
            var stock = new Get(_db, _logger).FetchStock(stockId);
            return await Task.FromResult(ResponseCreation.CreateSuccessResponse(source, stock, message));
        }
        catch (Exception ex)
        {
            _logDetail.EventLabel = "Unsuccessful";
            _logDetail.LogLabel = "API Exception Occurred.";
            _logDetail.DateTimestamp = DateTime.Now;
            _logDetail.ExceptionMessage = ex.Message;
            _logDetail.ExceptionStackTrace = ex.StackTrace ?? string.Empty;
            _logDetail.InnerExceptionMessage = ex.InnerException?.Message ?? string.Empty;
            _logDetail.InnerExceptionStackTrace = ex.InnerException?.StackTrace ?? string.Empty;
            _logger.Error(ex, LogError(_logDetail));
            return await Task.FromResult(
                ResponseCreation.CreateInternalServerErrorResponse(_suffixSourceName, _logDetail.LogLabel));
        }
    }

    [HttpPost("add-stock-item")]
    public async Task<WrapperResponse> AddStockItem([FromBody] StockItemAdd stock)
    {
        var message = string.Empty;
        var source = $"{_suffixSourceName}-{nameof(AddStockItem)}";

        try
        {
            var addStock = new StockItemAdd(_db, _logger).AddStock(stock);
            if (addStock is null)
            {
                message = $"Failed to update stock item: {stock.Name}";
                _logDetail.LogLabel = message;
                _logDetail.DateTimestamp = DateTime.Now;
                _logDetail.EventLabel = $"Action: stock item {stock.Name}, stock Id: {stock.Id}  returned null values";
                _logger.Information(LogInfo(_logDetail));

                return await Task.FromResult(
                    ResponseCreation.CreateErrorResponse(source, message));
            }

            message = "updated stock";
            _logger.Information(LogInfo(_logDetail));

            return await Task.FromResult(
                ResponseCreation.CreateSuccessResponse(source, addStock, message));
        }
        catch (DbUpdateConcurrencyException ex)
        {
            _logDetail.EventLabel = "Unsuccessful";
            _logDetail.LogLabel = "DbUpdate Concurrency Exception Occurred";
            _logDetail.DateTimestamp = DateTime.Now;
            _logDetail.ExceptionMessage = ex.Message;
            _logDetail.ExceptionStackTrace = ex.StackTrace ?? string.Empty;
            _logDetail.InnerExceptionMessage = ex.InnerException?.Message ?? string.Empty;
            _logDetail.InnerExceptionStackTrace = ex.InnerException?.StackTrace ?? string.Empty;
            _logger.Error(ex, LogError(_logDetail));
            return await Task.FromResult(
                ResponseCreation.CreateInternalServerErrorResponse(_suffixSourceName, _logDetail.LogLabel));
        }
        catch (DbException ex)
        {
            _logDetail.EventLabel = "Unsuccessful";
            _logDetail.LogLabel = "Database Exception Occurred.";
            _logDetail.DateTimestamp = DateTime.Now;
            _logDetail.ExceptionMessage = ex.Message;
            _logDetail.ExceptionStackTrace = ex.StackTrace ?? string.Empty;
            _logDetail.InnerExceptionMessage = ex.InnerException?.Message ?? string.Empty;
            _logDetail.InnerExceptionStackTrace = ex.InnerException?.StackTrace ?? string.Empty;
            _logger.Error(ex, LogError(_logDetail));
            return await Task.FromResult(
                ResponseCreation.CreateInternalServerErrorResponse(_suffixSourceName, _logDetail.LogLabel));
        }
        catch (Exception ex)
        {
            _logDetail.EventLabel = "Unsuccessful";
            _logDetail.LogLabel = "API Exception Occurred.";
            _logDetail.DateTimestamp = DateTime.Now;
            _logDetail.ExceptionMessage = ex.Message;
            _logDetail.ExceptionStackTrace = ex.StackTrace ?? string.Empty;
            _logDetail.InnerExceptionMessage = ex.InnerException?.Message ?? string.Empty;
            _logDetail.InnerExceptionStackTrace = ex.InnerException?.StackTrace ?? string.Empty;
            _logger.Error(ex, LogError(_logDetail));
            return await Task.FromResult(
                ResponseCreation.CreateInternalServerErrorResponse(_suffixSourceName, _logDetail.LogLabel));
        }
    }

    [HttpPut("update-stock-item")]
    public async Task<WrapperResponse> UpdateStockItem([FromBody] StockItemUpdate stock)
    {
        var message = string.Empty;
        var source = $"{_suffixSourceName}-{nameof(UpdateStockItem)}";

        try
        {
            var updatedStock = new StockItemUpdate(_db, _logger).UpdateStock(stock);
            if (updatedStock is null)
            {
                message = $"Failed to update stock item: {stock.Name}";
                _logDetail.LogLabel = message;
                _logDetail.DateTimestamp = DateTime.Now;
                _logDetail.EventLabel = $"Action: stock item {stock.Name}, stock Id: {stock.Id}  returned null values";
                _logger.Information(LogInfo(_logDetail));

                return await Task.FromResult(
                    ResponseCreation.CreateErrorResponse(source, message));
            }

            if (!string.IsNullOrEmpty(updatedStock.Errors))
            {
                message = updatedStock.Errors;
                _logDetail.LogLabel = message;
                _logDetail.DateTimestamp = DateTime.Now;
                _logDetail.EventLabel = "Action: check for cart for errors";
                _logger.Information(LogInfo(_logDetail));

                return await Task.FromResult(
                    ResponseCreation.CreateErrorResponse(source, message));
            }

            message = "updated stock";
            _logger.Information(LogInfo(_logDetail));

            return await Task.FromResult(
                ResponseCreation.CreateSuccessResponse(source, updatedStock, message));
        }
        catch (DbUpdateConcurrencyException ex)
        {
            _logDetail.EventLabel = "Unsuccessful";
            _logDetail.LogLabel = "DbUpdate Concurrency Exception Occurred";
            _logDetail.DateTimestamp = DateTime.Now;
            _logDetail.ExceptionMessage = ex.Message;
            _logDetail.ExceptionStackTrace = ex.StackTrace ?? string.Empty;
            _logDetail.InnerExceptionMessage = ex.InnerException?.Message ?? string.Empty;
            _logDetail.InnerExceptionStackTrace = ex.InnerException?.StackTrace ?? string.Empty;
            _logger.Error(ex, LogError(_logDetail));
            return await Task.FromResult(
                ResponseCreation.CreateInternalServerErrorResponse(_suffixSourceName, _logDetail.LogLabel));
        }
        catch (DbException ex)
        {
            _logDetail.EventLabel = "Unsuccessful";
            _logDetail.LogLabel = "Database Exception Occurred.";
            _logDetail.DateTimestamp = DateTime.Now;
            _logDetail.ExceptionMessage = ex.Message;
            _logDetail.ExceptionStackTrace = ex.StackTrace ?? string.Empty;
            _logDetail.InnerExceptionMessage = ex.InnerException?.Message ?? string.Empty;
            _logDetail.InnerExceptionStackTrace = ex.InnerException?.StackTrace ?? string.Empty;
            _logger.Error(ex, LogError(_logDetail));
            return await Task.FromResult(
                ResponseCreation.CreateInternalServerErrorResponse(_suffixSourceName, _logDetail.LogLabel));
        }
        catch (Exception ex)
        {
            _logDetail.EventLabel = "Unsuccessful";
            _logDetail.LogLabel = "API Exception Occurred.";
            _logDetail.DateTimestamp = DateTime.Now;
            _logDetail.ExceptionMessage = ex.Message;
            _logDetail.ExceptionStackTrace = ex.StackTrace ?? string.Empty;
            _logDetail.InnerExceptionMessage = ex.InnerException?.Message ?? string.Empty;
            _logDetail.InnerExceptionStackTrace = ex.InnerException?.StackTrace ?? string.Empty;
            _logger.Error(ex, LogError(_logDetail));
            return await Task.FromResult(
                ResponseCreation.CreateInternalServerErrorResponse(_suffixSourceName, _logDetail.LogLabel));
        }
    }

    [HttpPut("remove-stock-item")]
    public async Task<WrapperResponse> RemoveStockItem(int stockId)
    {
        var message = string.Empty;
        var source = $"{_suffixSourceName}-{nameof(GetStockItem)}";

        try
        {
            var stock = new StockItemDelete(_db, _logger).RemoveStock(stockId);

            if (stock is false)
            {
                message = $"Failed to remove stock item";
                _logDetail.LogLabel = message;
                _logDetail.DateTimestamp = DateTime.Now;
                _logDetail.EventLabel = $"Action: stock Id {stockId} returned null values";
                _logger.Information(LogInfo(_logDetail));

                return await Task.FromResult(
                    ResponseCreation.CreateErrorResponse(source, message));
            }

            if (stock is null)
            {
                message = $"No stock item found to remove";
                _logDetail.LogLabel = message;
                _logDetail.DateTimestamp = DateTime.Now;
                _logDetail.EventLabel = $"Action: stock Id {stockId} returned null values";
                _logger.Information(LogInfo(_logDetail));

                return await Task.FromResult(
                    ResponseCreation.CreateNotFoundErrorResponse(source, message));
            }

            message = "Successfully removed stock";
            return await Task.FromResult(ResponseCreation.CreateSuccessResponse(source, stock, message));
        }
        catch (DbUpdateConcurrencyException ex)
        {
            _logDetail.EventLabel = "Unsuccessful";
            _logDetail.LogLabel = "DbUpdate Concurrency Exception Occurred";
            _logDetail.DateTimestamp = DateTime.Now;
            _logDetail.ExceptionMessage = ex.Message;
            _logDetail.ExceptionStackTrace = ex.StackTrace ?? string.Empty;
            _logDetail.InnerExceptionMessage = ex.InnerException?.Message ?? string.Empty;
            _logDetail.InnerExceptionStackTrace = ex.InnerException?.StackTrace ?? string.Empty;
            _logger.Error(ex, LogError(_logDetail));
            return await Task.FromResult(
                ResponseCreation.CreateInternalServerErrorResponse(_suffixSourceName, _logDetail.LogLabel));
        }
        catch (DbException ex)
        {
            _logDetail.EventLabel = "Unsuccessful";
            _logDetail.LogLabel = "Database Exception Occurred.";
            _logDetail.DateTimestamp = DateTime.Now;
            _logDetail.ExceptionMessage = ex.Message;
            _logDetail.ExceptionStackTrace = ex.StackTrace ?? string.Empty;
            _logDetail.InnerExceptionMessage = ex.InnerException?.Message ?? string.Empty;
            _logDetail.InnerExceptionStackTrace = ex.InnerException?.StackTrace ?? string.Empty;
            _logger.Error(ex, LogError(_logDetail));
            return await Task.FromResult(
                ResponseCreation.CreateInternalServerErrorResponse(_suffixSourceName, _logDetail.LogLabel));
        }
        catch (Exception ex)
        {
            _logDetail.EventLabel = "Unsuccessful";
            _logDetail.LogLabel = "API Exception Occurred.";
            _logDetail.DateTimestamp = DateTime.Now;
            _logDetail.ExceptionMessage = ex.Message;
            _logDetail.ExceptionStackTrace = ex.StackTrace ?? string.Empty;
            _logDetail.InnerExceptionMessage = ex.InnerException?.Message ?? string.Empty;
            _logDetail.InnerExceptionStackTrace = ex.InnerException?.StackTrace ?? string.Empty;
            _logger.Error(ex, LogError(_logDetail));
            return await Task.FromResult(
                ResponseCreation.CreateInternalServerErrorResponse(_suffixSourceName, _logDetail.LogLabel));
        }
    }
}