namespace Void.Libs.Results;

public class Result
{
    public bool Successful { get; set; } = true;
    public IList<ReportedMessage> Warnings { get; } = new List<ReportedMessage>();
    public IList<ReportedMessage> Errors { get; } = new List<ReportedMessage>();
    
    public Result WithWarning(string message, string? causedBy = null)
    {
        Warnings.Add(new ReportedMessage(message, causedBy));
        return this;
    }

    public Result WithError(string message, string? causedBy = null)
    {
        Successful = false;
        Errors.Add(new ReportedMessage(message, causedBy));
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
        Errors.Add(error);
        return this;
    }
}

public class Result<TData> : Result
{
    public TData? Data { get; set; }

    public Result<TData> WithResult(TData? data)
    {
        Data = data;
        return this;
    }
}
