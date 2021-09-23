using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thunder.WebView.Tests
{
    public class UseWebViewHostBuilderExtensionsTests
    {
        [Test]
        public async Task UseWebView_Verify()
        {
            await Host.CreateDefaultBuilder()
               .UseWebView<TestStartup>()
               .Build()
               .RunAsync();
        }
    }
}
