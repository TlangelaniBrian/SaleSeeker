using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.RegularExpressions;

namespace SaleSeeker_Api.Utils.Exceptions;

public class ExceptionHandler
{

    internal static bool IsRecognizedErrorMessage(KeyValuePair<string, ModelStateEntry> keyValuePair, out string? customErrorMessage)
    {

        var badRequestDueToInvalidObject = new Regex(@"^\$\.result\[(\d+)\]\.");

        if (badRequestDueToInvalidObject.IsMatch(keyValuePair.Key))
        {
            customErrorMessage = "The request object is invalid";
            return true;
        }

        if (!string.IsNullOrEmpty(keyValuePair.Key) && keyValuePair.Value.ValidationState == ModelValidationState.Invalid)
        {
            customErrorMessage = $"The request has the following invalid property: {keyValuePair.Key}";
            return true;
        }

        customErrorMessage = "Internal Server Error";
        return false;
    }
}