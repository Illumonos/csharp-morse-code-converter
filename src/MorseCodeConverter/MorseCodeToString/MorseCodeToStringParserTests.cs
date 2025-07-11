using static MorseCodeConverter.MorseCodeToString.MorseCodeToStringParseFailure;

namespace MorseCodeConverter.MorseCodeToString;

public sealed class MorseCodeToStringParserTests
{
    [Theory]
    [MemberData(nameof(MorseCodeToStringParserTestCases.ValidMorseCodeData), MemberType = typeof(MorseCodeToStringParserTestCases))]
    public void For_MorseCodeToStringParser_When_TryParse_With_Valid_MorseCode_Then_Return_Expected_Message(string morseCode, string expectedMessage)
    {
        MorseCodeToStringParseResult.Success expectedResult = new(expectedMessage);
        MorseCodeToStringParseResult actualResult = MorseCodeToStringParser.TryParse(morseCode);
        Assert.Equal(expectedResult, actualResult);
    }

    [Theory]
    [MemberData(nameof(MorseCodeToStringParserTestCases.InvalidMorseCodeData), MemberType = typeof(MorseCodeToStringParserTestCases))]
    public void For_MorseCodeToStringParser_When_TryParse_With_Invalid_MorseCode_Then_Return_Error_Message(string? morseCode, string expectedErrorMessage)
    {
        MorseCodeToStringParseResult.Failure expectedResult = new(expectedErrorMessage);
        MorseCodeToStringParseResult actualResult = MorseCodeToStringParser.TryParse(morseCode);
        Assert.Equal(expectedResult, actualResult);
    }
    
    private static class MorseCodeToStringParserTestCases
    {
        public static readonly TheoryData<string, string> ValidMorseCodeData = new()
        {
            { ".-", "A" },
            { ".- / -... / -.-. / -..", "A B C D" },
            { ".... . .-.. .-.. --- / .-- --- .-. .-.. -..", "HELLO WORLD" },
            { "- .... . .-. . / .. ... / -. --- / ... .--. --- --- -.", "THERE IS NO SPOON" }
        };

        public static readonly TheoryData<string?, string> InvalidMorseCodeData = new()
        {
            { null, IsNull },
            { InvalidMorseCode.Empty, IsEmpty },
            { InvalidMorseCode.WhitespaceOnly, IsWhitespace },
            { InvalidMorseCode.WhitespacePrefix, StartOrEndingSpaces },
            { InvalidMorseCode.WhitespaceSuffix, StartOrEndingSpaces },
            { InvalidMorseCode.WhitespaceBothSides, StartOrEndingSpaces },
            { InvalidMorseCode.WhitespaceInBetweenWords, InvalidSpacingBetweenWordsOrLetters },
            { InvalidMorseCode.WhitespaceInBetweenLetters, InvalidSpacingBetweenWordsOrLetters },
            { InvalidMorseCode.InvalidAlphaCharacter, InvalidMorseCodeCharacter },
            { InvalidMorseCode.InvalidNumberCharacter, InvalidMorseCodeCharacter },
            { InvalidMorseCode.InvalidSpecialCharacter, InvalidMorseCodeCharacter }
        };
    }
}