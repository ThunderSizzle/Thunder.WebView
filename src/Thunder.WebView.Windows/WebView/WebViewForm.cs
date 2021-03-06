using Diga.WebView2.Wrapper.EventArguments;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Text.Json;
using System.Windows.Forms;
using Thunder.WebView.Messaging;
using Message = Thunder.WebView.Messaging.Message;

namespace Thunder.WebView.Windows
{
    public partial class WebViewForm : Form, IMessagingWebView
    {
        private readonly WebViewOptions _options;
        private readonly Diga.WebView2.WinForms.WebView _webView1;
        private readonly IServiceProvider _serviceProvider;

        public WebViewForm(IOptions<WebViewOptions> options, IServiceProvider serviceProvider)
        {
            _options = options?.Value;
            InitializeComponent();

            _webView1 = new Diga.WebView2.WinForms.WebView();
            SetupWebView();

            _webView1.Url = _options?.StartingUrl;
            this.AddBrowserControl(_webView1);
            toolStrip1.Visible = _options.ShowDevUi;
            _serviceProvider = serviceProvider;
        }

        private void SetupWebView()
        {
            // 
            // webView1
            // 
            _webView1.BackColor = System.Drawing.Color.Black;
            _webView1.DefaultContextMenusEnabled = true;
            _webView1.DefaultScriptDialogsEnabled = true;
            _webView1.DevToolsEnabled = true;
            _webView1.Dock = System.Windows.Forms.DockStyle.Fill;
            _webView1.EnableMonitoring = true;
            _webView1.HtmlContent = null;
            _webView1.IsCreated = false;
            _webView1.IsScriptEnabled = true;
            _webView1.IsStatusBarEnabled = true;
            _webView1.IsWebMessageEnabled = true;
            _webView1.IsZoomControlEnabled = true;
            _webView1.Location = new System.Drawing.Point(0, 24);
            _webView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _webView1.MonitoringFolder = ".\\wwwroot";
            _webView1.MonitoringUrl = "https://5b834d57-0891-4730-b6ba-c793b4e76468/";
            _webView1.Name = "webView1";
            _webView1.RemoteObjectsAllowed = true;
            _webView1.Size = new System.Drawing.Size(941, 530);
            _webView1.TabIndex = 0;
            _webView1.Url = null;
            _webView1.WebMessageReceived += this.webView1_WebMessageReceived;
        }

        private void webView1_WebMessageReceived(object sender, WebMessageReceivedEventArgs e)
        {
            var message = this.ReadMessage(e);
            this.HandleMessage(message);
        }

        private void HandleMessage(Message message)
        {
            IMessageResult result;
            var context = new MessageContext(this, message);
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var handler = scope.ServiceProvider.GetService<IMessageHandler>();
                    result = handler.HandleMessage(message);
                }
            }
            catch (Exception ex)
            {
                result = new ExceptionMessageResult(ex);
            }
            result.ExecuteResult(context);
        }

        private Message ReadMessage(WebMessageReceivedEventArgs e)
        {
            return JsonSerializer.Deserialize<Message>(e.WebMessageAsJson, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        }

        private void AddBrowserControl<T>(T browser)
            where T : Control
        {
            toolStripContainer.ContentPanel.Controls.Add(browser);
        }

        private void HandleToolStripLayout()
        {
            var width = toolStrip1.Width;
            foreach (ToolStripItem item in toolStrip1.Items)
            {
                if (item != urlTextBox)
                {
                    width -= item.Width - item.Margin.Horizontal;
                }
            }
            urlTextBox.Width = Math.Max(0, width - urlTextBox.Margin.Horizontal - 18);
        }
        private void HandleToolStripLayout(object sender, LayoutEventArgs e)
        {
            HandleToolStripLayout();
        }
        private void ExitMenuItemClick(object sender, EventArgs e)
        {
            throw new NotSupportedException();
        }

        public void SendMessage(string json)
        {
            _webView1.SendMessage(json);
        }
    }
}
