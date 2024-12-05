using Converter.Core.Components;

namespace Converter.Tests;

public class ConverterMapperTests
{
    private readonly ConverterMapper _mapper;

    public ConverterMapperTests()
    {
        _mapper = new ConverterMapper();
    }

    [Theory]
    [InlineData("a", "2")]
    [InlineData("b", "22")]
    [InlineData("c", "222")]
    [InlineData("aa", "2 2")]
    [InlineData("abc", "2 22 222")]
    [InlineData("hello", "4433555 555666")]
    [InlineData("world", "96667775553")]
    [InlineData(" ", "0")]
    [InlineData("a a", "202")]
    [InlineData("hi", "44 444")]
    [InlineData("foo  bar", "333666 6660 022 2777")]
    public void Convert_ValidInput_ReturnsCorrectOutput(string input, string expected)
    {
        string result = _mapper.Convert(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Convert_InvalidCharacter_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _mapper.Convert("hello123"));
    }

}
