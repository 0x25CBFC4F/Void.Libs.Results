using Void.Libs.Results.Tests.Models;

namespace Void.Libs.Results.Tests;

public class CustomResultTests
{
    [Fact]
    public void Must_Report_Warnings_Correctly()
    {
        var result = TestResult.New
            .WithWarning(TestWarning.A)
            .WithWarning(TestWarning.B, string.Empty)
            .WithWarning(new CustomReportedMessage<TestWarning>(TestWarning.C, string.Empty));

        Assert.True(result.Successful);
        Assert.NotEmpty(result.Warnings);
        Assert.True(result.Warnings.Count == 3);
    }
    
    [Fact]
    public void Must_Report_Error_Correctly_With_Args()
    {
        var result = TestResult.New
            .WithError(TestError.A, string.Empty);
        
        Assert.False(result.Successful);
        Assert.NotNull(result.Error);
    }
    
    [Fact]
    public void Must_Report_Error_Correctly_With_Message()
    {
        var result = TestResult.New
            .WithError(new CustomReportedMessage<TestError>(TestError.A, string.Empty));
        
        Assert.False(result.Successful);
        Assert.NotNull(result.Error);
    }
    
    [Fact]
    public void Must_Report_Error_Correctly_With_Code()
    {
        var result = TestResult.New
            .WithError(TestError.A);
        
        Assert.False(result.Successful);
        Assert.NotNull(result.Error);
    }

    [Fact]
    public void Exception_Method_Must_Report_Message_And_StackTrace()
    {
        var exception = new Exception("Exception message");

        var result = TestResult.New
            .WithException(TestError.A, exception);
        
        Assert.False(result.Successful);
        Assert.NotNull(result.Error);
        
        Assert.Equal(exception.Message, result.Error!.Message);
        Assert.Equal(exception.StackTrace, result.Error.CausedBy);
        Assert.Same(exception, result.Error.Exception);
    }

    [Fact]
    public void Must_Report_Data_Correctly()
    {
        var resultObject = new object();
        var result = TestResult.New.WithResult(resultObject);
        
        Assert.True(result.Successful);
        Assert.NotNull(result.Data);
        Assert.Same(resultObject, result.Data);
    }
}