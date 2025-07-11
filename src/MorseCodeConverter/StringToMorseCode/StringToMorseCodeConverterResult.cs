using Dunet;

namespace MorseCodeConverter.StringToMorseCode;

[Union]
internal partial record StringToMorseCodeConverterResult
{
    public partial record Success(string message);

    public partial record Failure(string errorMessage);
}