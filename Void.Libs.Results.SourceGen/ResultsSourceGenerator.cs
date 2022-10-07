using System.Diagnostics;
using System.Text;
using System.Text.Json;
using Microsoft.CodeAnalysis;
using Void.Libs.Results.SourceGen.CodeTemplates;
using Void.Libs.Results.SourceGen.Configuration;

namespace Void.Libs.Results.SourceGen;

[Generator(LanguageNames.CSharp)]
public class ResultsSourceGenerator : ISourceGenerator
{
    private const string ConfigurationFileName = "results.config.json";

    private readonly JsonSerializerOptions _jsonSerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };
    
    public void Initialize(GeneratorInitializationContext context)
    {
    }

    public void Execute(GeneratorExecutionContext context)
    {
#if DEBUG
        if (!Debugger.IsAttached)
        {
            //Debugger.Launch();
        }
#endif

        var configurationFile = LoadConfiguration(context);

        if (configurationFile is not { Enabled: true })
        {
            return;
        }

        if (configurationFile.Simple?.Generate == true)
        {
            var simpleResultTemplate = new SimpleResultTemplate
            {
                Settings = configurationFile.Simple
            };
            
            context.AddSource($"{configurationFile.Simple.ClassName}.g.cs", simpleResultTemplate.TransformText());

            var reportedMessageTemplate = new ReportedMessageTemplate();
            context.AddSource("ReportedMessage.g.cs", reportedMessageTemplate.TransformText());
        }

        if (configurationFile.Custom == null || !configurationFile.Custom.Any())
        {
            return;
        }
        
        var customReportedMessageTemplate = new CustomReportedMessageTemplate();
        context.AddSource("CustomReportedMessage.g.cs", customReportedMessageTemplate.TransformText());

        foreach (var customResultConfiguration in configurationFile.Custom)
        {
            var customResultTemplate = new CustomResultTemplate
            {
                Settings = customResultConfiguration
            };
            
            context.AddSource($"{customResultConfiguration.ClassName}.g.cs", customResultTemplate.TransformText());
        }
    }

    private ResultConfiguration? LoadConfiguration(GeneratorExecutionContext context)
    {
        var configurationFile = context.AdditionalFiles
            .Where(file => Path.GetFileName(file.Path).Equals(ConfigurationFileName, StringComparison.InvariantCultureIgnoreCase)).ToArray();

        if (!configurationFile.Any())
        {
            context.ReportDiagnostic("VRG001", "No configuration file was found. No result types were generated.", DiagnosticSeverity.Warning);
            return null;
        }

        if (configurationFile.Length > 1)
        {
            context.ReportDiagnostic("VRG002", "Multiple configuration files were found.", DiagnosticSeverity.Error);
            return null;
        }

        var configurationJson = File.ReadAllText(configurationFile.First().Path, Encoding.UTF8);
        var configuration = JsonSerializer.Deserialize<ResultConfiguration>(configurationJson, _jsonSerializerOptions);
        return configuration;
    }
}