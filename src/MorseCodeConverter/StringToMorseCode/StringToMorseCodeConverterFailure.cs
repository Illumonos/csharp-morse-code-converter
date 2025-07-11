namespace MorseCodeConverter.StringToMorseCode;

internal static class StringToMorseCodeConverterFailure
{
    public const string ExtraWhitespaceBetweenWords = "Message contains extra whitespace between words";
    public const string InvalidCharacters = "Message contains invalid characters";
    public const string IsEmpty = "Message cannot be empty";
    public const string IsNull = "Message cannot be null";
    public const string IsWhitespace = "Message cannot be whitespace";
    public const string StartOrEndingSpaces = "Message cannot start or end with spaces";
}