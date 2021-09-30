using System;

namespace Thunder.WebView.Messaging
{
    public class ExceptionMessageResult : ResponseMessageResult
    {
        public ExceptionMessageResult(Exception exception) : base(new ErrorMessageData(exception))
        {
        }
    }
}