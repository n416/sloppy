using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sloppy
{
    public partial class EnemyBar : Form
    {
        public static ChromiumWebBrowser chromeBrowser;
        public static EnemyBar meInstance;

        public EnemyBar()
        {
            InitializeComponent();
            InitializeChromium();

        }

        private void EnemyBar_Load(object sender, EventArgs e)
        {

            chromeBrowser = new ChromiumWebBrowser(Application.StartupPath + "\\htmls\\enemy.html");

            chromeBrowser.Dock = DockStyle.Fill;
            chromeBrowser.Name = "chromeBrowser";
            chromeBrowser.RequestHandler = new MyRequestHandler();
            panel1.Controls.Add(chromeBrowser);
            Size = new Size(400, 780);
            meInstance = this;
        }

        public void InitializeChromium()
        {
/*            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);*/
        }

        private void EnemyBar_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();

        }
        public static void htmlLoadCompleteAction(object requestObject)
        {
            string script = @"$('.btn-success').hide();";
            chromeBrowser.ExecuteScriptAsync(script);
        }

        class MyRequestHandler : IRequestHandler
        {
            // 必要なファイル
            static string[] requiredFiles = { "self.html", "jquery-2.1.4.min.js" };
            static int readRequiredFileCount = 0;

            /* IRequestHandlerがインターフェイスとして定義しているメソッド群を実装しないと生成できないのでほとんどがFlaseとかNullとかばかりを返すメソッドだけど実装しておく */
            CefReturnValue IRequestHandler.OnBeforeResourceLoad(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IRequestCallback callback) { return CefReturnValue.Continue; }
            IResponseFilter IRequestHandler.GetResourceResponseFilter(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response) { return null; }
            bool IRequestHandler.OnBeforeBrowse(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, bool isRedirect) { return false; }
            bool IRequestHandler.OnOpenUrlFromTab(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, WindowOpenDisposition targetDisposition, bool userGesture) { return false; }
            bool IRequestHandler.OnCertificateError(IWebBrowser browserControl, IBrowser browser, CefErrorCode errorCode, string requestUrl, ISslInfo sslInfo, IRequestCallback callback) { return false; }
            void IRequestHandler.OnPluginCrashed(IWebBrowser browserControl, IBrowser browser, string pluginPath) { }
            bool IRequestHandler.GetAuthCredentials(IWebBrowser browserControl, IBrowser browser, IFrame frame, bool isProxy, string host, int port, string realm, string scheme, IAuthCallback callback) { callback.Dispose(); return false; }
            void IRequestHandler.OnRenderProcessTerminated(IWebBrowser browserControl, IBrowser browser, CefTerminationStatus status) { }
            bool IRequestHandler.OnQuotaRequest(IWebBrowser browserControl, IBrowser browser, string originUrl, long newSize, IRequestCallback callback) { return false; }
            void IRequestHandler.OnResourceRedirect(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, ref string newUrl) { }
            bool IRequestHandler.OnProtocolExecution(IWebBrowser browserControl, IBrowser browser, string url) { return false; }
            void IRequestHandler.OnRenderViewReady(IWebBrowser browserControl, IBrowser browser) { }
            bool IRequestHandler.OnResourceResponse(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response) { return false; }
            /* httpアクセスが終了した時に来るイベント */
            void IRequestHandler.OnResourceLoadComplete(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response, UrlRequestStatus status, long receivedContentLength)
            {
                foreach (string fileName in requiredFiles)
                {
                    if (request.Url.EndsWith(fileName))
                    {
                        readRequiredFileCount++;
                    }
                }
                if (requiredFiles.Length <= readRequiredFileCount)
                {
                    EnemyBar.htmlLoadCompleteAction(request);
                    readRequiredFileCount = 0;
                }
            }
        }

    }
}
