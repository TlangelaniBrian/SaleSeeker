using Microsoft.AspNetCore.Mvc;
using SaleSeeker_Api.Utils.Response;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SaleSeeker_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    // GET: api/<AuthController>
    [HttpGet("facebook-login")]
    public async Task<WrapperResponse> LoginWithFacebook()
    {
        var message = "Successfully logged in user";
        var source = "";
        var authResult = "";
        return await Task.FromResult(ResponseCreation.CreateSuccessResponse(source, authResult, message));
    }
}