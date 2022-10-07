namespace Void.Libs.Results.SourceGen.Configuration;

public class CustomResultConfiguration : BaseGenerationInfo
{
    public bool UseWarningEnumForErrors { get; set; }
    public string WarningEnum { get; set; }

    private string? _errorEnum;
    
    public string? ErrorEnum
    {
        get => UseWarningEnumForErrors ? WarningEnum : _errorEnum;
        set => _errorEnum = value;
    }
}