using Google.Cloud.TextToSpeech.V1;
using System;
using System.IO;

namespace externalServices
{
    public class TextToSpeech : ITextToSpeech
    {
        public byte[] ConvertTextToSpeech(string inputText)
        {   
            TextToSpeechClient client = TextToSpeechClient.Create();

            // Set the text input to be synthesized.
            SynthesisInput input = new SynthesisInput
            {
                Text = inputText
            };

            // Build the voice request, select the language code ("en-US"),
            // and the SSML voice gender ("neutral").
            VoiceSelectionParams voice = new VoiceSelectionParams
            {
                LanguageCode = "en-AU",
                SsmlGender = SsmlVoiceGender.Female
            };

            // Select the type of audio file you want returned.
            AudioConfig config = new AudioConfig
            {
                AudioEncoding = AudioEncoding.Mp3
            };

            // Perform the Text-to-Speech request, passing the text input
            // with the selected voice parameters and audio file type
            var response = client.SynthesizeSpeech(new SynthesizeSpeechRequest
            {
                Input = input,
                Voice = voice,
                AudioConfig = config
            });

            // Write the binary AudioContent of the response to an  stream.
            using (var output = new MemoryStream())
            {
                response.AudioContent.WriteTo(output);
                return output.ToArray();
            }
        }
    }
}
