using Converter.Core.Components;

namespace Converter.Tests;

public class InputHandlerTests
{
    private readonly InputHandler _inputHandler;

    public InputHandlerTests()
    {
        _inputHandler = new InputHandler();
    }

    [Fact]
    public void ReadInput_ValidFile_ReturnsCorrectLines()
    {
        string testInputPath = "testInput.txt";
        File.WriteAllLines(testInputPath, new[] { "2", "hello", "world" });

        var result = _inputHandler.ReadInput(testInputPath);

        Assert.Equal(2, result.Count);
        Assert.Equal("hello", result[0]);
        Assert.Equal("world", result[1]);

        File.Delete(testInputPath);
    }

    [Fact]
    public void ReadInput_FileNotFound_ThrowsFileNotFoundException()
    {
        string testInputPath = "";
        Assert.Throws<FileNotFoundException>(() => _inputHandler.ReadInput(testInputPath));
    }

    [Fact]
    public void ReadInput_InvalidLinesCount_ThrowsArgumentException()
    {
        string testInputPath = "testInput.txt";
        File.WriteAllLines(testInputPath, new[] { "101", "hello" });

        Assert.Throws<ArgumentException>(() => _inputHandler.ReadInput(testInputPath));

        File.Delete(testInputPath);
    }

    [Fact]
    public void ReadInput_InvalidFirstLine_ThrowsArgumentException()
    {
        string testInputPath = "testInput.txt";
        File.WriteAllLines(testInputPath, new[] { "a" , "a" });

        Assert.Throws<ArgumentException>(() => _inputHandler.ReadInput(testInputPath));

        File.Delete(testInputPath);
    }

    [Fact]
    public void ReadInput_InsufficientLines_ThrowsInvalidOperationException()
    {
        string testInputPath = "testInput.txt";
        File.WriteAllLines(testInputPath, new[] { "2" });

        Assert.Throws<InvalidOperationException>(() => _inputHandler.ReadInput(testInputPath));

        File.Delete(testInputPath);
    }
}

