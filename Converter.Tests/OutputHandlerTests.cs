using Converter.Core.Components;

namespace Converter.Tests;

public class OutputHandlerTests
{
    private readonly OutputHandler _outputHandler;

    public OutputHandlerTests()
    {
        _outputHandler = new OutputHandler();
    }

    [Fact]
    public void WriteOutput_ValidLines_WritesToFileCorrectly()
    {
        string testOutputPath = "testOutput.txt";
        var cases = new List<string> { "Case #1: 2", "Case #2: 22" };

        _outputHandler.WriteOutput(testOutputPath, cases);

        var writtenLines = File.ReadAllLines(testOutputPath);
        Assert.Equal(2, writtenLines.Length);
        Assert.Equal("Case #1: 2", writtenLines[0]);
        Assert.Equal("Case #2: 22", writtenLines[1]);

        File.Delete(testOutputPath);
    }
}
