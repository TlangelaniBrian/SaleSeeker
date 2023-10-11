namespace SaleSeeker_Api.Utils.Logging;

public static class LogWrapper
{
    public static string LogInfo(LogObject log)
    {
        return string.Format("<{0}>" +
                             "<log>{1}</log>" +
                             "<event>{2}</event>" +
                             "<UserId>{3}</UserId>" +
                             "<ItemId>{4}</ItemId>" +
                             "<SellerId>{5}</SellerId>" +
                             "<method>{6}</method>" +
                             "<endpoint>{7}</endpoint>" +
                             "<datetime>{8}</datetime>" +
                             "<service>{9}</service>" +
                             "</{0}>",
            log.ClassName,
            log.LogLabel,
            log.EventLabel,
            log.UserId,
            log.ItemId,
            log.SellerId,
            log.MethodName,
            log.Endpoint,
            log.DateTimestamp,
            log.Service
        );
    }

    public static string LogInfo(LogGeneralObject log)
    {
        return string.Format("<{0}>" +
                             "<log>{1}</log>" +
                             "<event>{2}</event>" +
                             "<UserId>{3}</UserId>" +
                             "<method>{4}</method>" +
                             "<endpoint>{5}</endpoint>" +
                             "<datetime>{6}</datetime>" +
                             "<service>{7}</service>" +
                             "</{0}>",
            log.ClassName,
            log.LogLabel,
            log.EventLabel,
            log.UserId,
            log.MethodName,
            log.Endpoint,
            log.DateTimestamp,
            log.Service
        );
    }

    public static string LogWarning(LogObject log)
    {
        return string.Format("<{0}>" +
                             "<log>{1}</log>" +
                             "<event>{2}</event>" +
                             "<UserId>{3}</UserId>" +
                             "<ItemId>{4}</ItemId>" +
                             "<SellerId>{5}</SellerId>" +
                             "<method>{6}</method>" +
                             "<endpoint>{7}</endpoint>" +
                             "<datetime>{8}</datetime>" +
                             "<service>{9}</service>" +
                             "</{0}>",
            log.ClassName,
            log.LogLabel,
            log.EventLabel,
            log.UserId,
            log.ItemId,
            log.SellerId,
            log.MethodName,
            log.Endpoint,
            log.DateTimestamp,
            log.Service
        );
    }

    public static string LogError(LogObject log)
    {
        return string.Format("<{0}>" +
                             "<log>{1}</log>" +
                             "<event>{2}</event>" +
                             "<UserId>{3}</UserId>" +
                             "<ItemId>{4}</ItemId>" +
                             "<SellerId>{5}</SellerId>" +
                             "<method>{6}</method>" +
                             "<endpoint>{7}</endpoint>" +
                             "<datetime>{8}</datetime>" +
                             "<service>{9}</service>" +
                             "<exception>" +
                             "<message>{10}</message>" +
                             "<stacktrace>{11}</stacktrace>" +
                             "<innerexception>" +
                             "<message>{12}</message>" +
                             "<stacktrace>{13}</stacktrace>" +
                             "</innerexception>" +
                             "</exception>" +
                             "</{0}>",
            log.ClassName,
            log.LogLabel,
            log.EventLabel,
            log.UserId,
            log.ItemId,
            log.SellerId,
            log.MethodName,
            log.Endpoint,
            log.DateTimestamp,
            log.Service,
            log.ExceptionMessage,
            log.ExceptionStackTrace,
            log.InnerExceptionMessage,
            log.InnerExceptionStackTrace
        );
    }

    public static string LogError(LogGeneralObject log)
    {
        return string.Format("<{0}>" +
                             "<log>{1}</log>" +
                             "<event>{2}</event>" +
                             "<UserId>{3}</UserId>" +
                             "<method>{4}</method>" +
                             "<endpoint>{5}</endpoint>" +
                             "<datetime>{6}</datetime>" +
                             "<service>{7}</service>" +
                             "<exception>" +
                             "<message>{8}</message>" +
                             "<stacktrace>{9}</stacktrace>" +
                             "<innerexception>" +
                             "<message>{10}</message>" +
                             "<stacktrace>{11}</stacktrace>" +
                             "</innerexception>" +
                             "</exception>" +
                             "</{0}>",
            log.ClassName,
            log.LogLabel,
            log.EventLabel,
            log.UserId,
            log.MethodName,
            log.Endpoint,
            log.DateTimestamp,
            log.Service,
            log.ExceptionMessage,
            log.ExceptionStackTrace,
            log.InnerExceptionMessage,
            log.InnerExceptionStackTrace
        );
    }

    public static string LogFatal(LogObject log)
    {
        return string.Format("<{0}>" +
                             "<log>{1}</log>" +
                             "<event>{2}</event>" +
                             "<UserId>{3}</UserId>" +
                             "<itemID>{4}</itemID>" +
                             "<sellerId>{5}</sellerId>" +
                             "<method>{6}</method>" +
                             "<endpoint>{7}</endpoint>" +
                             "<datetime>{8}</datetime>" +
                             "<service>{9}</service>" +
                             "<exception>" +
                             "<message>{10}</message>" +
                             "<stacktrace>{11}</stacktrace>" +
                             "<innerexception>" +
                             "<message>{12}</message>" +
                             "<stacktrace>{13}</stacktrace>" +
                             "</innerexception>" +
                             "</exception>" +
                             "</{0}>",
            log.ClassName,
            log.LogLabel,
            log.EventLabel,
            log.UserId,
            log.ItemId,
            log.SellerId,
            log.MethodName,
            log.Endpoint,
            log.DateTimestamp,
            log.Service,
            log.ExceptionMessage,
            log.ExceptionStackTrace,
            log.InnerExceptionMessage,
            log.InnerExceptionStackTrace
        );
    }
}