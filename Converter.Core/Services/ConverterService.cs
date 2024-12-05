using Converter.Core.Interfaces;

namespace Converter.Core.Services;

/// <summary>
/// Class for work with convertor
/// </summary>
public class ConverterService : IConverterService
{
    private readonly IInputHandler _inputHandler;
    private readonly IConverterMapper _converterMapperMapper;
    private readonly IOutputHandler _outputHandler;

    /// <summary>
    /// Constructor convertor services
    /// </summary>
    /// <param name="inputHandler"></param>
    /// <param name="converterMapperMapper"></param>
    /// <param name="outputHandler"></param>
    public ConverterService(IInputHandler inputHandler, IConverterMapper converterMapperMapper, IOutputHandler outputHandler)
    {
        _inputHandler = inputHandler;
        _converterMapperMapper = converterMapperMapper;
        _outputHandler = outputHandler;
    }

    /// <summary>
    /// Data conversion process
    /// </summary>
    /// <param name="inputFilePath">Path to the file with data to be converted</param>
    /// <param name="outputFilePath">Path to output file with converted data</param>
    public void Process(string inputFilePath, string outputFilePath)
    {
        var lines = _inputHandler.ReadInput(inputFilePath);
        var results = new List<string>();

        for (int i = 0; i < lines.Count; i++)
        {
            string converted = _converterMapperMapper.Convert(lines[i]);
            results.Add($"Case #{i + 1}: {converted}");
        }

        _outputHandler.WriteOutput(outputFilePath, results);
    }
}

