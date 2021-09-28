namespace Thunder.WebView.Messaging
{
    public class MessageContext
    {
        public MessageContext(IMessagingWebView webView, Message request)
        {
            this.WebView = webView;
            this.Request = request;
        }

        public Message Request { get; }
        public IMessagingWebView WebView { get; }
    }
}