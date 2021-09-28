using System;

namespace Thunder.WebView.Windows
{
    public class Message
    {
        public Message()
        {
        }

        public Message(String action, dynamic data)
        {
            this.Action = action;
            this.MessageId = Guid.NewGuid().ToString();
            if (data != null)
            {
                this.Data = data;
                this.DataType = data.GetType().Name;
            }
        }

        public Message(String messageId, String action, dynamic data)
        {
            this.Action = action;
            this.MessageId = messageId;

            if (data != null)
            {
                this.Data = data;
                this.DataType = data.GetType().Name;
            }
        }

        public String Action { get; set; }

        public dynamic Data { get; set; }

        public String MessageId { get; set; }
        public String DataType { get; set; }

        public T GetData<T>()
        {
            return ((JsonElement)this.Data).ToObject<T>();
        }

        internal Message CreateResponse(dynamic data)
        {
            return new Message(this.MessageId, this.Action, data);
        }
    }
}