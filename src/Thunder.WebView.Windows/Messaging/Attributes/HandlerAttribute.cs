using System;

namespace Thunder.WebView.Windows
{
    public class HandlerAttribute : Attribute
    {
        public HandlerAttribute()
        {
        }
        public HandlerAttribute(String name)
        {
            this.Name = name;
        }

        public String Name { get; set; }
    }
}