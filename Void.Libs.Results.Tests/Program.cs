namespace Void.Libs.Results.Tests;

public static class Program
{
    public static void Main()
    {
        var result = Test2Result
            .New()
            .WithWarning(UniversalCode.A);
    }
}