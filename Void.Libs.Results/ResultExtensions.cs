namespace Void.Libs.Results;

public static class ResultExtensions
{
    public static T WithWarning<T>(this T result, string message, string? causedBy = null)
        where T : Result
    {
        result.Warnings.Add(new ReportedMessage(message, causedBy));
        return result;
    }
    
    public static T WithError<T>(this T result, string message, string? causedBy = null)
        where T : Result
    {
        result.Successful = false;
        result.Errors.Add(new ReportedMessage(message, causedBy));
        return result;
    }
}