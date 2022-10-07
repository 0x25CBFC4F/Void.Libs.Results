namespace Void.Libs.Results.SourceGen.Configuration;

public class BaseGenerationInfo
{
    public string Namespace { get; set; } = "Void.Libs.Results";
    public string ClassName { get; set; }
    
    public bool IncludeDataVariant { get; set; } = true;
}