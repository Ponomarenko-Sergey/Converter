using Converter.Core.Interfaces;
using System.Text;

namespace Converter.Core.Components;

/// <summary>
/// Class for working with convertible mapping
/// </summary>
public class ConverterMapper : IConverterMapper
{
    private readonly Dictionary<char, string> _mapping;

    /// <summary>
    /// Constructor for default character matching (en) 
    /// </summary>
    public ConverterMapper()
    {
        _mapping = new Dictionary<char, string>
        {
            { 'a', "2" }, { 'b', "22" }, { 'c', "222" },
            { 'd', "3" }, { 'e', "33" }, { 'f', "333" },
            { 'g', "4" }, { 'h', "44" }, { 'i', "444" },
            { 'j', "5" }, { 'k', "55" }, { 'l', "555" },
            { 'm', "6" }, { 'n', "66" }, { 'o', "666" },
            { 'p', "7" }, { 'q', "77" }, { 'r', "777" }, { 's', "7777" },
            { 't', "8" }, { 'u', "88" }, { 'v', "888" },
            { 'w', "9" }, { 'x', "99" }, { 'y', "999" }, { 'z', "9999" },
            { ' ', "0" }
        };
    }

    /// <summary>
    /// Constructor for matching characters from a dictionary 
    /// </summary>
    /// <param name="mapping">Dictionary for character matching</param>
    public ConverterMapper(Dictionary<char, string> mapping) => _mapping = mapping;

    /// <summary>
    /// Convert input string to T9 combination
    /// </summary>
    /// <param name="inputString">Input text string</param>
    /// <returns>Converted to T9 string</returns>
    /// <exception cref="ArgumentException">When the input string contains invalid characters</exception>
    public string Convert(string inputString)
    {
        var convertedString = new StringBuilder();
        char? prevСharacter = null;
        char? prevKey = null;

        foreach (var character in inputString)
        {
            if (!_mapping.ContainsKey(character))
            {
                throw new ArgumentException($"Invalid character: {character}");
            }

            string currentKey = _mapping[character];

            // If character from input string equals previous character 
            // or a character from the mapping group has been converted
            if (prevСharacter != null &&
                (character == prevСharacter.Value || currentKey[0] == prevKey.Value))
            {
                convertedString.Append(" ");
            }

            convertedString.Append(currentKey);
            prevСharacter = character;
            prevKey = currentKey[0];
        }

        return convertedString.ToString();
    }
}

