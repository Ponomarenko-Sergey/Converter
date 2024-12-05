namespace Converter.Core.Interfaces;

public interface IOutputHandler
{
    bool WriteOutput(string filePath, List<string> cases);
}
