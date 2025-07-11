using System.Text;
using static MorseCodeConverter.MorseCodeToString.MorseCodeToStringParseFailure;

namespace MorseCodeConverter.MorseCodeToString;

internal static class MorseCodeToStringParser
{
    private static readonly Dictionary<string, char> _alphabet = new()
    {
        [".-"]    = 'A',
        ["-..."]  = 'B',
        ["-.-."]  = 'C',
        ["-.."]   = 'D',
        ["."]     = 'E',
        ["..-."]  = 'F',
        ["--."]   = 'G',
        ["...."]  = 'H',
        [".."]    = 'I',
        [".---"]  = 'J',
        ["-.-"]   = 'K',
        [".-.."]  = 'L',
        ["--"]    = 'M',
        ["-."]    = 'N',
        ["---"]   = 'O',
        [".--."]  = 'P',
        ["--.-"]  = 'Q',
        [".-."]   = 'R',
        ["..."]   = 'S',
        ["-"]     = 'T',
        ["..-"]   = 'U',
        ["...-"]  = 'V',
        [".--"]   = 'W',
        ["-..-"]  = 'X',
        ["-.--"]  = 'Y',
        ["--.."]  = 'Z',
        ["-----"] = '0',
        [".----"] = '1',
        ["..---"] = '2',
        ["...--"] = '3',
        ["....-"] = '4',
        ["....."] = '5',
        ["-...."] = '6',
        ["--..."] = '7',
        ["---.."] = '8',
        ["----."] = '9'
    };
    
    private const char _letterSeparator = ' ';
    private const string _wordSeparator = " / ";

    public static MorseCodeToStringParseResult TryParse(string? morseCode)
    {
        if (morseCode is null)
        {
            return new MorseCodeToStringParseResult.Failure(IsNull);
        }
        
        if (morseCode == string.Empty)
        {
            return new MorseCodeToStringParseResult.Failure(IsEmpty);
        }
        
        if (string.IsNullOrWhiteSpace(morseCode))
        {
            return new MorseCodeToStringParseResult.Failure(IsWhitespace);
        }

        if (morseCode.Trim().Length != morseCode.Length)
        {
            return new MorseCodeToStringParseResult.Failure(StartOrEndingSpaces);
        }
        
        string[] words = morseCode.Split(_wordSeparator);
        StringBuilder result = new();
        
        foreach (string word in words)
        {
            string[] letters = word.Split(_letterSeparator);
            if (letters.Any(string.IsNullOrWhiteSpace))
            {
                return new MorseCodeToStringParseResult.Failure(InvalidSpacingBetweenWordsOrLetters);
            }
            
            foreach (string letter in letters)
            {
                if (_alphabet.TryGetValue(letter, out char character))
                {
                    result.Append(character);
                }
                else
                {
                    return new MorseCodeToStringParseResult.Failure(InvalidMorseCodeCharacter);
                }
            }

            result.Append(_letterSeparator);
        }

        return new MorseCodeToStringParseResult.Success(result.ToString().TrimEnd());
    }
}