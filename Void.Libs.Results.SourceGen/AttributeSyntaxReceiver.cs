using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Void.Libs.Results.SourceGen;

public class AttributeSyntaxReceiver : ISyntaxReceiver
{
    public List<ClassDeclarationSyntax> ClassesToProcess { get; } = new();

    public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
    {
        if (syntaxNode is ClassDeclarationSyntax cds)
        {
            if (!cds.AttributeLists.Any(al => al.Attributes.Any(a => a.GetText().ToString().Equals("GeneratedResult"))))
            {
                return;
            }

            ClassesToProcess.Add(cds);
        }
    }
}