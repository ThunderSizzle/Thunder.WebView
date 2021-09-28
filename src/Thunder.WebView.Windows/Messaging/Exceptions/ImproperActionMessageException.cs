namespace Thunder.WebView.Windows
{
    public class ImproperActionMessageException : HandleMessageException
    {
        public ImproperActionMessageException(Message message)
            : base($"The action '{message.Action}' of the message could not be parsed.")
        {
        }
    }
}