# Installation

1. Install [Void.Libs.Results.SourceGen](https://www.nuget.org/packages/Void.Libs.Results.SourceGen) to your project. Through IDE of your choice.

*..or via dotnet command*
```bash
dotnet add package Void.Libs.Results.SourceGen
```

2. Create file called `results.config.json` somewhere in your project.
3. Set config file 'Build Action' to 'AdditionalFiles'

*..or do this in your project XML*
```xml
<ItemGroup>
    <None Remove="results.config.json" />
    <AdditionalFiles Include="results.config.json" />
</ItemGroup>
```

4. Configure source generator.
5. Done!

# Config file example and explanation

## `results.config.json` example contents:
```json
{
  "enabled": true,
  "simple": {
    "generate": true,
    "namespace": "Void.Libs.Example.Generated",
    "className": "SimpleResultExample",
    "includeDataVariant": true
  },
  "custom": [
    {
      "namespace": "Your.Namespace.Generated",
      "className": "CustomResultExample",
      "useWarningEnumForErrors": false,
      "warningEnum": "Your.Namespace.ExampleEnum",
      "errorEnum": "Your.Namespace.ExampleEnum",
      "includeDataVariant": true
    }
  ]
}
```

## Config file explanation

> <span style="color: #f39c12">Warning!</span> Please do not include comments when configuring this source generator.

```json
{
  // Sets if this source generator needs to generate anything. Quick on-off switch.
  "enabled": true,

  // Simple result type. Does not include custom Enum codes.
  "simple": {
    // On-off switch to generate simple type.
    "generate": true,
    // Namespace for simple result type.
    "namespace": "Void.Libs.Example.Generated",
    // Class name of the simple result type.
    "className": "SimpleResultExample",
    // Include data variant. In this example will generate SimpleResultExample<T> and .WithData(TData? data) method
    "includeDataVariant": true
  },

  // Custom result types. You can define any amount of them.
  "custom": [
    {
      // Namespace for custom result type.
      "namespace": "Your.Namespace.Generated",
      // Class name of the custom result type.
      "className": "CustomResultExample",
      // Switch to ignore 'errorEnum' property. 'warningEnum' will be used both for warnings and errors.
      "useWarningEnumForErrors": false,
      // Warning Enum full namespace and class name.
      "warningEnum": "Your.Namespace.ExampleEnum",
      // Error Enum full namespace and class name.
      "errorEnum": "Your.Namespace.ExampleEnum",
      // Include data variant. In this example will generate CustomResultExample<T> and .WithData(TData? data) method
      "includeDataVariant": true
    }
  ]
}
```
