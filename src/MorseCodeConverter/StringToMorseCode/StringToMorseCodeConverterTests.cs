using static MorseCodeConverter.StringToMorseCode.StringToMorseCodeConverterFailure;

namespace MorseCodeConverter.StringToMorseCode;

public sealed class StringToMorseCodeConverterTests
{
    [Theory]
    [MemberData(nameof(StringToMorseCodeTestCases.ValidMessages), MemberType = typeof(StringToMorseCodeTestCases))]
    public void For_StringToMorseCodeConverter_When_TryConvert_With_Valid_MorseCode_Then_Return_Expected_Message(string message, string expectedMessage)
    {
        StringToMorseCodeConverterResult.Success expectedResult = new(expectedMessage);
        StringToMorseCodeConverterResult actualResult = StringToMorseCodeConverter.TryConvert(message);
        Assert.Equal(expectedResult, actualResult);
    }

    [Theory]
    [MemberData(nameof(StringToMorseCodeTestCases.InvalidMessages), MemberType = typeof(StringToMorseCodeTestCases))]
    public void For_StringToMorseCodeConverter_When_TryConvert_With_Invalid_MorseCode_Then_Return_Error_Message(string? message, string expectedErrorMessage)
    {
        StringToMorseCodeConverterResult.Failure expectedResult = new(expectedErrorMessage);
        StringToMorseCodeConverterResult actualResult = StringToMorseCodeConverter.TryConvert(message);
        Assert.Equal(expectedResult, actualResult);
    }
    
    private static class StringToMorseCodeTestCases
    {
        public static readonly TheoryData<string, string> ValidMessages = new()
        {
            { "A", ".-" },
            { "A B C D", ".- / -... / -.-. / -.." },
            { "HELLO WORLD", ".... . .-.. .-.. --- / .-- --- .-. .-.. -.." },
            { "THERE IS NO SPOON", "- .... . .-. . / .. ... / -. --- / ... .--. --- --- -." }
        };

        public static readonly TheoryData<string?, string> InvalidMessages = new()
        {
            { null, IsNull },
            { InvalidMessage.ExtraWhitespaceInBetweenWords, ExtraWhitespaceBetweenWords },
            { InvalidMessage.Empty, IsEmpty },
            { InvalidMessage.InvalidCharacters, InvalidCharacters },
            { InvalidMessage.WhitespaceOnly, IsWhitespace },
            { InvalidMessage.WhitespacePrefix, StartOrEndingSpaces },
            { InvalidMessage.WhitespaceSuffix, StartOrEndingSpaces },
            { InvalidMessage.WhitespaceBothSides, StartOrEndingSpaces }
        };
    }
}