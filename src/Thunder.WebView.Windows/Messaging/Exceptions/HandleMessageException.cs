using System;

namespace Thunder.WebView.Windows
{
    public class HandleMessageException : Exception
    {
        public HandleMessageException(String message)
             : base(message)
        {
        }
    }
}