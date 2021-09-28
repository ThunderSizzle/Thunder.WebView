using System.Text.Json;

namespace Thunder.WebView.Windows
{
    public class ResponseMessageResult : IMessageResult
    {
        private readonly dynamic _responseMessageData;

        public ResponseMessageResult(dynamic data)
        {
            _responseMessageData = data;
        }

        public virtual void ExecuteResult(MessageContext messageContext)
        {
            var response = messageContext.Request.CreateResponse(_responseMessageData);
            var json = JsonSerializer.Serialize(response, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            messageContext.WebView.SendMessage(json);
        }
    }
}