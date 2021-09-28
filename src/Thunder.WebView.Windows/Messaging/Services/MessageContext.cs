namespace Thunder.WebView.Windows
{
    public class MessageContext
    {
        public MessageContext(Diga.WebView2.WinForms.WebView webView, Message request)
        {
            this.WebView = webView;
            this.Request = request;
        }

        public Message Request { get; }
        public Diga.WebView2.WinForms.WebView WebView { get; }
    }
}