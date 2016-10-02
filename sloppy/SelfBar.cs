using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.Text.RegularExpressions;

namespace sloppy
{
    public partial class SelfBar : Form
    {
        // ドラッグ中のマウス位置
        private Point mousePoint;

        public static ChromiumWebBrowser chromeBrowser;
        public static SelfBar meInstance;

        public SelfBar()
        {
            InitializeComponent();
            InitializeChromium();
        }

        private void SideBar_Load(object sender, EventArgs e)
        {
            chromeBrowser = new ChromiumWebBrowser(Application.StartupPath + "\\htmls\\self.html");
            chromeBrowser.Dock = DockStyle.Fill;
            chromeBrowser.Name = "chromeBrowser";
            chromeBrowser.RequestHandler = new MyRequestHandler();
            panel1.Controls.Add(chromeBrowser);
            Size = new Size(400, 780);
            chromeBrowser.MouseDown += new MouseEventHandler(SelfBar_MouseDown);
            chromeBrowser.MouseMove += new MouseEventHandler(SelfBar_MouseMove);
            meInstance = this;
        }

        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);
        }

        private void SideBar_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }

        public void htmlReadComplete(object requestObject)
        {
            string script =@"$('.btn-success').hide();";
            chromeBrowser.ExecuteScriptAsync(script);

        }
        private void button2_Click(object sender, EventArgs e)
        {
            /*            var script = "$('#timer2').click();";
                        chromeBrowser.ExecuteScriptAsync(script);*/

        }

        /* self.htmlの読み込み*/
        public static void htmlLoadCompleteAction(IRequest request)
        {

        }

        class MyRequestHandler : IRequestHandler
        {
            // 必要なファイル
            static string[] requiredFiles = { "self.html", "jquery-2.1.4.min.js"};
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
                foreach (string fileName in requiredFiles) {
                    if (request.Url.EndsWith(fileName))
                    {
                        readRequiredFileCount++;
                    }
                }
                if(requiredFiles.Length <= readRequiredFileCount)
                {
                    SelfBar.htmlLoadCompleteAction(request);
                    readRequiredFileCount = 0;
                }
                
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"[^0-9]");
            int inputInt;
            if (int.TryParse(regex.Replace(textBox1.Text, ""), out inputInt) == false) return;

            int allSec;
            allSec = ((inputInt - inputInt % 100) / 100 * 60) + inputInt % 100;

            string script = 
                @"
                $('#timeInput').val(" + allSec + @");
                $('#alltime-reset').click();
                $('#alltime-starstop').click();
                $('.btn-success').hide();
                ";

            chromeBrowser.ExecuteScriptAsync(script);
            EnemyBar.chromeBrowser.ExecuteScriptAsync(script);
        }


        // フォームマウスダウン
        private void SelfBar_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
                mousePoint = new Point(e.X, e.Y);
        }

        private void chromeBrowser_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
                mousePoint = new Point(e.X, e.Y);
        }

        // フォームマウスムーブ
        private void SelfBar_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
                Location = new Point(Location.X + e.X - mousePoint.X, Location.Y + e.Y - mousePoint.Y);
        }
        private void chromeBrowser_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
                Location = new Point(Location.X + e.X - mousePoint.X, Location.Y + e.Y - mousePoint.Y);
        }

        private void SelfBar_LocationChanged(object sender, EventArgs e)
        {
            int Y = Location.Y;
            if (EnemyBar.meInstance == null) return;
            try
            {
                EnemyBar.meInstance.Location = new Point(EnemyBar.meInstance.Location.X, Y);
            }
            catch
            {
                return;
            }
        }
    }


}
