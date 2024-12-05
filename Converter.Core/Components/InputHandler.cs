using Converter.Core.Interfaces;

namespace Converter.Core.Components;

/// <summary>
/// Class for working with the input 
/// </summary>
public class InputHandler : IInputHandler
{
    /// <summary>
    /// Reading data from a file
    /// </summary>
    /// <param name="filePath">File path to read</param>
    /// <returns>List of read string lines</returns>
    /// <exception cref="FileNotFoundException">File is not found by filepath</exception>
    /// <exception cref="InvalidOperationException">There are less then two lines in rerading file</exception>
    /// <exception cref="ArgumentException">First line isn't a digit</exception>
    public List<string> ReadInput(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("File not found");
        }

        var lines = File.ReadAllLines(filePath).ToList();

        if (lines.Count < 2)
        {
            throw new InvalidOperationException("Invalid input format");
        }

        int linesCount;
        if (!int.TryParse(lines[0], out linesCount))
        {
            throw new ArgumentException("First line must be digit");
        }

        if (linesCount < 1 || linesCount > 100)
        {
            throw new ArgumentException("Line count must be between 1 and 100");
        }

        return lines.Skip(1).Take(linesCount).ToList();
    }
}
