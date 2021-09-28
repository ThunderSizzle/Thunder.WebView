using System;

namespace Thunder.WebView.Messaging
{
    public interface IMessagingWebView
    {
        void SendMessage(String json);
    }
}