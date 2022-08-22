using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Void.Libs.Results.SourceGen.CodeTemplates;

namespace Void.Libs.Results.SourceGen;

[Generator]
public class ImplicitResultGenerator : ISourceGenerator
{
    private static readonly HashSet<string> AvailableResultTypes = new()
    {
        "CustomResult"
    };

    public void Initialize(GeneratorInitializationContext context)
    {
        context.RegisterForSyntaxNotifications(() => new AttributeSyntaxReceiver());
    }

    public void Execute(GeneratorExecutionContext context)
    {
        if (!Debugger.IsAttached)
        {
            //Debugger.Launch();
        }

        var classesToProcess = (context.SyntaxReceiver as AttributeSyntaxReceiver)!.ClassesToProcess;

        foreach (var syntax in classesToProcess)
        {
            var methodInfo = CollectMethodInfo(context, syntax);

            if (methodInfo == null)
            {
                continue;
            }

            var source = GeneratePartialClass(methodInfo);
            context.AddSource($"{methodInfo.ClassName}.g.cs", source);
        }
    }

    private static string GeneratePartialClass(ResolvedMethodInfo methodInfo)
    {
        return methodInfo.GenericArguments.Length switch
        {
            2 => GenerateFunctions("CustomResultTemplate.cs", methodInfo),
            3 => GenerateFunctions("CustomResultDataTemplate.cs", methodInfo),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private static string GenerateFunctions(string fileName, ResolvedMethodInfo methodInfo)
    {
        var sourceCodeStream = typeof(ImplicitResultGenerator).Assembly.GetManifestResourceStream($"{typeof(CodeTemplatesRoot).Namespace}.{fileName}");
        using var streamReader = new StreamReader(sourceCodeStream!, Encoding.UTF8);
        var sourceCode = streamReader.ReadToEnd();

        var parameters = new Dictionary<string, string>
        {
            { "_ClassName", methodInfo.ClassName },
            { "_BaseTypeName", methodInfo.BaseTypeName },
            { "_BaseFullDeclaration", $"{methodInfo.BaseTypeName}<{methodInfo.WarningEnum}, {methodInfo.ErrorEnum}{(methodInfo.CustomDataType != null ? $", {methodInfo.CustomDataType}" : null)}>" },
            { "_ClassNameSpace", methodInfo.ClassNameSpace },
            { "_FileUsings", methodInfo.FileUsings },
            { "_WarningEnum", methodInfo.WarningEnum },
            { "_ErrorEnum", methodInfo.ErrorEnum },
            { "_CustomDataType", methodInfo.CustomDataType ?? string.Empty },
            { "_CurrentDate", DateTime.UtcNow.ToString("O") }
        };
        
        return Regex.Replace(sourceCode, @"(_[a-zA-Z0-9]{1,})", m => parameters.TryGetValue(m.Groups[1].Value, out var value) ? value : m.Groups[1].Value);
    } 

    private static ResolvedMethodInfo? CollectMethodInfo(GeneratorExecutionContext context, ClassDeclarationSyntax syntax)
    {
        // TODO: This looks awful. Refactor this later. Is there's even an easier way to do this?
        
        var className = syntax.Identifier.ToString();

        if (syntax.ChildTokens().All(x => x.Text != "partial"))
        {
            var localizedString = new LocalizableResourceString("ShouldBePartial", Messages.ResourceManager, typeof(Messages), className);
            var diagnostic = Diagnostic.Create("VRG001", "VRG", localizedString, DiagnosticSeverity.Error, DiagnosticSeverity.Error, true, 0, location: syntax.Identifier.GetLocation());
            context.ReportDiagnostic(diagnostic);
        }
        
        var classNamespaceSyntax = syntax.Parent;

        if (classNamespaceSyntax is not NamespaceDeclarationSyntax && classNamespaceSyntax is not FileScopedNamespaceDeclarationSyntax)
        {
            var localizedString = new LocalizableResourceString("CantBeANestedClass", Messages.ResourceManager, typeof(Messages), className);
            var diagnostic = Diagnostic.Create("VRG002", "VRG", localizedString, DiagnosticSeverity.Error, DiagnosticSeverity.Error, true, 0, location: syntax.Identifier.GetLocation());
            context.ReportDiagnostic(diagnostic);
        }

        var baseType = syntax.BaseList?.Types.FirstOrDefault(x => AvailableResultTypes.Contains(x.Type.ChildTokens().First().ToString()))?.ChildNodes().First();
        var baseTypeName = baseType?.ChildTokens().First().ToString();
        var genericArguments = baseType?.ChildNodes().First().ChildNodes().Select(node => node.ToString()).ToArray();
        classNamespaceSyntax = classNamespaceSyntax?.ChildNodes().First();

        if (baseTypeName == null || genericArguments == null || classNamespaceSyntax is not QualifiedNameSyntax)
        {
            var localizedString = new LocalizableResourceString("UnableToExtractInformation", Messages.ResourceManager, typeof(Messages), className);
            var diagnostic = Diagnostic.Create("VRG100", "VRG", localizedString, DiagnosticSeverity.Error, DiagnosticSeverity.Error, true, 0, location: syntax.Identifier.GetLocation());
            context.ReportDiagnostic(diagnostic);
            return null;
        }
        
        var classNamespace = classNamespaceSyntax.ToString();
        var parsedUsings = syntax.Parent?.ChildNodes().Where(x => x is UsingDirectiveSyntax).Select(x => x.ToString()).ToArray();
        var fileUsings = string.Join(Environment.NewLine, parsedUsings ?? Array.Empty<string>());

        return new ResolvedMethodInfo
        {
            ClassName = className,
            BaseTypeName = baseTypeName,
            GenericArguments = genericArguments,
            ClassNameSpace = classNamespace,
            FileUsings = fileUsings
        };
    }
}