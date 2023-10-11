using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaleSeeker_Api.Models.CartItem;
using SaleSeeker_Api.Repositories;
using SaleSeeker_Api.Utils.Logging;
using SaleSeeker_Api.Utils.Response;
using System.Data.Common;
using System.Net;
using static SaleSeeker_Api.Utils.Logging.LogWrapper;
using ILogger = Serilog.ILogger;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SaleSeeker_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartController : ControllerBase
{
    private const string _suffixSourceName = "cart";
    private readonly IDbService _db;
    private readonly ILogger _logger;
    private readonly LogObject _logDetail = new LogObject();

    public CartController(IDbService db, ILogger logger)
    {
        _db = db;
        _logger = logger;
    }

    // GET: api/<CartController>
    [HttpGet("get-item")]
    [AllowAnonymous]
    public async Task<WrapperResponse> GetCartItem(string userId, int productId)
    {
        try
        {
            var message = string.Empty;
            var source = $"{_suffixSourceName}-{nameof(GetCartItem)}";
            var cart = new CartItemGet(_db, _logger).GetCartItem(userId, productId);

            if (cart == null)
            {
                message = $"No cart found for user";
                _logDetail.LogLabel = message;
                _logDetail.DateTimestamp = DateTime.Now;
                _logDetail.EventLabel = "Action: check for cart for errors";
                _logger.Information(LogInfo(_logDetail));

                return await Task.FromResult(
                    ResponseCreation.CreateNotFoundErrorResponse(source, message));
            }

            message = "Successfully loaded user cart";
            return await Task.FromResult(ResponseCreation.CreateSuccessResponse(source, cart, message));
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

    // GET api/<CartController>/5
    [HttpGet("get-items")]
    public async Task<WrapperResponse> GetCartItems(string userId, int cartId)
    {
        try
        {
            var source = $"{_suffixSourceName}-{nameof(GetCartItems)}";
            var carts = new CartItemGet(_db, _logger).GetCartItems(userId, cartId);
            return await Task.FromResult(ResponseCreation.CreateSuccessResponse(source, carts));
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

    // POST api/<CartController>
    [HttpPost("add-item")]
    public async Task<WrapperResponse> AddCartItem([FromBody] CartItemAdd item)
    {
        var source = $"{_suffixSourceName}-{nameof(AddCartItem)}";
        try
        {
            var message = "";
            if (!ModelState.IsValid)
            {
                message = $"Invalid type input payload Try Again";
                _logDetail.LogLabel = message;
                _logDetail.DateTimestamp = DateTime.Now;
                _logDetail.EventLabel = $"Action: check for Parameter cart";
                _logger.Error(LogInfo(_logDetail));

                return await Task.FromResult(
                    ResponseCreation.CreateErrorResponse(source, message));
            }

            var result = await new CartItemAdd(_db, _logger).AddItem(item);
            if (!string.IsNullOrEmpty(result.Errors))
            {
                message = result.Errors;
                _logDetail.LogLabel = message;
                _logDetail.DateTimestamp = DateTime.Now;
                _logDetail.EventLabel = "Action: check for cart for errors";
                _logger.Information(LogInfo(_logDetail));

                return await Task.FromResult(
                    ResponseCreation.CreateErrorResponse(source, message));
            }

            message = "created new cart";
            _logDetail.EventLabel = "Action: created user cart";
            _logDetail.LogLabel = message;
            _logger.Information(LogInfo(_logDetail));

            return await Task.FromResult(
                ResponseCreation.CreateSuccessResponse(source, result, message, HttpStatusCode.Created));
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

    // PUT api/<CartController>/5
    [HttpPut("update-item")]
    public async Task<WrapperResponse> UpdateCartItem([FromBody] CartItemUpdate cart)
    {
        try
        {
            var message = "updated cart";
            var source = $"{_suffixSourceName}-{nameof(UpdateCartItem)}";
            _logger.Information(LogInfo(_logDetail));
            var newUpdatedCart = new CartItemUpdate(_db, _logger).UpdateCart(cart);
            return await Task.FromResult(
                ResponseCreation.CreateSuccessResponse(source, newUpdatedCart, message));
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
            _logDetail.LogLabel = "Internal API Exception Occurred.";
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

    // DELETE api/<CartController>/5
    [HttpDelete("remove-item")]
    public async Task<WrapperResponse> RemoveCartItem(CartItemDelete cart)
    {
        try
        {
            var message = "";
            var source = $"{_suffixSourceName}-{nameof(RemoveCartItem)}";
            _logger.Information(LogInfo(_logDetail));
            var isCartRemoved = new CartItemDelete(_db, _logger).RemoveCart(cart);
            if (!isCartRemoved)
            {
                // TODO: Add log
            }

            message = "remove cart item";
            return await Task.FromResult(
                ResponseCreation.CreateSuccessResponse(source, isCartRemoved, message, HttpStatusCode.Created));
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