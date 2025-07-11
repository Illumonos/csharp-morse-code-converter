using System.Text;
using static MorseCodeConverter.StringToMorseCode.StringToMorseCodeConverterFailure;

namespace MorseCodeConverter.StringToMorseCode;

internal static class StringToMorseCodeConverter
{
    private static readonly Dictionary<char, string> _alphabet = new()
    {
        ['A'] = ".-",
        ['B'] = "-...",
        ['C'] = "-.-.",
        ['D'] = "-..",
        ['E'] = ".",
        ['F'] = "..-.",
        ['G'] = "--.",
        ['H'] = "....",
        ['I'] = "..",
        ['J'] = ".---",
        ['K'] = "-.-",
        ['L'] = ".-..",
        ['M'] = "--",
        ['N'] = "-.",
        ['O'] = "---",
        ['P'] = ".--.",
        ['Q'] = "--.-",
        ['R'] = ".-.",
        ['S'] = "...",
        ['T'] = "-",
        ['U'] = "..-",
        ['V'] = "...-",
        ['W'] = ".--",
        ['X'] = "-..-",
        ['Y'] = "-.--",
        ['Z'] = "--..",
        ['0'] = "-----",
        ['1'] = ".----",
        ['2'] = "..---",
        ['3'] = "...--",
        ['4'] = "....-",
        ['5'] = ".....",
        ['6'] = "-....",
        ['7'] = "--...",
        ['8'] = "---..",
        ['9'] = "----."
    };
    
    private const char _morseCodeLetterSeparator = ' ';
    private const string _morseCodeWordSeparator = " / ";
    private const string _wordSeparator = " ";

    public static StringToMorseCodeConverterResult TryConvert(string? message)
    {
        if (message is null)
        {
            return new StringToMorseCodeConverterResult.Failure(IsNull);
        }
        
        if (message == string.Empty)
        {
            return new StringToMorseCodeConverterResult.Failure(IsEmpty);
        }
        
        if (string.IsNullOrWhiteSpace(message))
        {
            return new StringToMorseCodeConverterResult.Failure(IsWhitespace);
        }

        if (message.Trim().Length != message.Length)
        {
            return new StringToMorseCodeConverterResult.Failure(StartOrEndingSpaces);
        }
        
        string[] words = message.Split(_wordSeparator);
        if (words.Any(string.IsNullOrWhiteSpace))
        {
            return new StringToMorseCodeConverterResult.Failure(ExtraWhitespaceBetweenWords);
        }
        
        StringBuilder result = new();

        foreach (string word in words)
        {
            IList<string> morseCodeWord = new List<string>();
            
            foreach (char letter in word)
            {
                char normalisedLetter = char.ToUpperInvariant(letter);
                if (!_alphabet.TryGetValue(normalisedLetter, out var morseCodeCharacter))
                {
                    return new StringToMorseCodeConverterResult.Failure(InvalidCharacters);
                }

                morseCodeWord.Add(morseCodeCharacter);
            }

            result.Append(string.Join(_morseCodeLetterSeparator, morseCodeWord));

            if (word != words.Last())
            {
                result.Append(_morseCodeWordSeparator);
            }
        }
        
        return new StringToMorseCodeConverterResult.Success(result.ToString().TrimEnd());
    }
}