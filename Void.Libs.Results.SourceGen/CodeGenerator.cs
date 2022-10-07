using System.Text.RegularExpressions;
using Void.Libs.Results.SourceGen.Configuration;

namespace Void.Libs.Results.SourceGen;

public class CodeGenerator
{
    private readonly string _template;

    public CodeGenerator(string template)
    {
        _template = template;
    }

    public string GenerateWith(Dictionary<string, string> variables)
    {
        return Regex.Replace(_template, @"(_[a-zA-Z]{1,})", m => variables.TryGetValue(m.Groups[1].Value, out var value) ? value : m.Groups[1].Value);
    }

    public Dictionary<string, string> BuildBasicVariables(BaseGenerationInfo baseGenerationInfo)
    {
        return new Dictionary<string, string>
        {
            { "_ClassNameSpace", baseGenerationInfo.Namespace },
            { "_ClassName", baseGenerationInfo.ClassName }
        };
    }
}