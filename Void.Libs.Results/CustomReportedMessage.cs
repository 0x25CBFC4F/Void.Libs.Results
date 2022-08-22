namespace Void.Libs.Results;

public record CustomReportedMessage<TEnum>(TEnum Code, string? Message, string? CausedBy) where TEnum : Enum;
