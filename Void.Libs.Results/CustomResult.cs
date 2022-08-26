using System.Diagnostics.CodeAnalysis;

namespace Void.Libs.Results;

[SuppressMessage("ReSharper", "UnusedMember.Global", Justification = "Methods will be used in auto-generated code.")]
public abstract class CustomResult<TWarningEnum, TErrorEnum>
    where TWarningEnum : Enum
    where TErrorEnum : Enum
{
    public bool Successful { get; set; } = true;
    public CustomReportedMessage<TErrorEnum> Error { get; private set; }
    public IList<CustomReportedMessage<TWarningEnum>> Warnings { get; } = new List<CustomReportedMessage<TWarningEnum>>();

    protected void InternalWithWarning(TWarningEnum warning)
    {
        Warnings.Add(new CustomReportedMessage<TWarningEnum>(warning, null, null));
    }
    
    protected void InternalWithWarning(TWarningEnum warning, string? message, string? causedBy = null)
    {
        Warnings.Add(new CustomReportedMessage<TWarningEnum>(warning, message, causedBy));
    }

    protected void InternalWithWarning(CustomReportedMessage<TWarningEnum> warning)
    {
        Warnings.Add(warning);
    }
    
    protected void InternalWithError(TErrorEnum error)
    {
        Successful = false;
        Error = new CustomReportedMessage<TErrorEnum>(error, null, null);
    }
    
    protected void InternalWithError(TErrorEnum error, string? message, string? causedBy = null)
    {
        Successful = false;
        Error = new CustomReportedMessage<TErrorEnum>(error, message, causedBy);
    }

    protected void InternalWithError(CustomReportedMessage<TErrorEnum> error)
    {
        Successful = false;
        Error = error;
    }
    
    protected void InternalWithException(TErrorEnum error, Exception ex)
    {
        Successful = false;
        Error = new CustomReportedMessage<TErrorEnum>(error, ex.Message, ex.StackTrace, ex);
    }
}

public class CustomResult<TWarningEnum, TErrorEnum, TData> : CustomResult<TWarningEnum, TErrorEnum>
    where TWarningEnum : Enum
    where TErrorEnum : Enum
{
    public TData? Data { get; set; }

    protected void InternalWithResult(TData? result)
    {
        Data = result;
    }
}
