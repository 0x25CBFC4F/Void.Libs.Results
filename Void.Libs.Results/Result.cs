namespace Void.Libs.Results;

public class Result
{
    public bool Successful { get; private set; } = true;
    public ReportedMessage? Error { get; private set; }
    public IList<ReportedMessage> Warnings { get; } = new List<ReportedMessage>();

    public static Result New => new();
    
    public Result WithWarning(string message, string? causedBy = null)
    {
        Warnings.Add(new ReportedMessage(message, causedBy));
        return this;
    }

    public Result WithError(string message, string? causedBy = null)
    {
        Successful = false;
        Error = new ReportedMessage(message, causedBy);
        return this;
    }
    
    public Result WithWarning(ReportedMessage warning)
    {
        Warnings.Add(warning);
        return this;
    }

    public Result WithError(ReportedMessage error)
    {
        Successful = false;
        Error = error;
        return this;
    }

    public Result WithException(Exception ex)
    {
        WithError(new ReportedMessage(ex.Message, ex.StackTrace, ex));
        return this;
    }
}

public class Result<TData> : Result
{
    public TData? Data { get; set; }
    
    public new static Result<TData> New => new();

    public Result<TData> WithResult(TData? data)
    {
        Data = data;
        return this;
    }
}
