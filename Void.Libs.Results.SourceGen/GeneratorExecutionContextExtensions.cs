using Microsoft.CodeAnalysis;

namespace Void.Libs.Results.SourceGen;

public static class GeneratorExecutionContextExtensions
{
    public static void ReportDiagnostic(this GeneratorExecutionContext context, string id, string message, DiagnosticSeverity severity = DiagnosticSeverity.Info, Location? location = null)
    {
        message = $"[VoidLibsResults] {message}";
        var diagnosticDescriptor = new DiagnosticDescriptor(id, message, message, "VRG", severity, true);
        context.ReportDiagnostic(Diagnostic.Create(diagnosticDescriptor, location));
    }
}