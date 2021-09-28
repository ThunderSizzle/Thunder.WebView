using System;

namespace Thunder.WebView.Messaging
{
    public class HandleMessageException : Exception
    {
        public HandleMessageException(String message)
             : base(message)
        {
        }
    }
}