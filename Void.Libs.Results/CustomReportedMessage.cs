namespace Void.Libs.Results;

public record CustomReportedMessage<TEnum>(TEnum Code, string? Message, string? CausedBy = null, Exception? Exception = null) where TEnum : Enum;
