namespace Thunder.WebView.Messaging
{
    public class NoMatchingActionOnControllerFoundException : HandleMessageException
    {
        public NoMatchingActionOnControllerFoundException(Message message, IMessageController controller)
            : base($"While a matching controller was found, no method was found matching the message's action of '{message.Action}'.")
        {
        }
    }
}