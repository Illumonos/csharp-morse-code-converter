using Dunet;

namespace MorseCodeConverter.MorseCodeToString;

[Union]
internal partial record MorseCodeToStringParseResult
{
    public partial record Success(string message);

    public partial record Failure(string errorMessage);
}