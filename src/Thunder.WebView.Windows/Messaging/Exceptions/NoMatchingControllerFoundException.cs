namespace Thunder.WebView.Windows
{
    public class NoMatchingControllerFoundException : HandleMessageException
    {
        public NoMatchingControllerFoundException(Message message)
            : base($"No message handler matches the message's action of '{message.Action}'.")
        {
        }
    }
}