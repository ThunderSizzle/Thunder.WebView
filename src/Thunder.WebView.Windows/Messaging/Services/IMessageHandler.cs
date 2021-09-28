namespace Thunder.WebView.Windows
{
    public interface IMessageHandler
    {
        IMessageResult HandleMessage(Message message);
    }
}