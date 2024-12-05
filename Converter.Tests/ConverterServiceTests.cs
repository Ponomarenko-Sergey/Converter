using Converter.Core.Interfaces;
using Converter.Core.Services;
using Moq;

namespace Converter.Tests;

public class ConverterServiceTests
{
    [Fact]
    public void Process_ValidInput_ProcessesCorrectly()
    {
        var mockInputHandler = new Mock<IInputHandler>();
        var mockConverterMapper = new Mock<IConverterMapper>();
        var mockOutputHandler = new Mock<IOutputHandler>();

        var inputLines = new List<string> { "hello", "world" };
        var outputLines = new List<string> { "Case #1: 4433555 555666", "Case #2: 96667775553" };

        mockInputHandler.Setup(m => m.ReadInput(It.IsAny<string>())).Returns(inputLines);
        mockConverterMapper.Setup(m => m.Convert("hello")).Returns("4433555 555666");
        mockConverterMapper.Setup(m => m.Convert("world")).Returns("96667775553");

        var service = new ConverterService(mockInputHandler.Object, mockConverterMapper.Object, mockOutputHandler.Object);
        service.Process("input.txt", "output.txt");

        mockInputHandler.Verify(m => m.ReadInput("input.txt"), Times.Once);
        mockConverterMapper.Verify(m => m.Convert(It.IsAny<string>()), Times.Exactly(2));
        mockOutputHandler.Verify(m => m.WriteOutput("output.txt", outputLines), Times.Once);
    }
}
