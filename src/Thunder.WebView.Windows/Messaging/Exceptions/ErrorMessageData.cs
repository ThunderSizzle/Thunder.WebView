using System;

namespace Thunder.WebView.Windows
{
    public class ErrorMessageData
    {
        public ErrorMessageData()
        {
        }

        public ErrorMessageData(Exception ex)
        {
            this.StackTrace = ex.StackTrace;
            this.Source = ex.Source;
            this.Message = ex.Message;
            this.InnerError = ex.InnerException != null ? new ErrorMessageData(ex.InnerException) : null;
        }

        public string StackTrace { get; set; }
        public string Source { get; set; }
        public string Message { get; set; }
        public ErrorMessageData InnerError { get; set; }
    }
}