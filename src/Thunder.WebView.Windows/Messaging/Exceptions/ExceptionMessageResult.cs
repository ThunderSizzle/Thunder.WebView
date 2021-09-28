using System;

namespace Thunder.WebView.Windows
{
    public class ExceptionMessageResult : ResponseMessageResult
    {
        public ExceptionMessageResult(Exception exception) : base(new ErrorMessageData(exception))
        {
        }
    }
}