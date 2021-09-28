namespace Thunder.WebView.Windows
{
    internal class ParsedAction
    {
        public string Key { get; set; }
        public string Method { get; set; }
        public Message Message { get; internal set; }
    }
}