using Void.Libs.Example;
using Void.Libs.Example.Generated;

SimpleResultExample.New
    .WithWarning("Hello world!")
    .WithError("Hello world!", "Caused by description");

SimpleResultExample<string>.New
    .WithWarning("Hello world!")
    .WithError("Hello world!", "Caused by description")
    .WithData("Some resulting data");
    
CustomResultExample.New
    .WithWarning(ExampleWarningEnum.None, "Hello world!")
    .WithError(ExampleErrorEnum.SomeError, "Hello world!", "Caused by description");
    
CustomResultExample<string>.New
    .WithWarning(ExampleWarningEnum.None, "Hello world!")
    .WithError(ExampleErrorEnum.SomeError, "Hello world!", "Caused by description")
    .WithData("Some resulting data");

