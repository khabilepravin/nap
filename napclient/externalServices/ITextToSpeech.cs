namespace externalServices
{
    public interface ITextToSpeech
    {
        byte[] ConvertTextToSpeech(string inputText);
    }
}
