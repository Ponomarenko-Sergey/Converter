using Converter.Core.Interfaces;

namespace Converter.Core.Components;

/// <summary>
/// Class for working with the output 
/// </summary>
public class OutputHandler : IOutputHandler
{
    /// <summary>
    /// Write result in file
    /// </summary>
    /// <param name="filePath">File path to write</param>
    /// <param name="lines">List strings to write</param>
    /// <returns>True - file is written, False - file is not written</returns>
    public bool WriteOutput(string filePath, List<string> lines)
    {
        if (!string.IsNullOrEmpty(filePath))
        {
            File.WriteAllLines(filePath, lines);
            return true;
        }
        return false;
    }
}
