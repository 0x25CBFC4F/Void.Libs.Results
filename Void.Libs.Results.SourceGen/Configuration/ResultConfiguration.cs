namespace Void.Libs.Results.SourceGen.Configuration;

public class ResultConfiguration
{
    public bool Enabled { get; set; }
    
    public SimpleResultConfiguration? Simple { get; set; }
    
    public CustomResultConfiguration[]? Custom { get; set; }
}