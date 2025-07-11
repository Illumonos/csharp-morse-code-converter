namespace MorseCodeConverter.MorseCodeToString;

internal static class MorseCodeToStringParseFailure
{
    public const string InvalidMorseCodeCharacter = "Invalid morse code character";
    public const string InvalidSpacingBetweenWordsOrLetters = "Spacing between words or letters is invalid";
    public const string IsEmpty = "Morse code cannot be empty";
    public const string IsNull = "Morse code cannot be null";
    public const string StartOrEndingSpaces = "Morse code cannot start or end with spaces";
    public const string IsWhitespace = "Morse code cannot be whitespace";
}