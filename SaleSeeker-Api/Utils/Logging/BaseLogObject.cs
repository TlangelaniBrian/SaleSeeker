namespace SaleSeeker_Api.Utils.Logging;


public abstract class BaseLogObject
{
    public int UserId { get; set; } = 0;
    public string ClassName { get; set; } = string.Empty;
    public string LogLabel { get; set; } = string.Empty;
    public string Service { get; set; } = string.Empty;
    public string EventLabel { get; set; } = string.Empty;
    public string MethodName { get; set; } = string.Empty;
    public string Endpoint { get; set; } = string.Empty;
    public DateTime DateTimestamp { get; set; }
    public string ExceptionMessage { get; set; } = string.Empty;
    public string ExceptionStackTrace { get; set; } = string.Empty;
    public string InnerExceptionMessage { get; set; } = string.Empty;
    public string InnerExceptionStackTrace { get; set; } = string.Empty;
}

public class LogObject : BaseLogObject
{
    public int SellerId { get; set; } = 0;
    public int ItemId { get; set; } = 0;
}

public class LogGeneralObject : BaseLogObject
{
}