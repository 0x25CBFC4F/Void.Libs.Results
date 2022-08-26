namespace Void.Libs.Results.Tests;

public class SimpleResultTests
{
    [Fact]
    public void Must_Report_Warnings_Correctly()
    {
        var result = Result.New
            .WithWarning(string.Empty)
            .WithWarning(new ReportedMessage(string.Empty));
        
        Assert.True(result.Successful);
        Assert.NotEmpty(result.Warnings);
        Assert.True(result.Warnings.Count == 2);
    }
    
    [Fact]
    public void Must_Report_Error_Correctly_With_Args()
    {
        var result = Result.New
            .WithError(string.Empty);
        
        Assert.False(result.Successful);
        Assert.NotNull(result.Error);
    }
    
    [Fact]
    public void Must_Report_Error_Correctly_With_Message()
    {
        var result = Result.New
            .WithError(new ReportedMessage(string.Empty));
        
        Assert.False(result.Successful);
        Assert.NotNull(result.Error);
    }

    [Fact]
    public void Exception_Method_Must_Report_Message_And_StackTrace()
    {
        var exception = new Exception("Exception message");

        var result = Result.New
            .WithException(exception);
        
        Assert.False(result.Successful);
        Assert.NotNull(result.Error);
        
        Assert.Equal(exception.Message, result.Error.Message);
        Assert.Equal(exception.StackTrace, result.Error.CausedBy);
        Assert.Equal(exception, result.Error.Exception);
    }
    
    [Fact]
    public void Must_Report_Data_Correctly()
    {
        var resultObject = new object();
        var result = Result<object>.New.WithResult(resultObject);
        
        Assert.True(result.Successful);
        Assert.NotNull(result.Data);
        Assert.Same(resultObject, result.Data);
    }
}