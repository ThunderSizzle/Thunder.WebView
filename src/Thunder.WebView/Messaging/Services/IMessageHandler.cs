namespace Thunder.WebView.Messaging
{
    public interface IMessageHandler
    {
        IMessageResult HandleMessage(Message message);
    }
}