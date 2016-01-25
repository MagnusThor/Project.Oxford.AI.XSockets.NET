using System.Linq;
using XSockets.Core.XSocket;
using XSockets.Core.XSocket.Helpers;
using XSockets.Core.Common.Socket.Event.Interface;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Emotion;

namespace WebRTC.MS.Emotion.API.RTC
{
    public class Emotion : XSocketController
    {
        private const string subscriptionKey = "yourapikey";
        // replace with your API key - see https://dev.projectoxford.ai/ 

        private static EmotionServiceClient emotionServiceClient;

        static Emotion()
        {
            // Create a EmotionServiceClient shared among all instances/clients connected
            // to the EmotionController
            emotionServiceClient = new EmotionServiceClient(subscriptionKey);
        }

        public async Task DetectEmotion(IMessage message)
        {
            using (var ms = new System.IO.MemoryStream(message.Blob.ToArray()))
            {
                var emotionResult = await emotionServiceClient.RecognizeAsync(ms);
                await this.Invoke(emotionResult, "emotionDetected");
                // If you wanna share the "blob" and the "current" emotion captured, just 
                // change from Invoke to InvokeToAll ..
                //  You may also wanna pass the Image recognized, just pass a new message 
                // containing the Blob or pass the IMessage :-)   This is f****g awesome
            }

        }

        public override async Task OnMessage(IMessage message)
        {
            await this.InvokeToAll(message);
        }
    }
}
