namespace MorseCodeConverter.MorseCodeToString;

internal static class InvalidMorseCode
{
    public const string Empty = "";
    public const string InvalidNumberCharacter = ".1";
    public const string InvalidAlphaCharacter = "... a";
    public const string InvalidSpecialCharacter = "..;.";
    public const string WhitespaceBothSides = " .... ";
    public const string WhitespaceInBetweenLetters = ".  .";
    public const string WhitespaceInBetweenWords = "....  /  ....";
    public const string WhitespacePrefix = " ....";
    public const string WhitespaceSuffix = ".... ";
    public const string WhitespaceOnly = "    ";
}