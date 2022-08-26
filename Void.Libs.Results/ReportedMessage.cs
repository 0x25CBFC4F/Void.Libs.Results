namespace Void.Libs.Results;

public record ReportedMessage(string Message, string? CausedBy = null, Exception? Exception = null);
