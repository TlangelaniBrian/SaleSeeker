using System.Net;
using Newtonsoft.Json;

namespace SaleSeeker_Api.Utils.Response;

[JsonObject(MemberSerialization.OptIn)]
public class WrapperResponse
{
    #region Properties

    [JsonProperty("code")]
    public int StatusCode { get; }

    [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
    public string? Message { get; set; }
    [JsonProperty("result", NullValueHandling = NullValueHandling.Ignore)]
    public object? Result { get; set; } = null;
    [JsonProperty("source")]
    public string Source { get; set; }
    #endregion

    #region Constructors
    public WrapperResponse(string source, HttpStatusCode statusCode, string? message = null, object? result = null)
    {
        StatusCode = (int)statusCode;
        Message = message;
        Result = result;
        Source = source;
    }
    #endregion
}