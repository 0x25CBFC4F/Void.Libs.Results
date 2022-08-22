namespace Void.Libs.Results.SourceGen;

public class ResolvedMethodInfo
{
    public string ClassName { get; set; } = null!;
    public string BaseTypeName { get; set; } = null!;
    public string[] GenericArguments { get; set; } = null!;
    public string ClassNameSpace { get; set; } = null!;
    public string FileUsings { get; set; } = null!;

    public string WarningEnum => TryGetGenericArgumentAtIndex(0) ?? throw new NotImplementedException();
    public string ErrorEnum => TryGetGenericArgumentAtIndex(1) ?? throw new NotImplementedException();
    public string? CustomDataType => TryGetGenericArgumentAtIndex(2);

    public string? TryGetGenericArgumentAtIndex(int index)
    {
        return GenericArguments.ElementAtOrDefault(index);
    }
}