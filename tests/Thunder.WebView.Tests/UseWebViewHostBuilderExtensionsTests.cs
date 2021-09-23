using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thunder.WebView.Blazor;
using Thunder.WebView.Windows;

namespace Thunder.WebView.Tests
{
    public class UseWebViewHostBuilderExtensionsTests
    {
        [Test]
        public async Task UseWebView_Verify()
        {
            await Host.CreateDefaultBuilder()
               .UseWebView<TestStartup>( builder => builder
                    .UseBlazor()
                    .UseSSL(true)
                    .UseWindowsForms())
               .Build()
               .RunAsync();
        }
    }
}
