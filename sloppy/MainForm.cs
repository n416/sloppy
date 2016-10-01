using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Web;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using CefSharp;

namespace sloppy
{
    //フォームクラス
    public partial class MainForm : Form
    {
        // ドラッグ中のマウス位置
        private Point mousePoint;

        // 表示のリフレッシュフラグ
        private Boolean refleshFlag = false;
        public Boolean RefleshFlag
        {
            set { refleshFlag = value; }
            get { return refleshFlag; }
        }

        // 処理済みのファイルサイズ
        private long processedLogFileSize;

        // 処理済みのファイルパス
        private String processedLogFilePath;

        // 発言者の最大文字長
        private int maxOwnerLength;

        // 中国語固有名詞→日本語固有名詞 変換リスト
        private SortedList<String, String> specialWordList = new SortedList<String, String>();

        // 中国語固有名詞→日本語固有名詞 変換リストの中国語固有名詞の文字長で降順で並び替えたリスト
        private List<KeyValuePair<string, string>> specialWordListOfKeyDescSort;

        // フォームコンストラクタ
        public MainForm()
        {
            InitializeComponent();
            // XMLファイルから設定を読み込む
            Settings.LoadFromXmlFile();
            // 発言者の最大文字長
            maxOwnerLength = 0;

            // 中国語固有名詞→日本語固有名詞 変換リストをセット
            specialWordList = CSVParser.getList(Application.StartupPath + "\\filter.tsv");

            // 中国語固有名詞→日本語固有名詞 変換リストをコピーして、List<KeyValuePair<string, string>>の形に変換
            specialWordListOfKeyDescSort = new List<KeyValuePair<string, string>>(specialWordList);
            // 文字長で降順ソート
            specialWordListOfKeyDescSort.Sort(CompareKeyLengthDesc);

        }

        // フォームロード
        private void MainForm_Load(object sender, EventArgs e)
        {
            // 最前面オプションをＯＮにする
            TopMost               = true;
            // サイズを設定
            Size                  = Settings.Instance.FormSize;
            // 位置を設定
            Location              = Settings.Instance.FormLocation;
            // 翻訳表示テキストボックスの上位置をメニューの高さに設定
            dumpTextBox.Top       = menuStrip.Height;
            // 翻訳表示テキストボックスのフォントを設定
            dumpTextBox.Font      = new Font(Settings.Instance.DumpTextBoxFontName, Settings.Instance.DumpTextBoxFontSize);
            // 翻訳表示テキストボックスのフォント色を設定
            dumpTextBox.ForeColor = Settings.Instance.DumpTextBoxForeColor;
            // 翻訳表示テキストボックスの背景色を設定
            dumpTextBox.BackColor = Settings.Instance.DumpTextBoxBackColor;
            // 翻訳表示テキストボックスにマウスダウンイベントを追加
            dumpTextBox.MouseDown += new MouseEventHandler(MainForm_MouseDown);
            // 翻訳表示テキストボックスにマウスムーブイベントを追加
            dumpTextBox.MouseMove += new MouseEventHandler(MainForm_MouseMove);

            SelfBar f1 = new SelfBar();
            f1.Show();
            // 位置を設定
            SelfBar.meInstance.Location = Settings.Instance.selfBarLocation;

            EnemyBar f2 = new EnemyBar();
            f2.Show();
            // 位置を設定
            EnemyBar.meInstance.Location = Settings.Instance.enemyBarLocation;
        }

        // フォームアクティブ
        private void MainForm_Activated(object sender, EventArgs e)
        {
            // 翻訳表示テキストボックスのフォントを設定
            dumpTextBox.Font = new Font(Settings.Instance.DumpTextBoxFontName, Settings.Instance.DumpTextBoxFontSize);
            // 翻訳表示テキストボックスのフォント色を設定
            dumpTextBox.ForeColor = Settings.Instance.DumpTextBoxForeColor;
            // 翻訳表示テキストボックスの背景色を設定
            dumpTextBox.BackColor = Settings.Instance.DumpTextBoxBackColor;
        }

        // フォームクローズ
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Instance.selfBarLocation = SelfBar.meInstance.Location;
            Settings.Instance.enemyBarLocation = EnemyBar.meInstance.Location;
            Settings.Instance.FormLocation = Location;
            Settings.Instance.FormSize = Size;
            Settings.SaveToXmlFile();
        }

        //フォームマウスダウン
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
                mousePoint = new Point(e.X, e.Y);
        }
        // フォームマウスムーブ
        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
                Location = new Point(Location.X + e.X - mousePoint.X, Location.Y + e.Y - mousePoint.Y);
        }

        // 設定画面メニュー
        private void setingFormOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingForm f = new SettingForm();
            f.ShowDialog(this);
            f.Dispose();
        }

        // 監視開始・停止ボタン
        private void moniterringButton_Click(object sender, EventArgs e){ MoniterringAction(); }
        // 監視開始・停止メニュー
        private void monitoringStartToolStripMenuItem_Click(object sender, EventArgs e) { MoniterringAction(); }

        // 形状変更ボタン
        private void styleChangeToolStripMenuItem_Click(object sender, EventArgs e) { StyleChangeAction(); }
        // 形状変更メニュー
        private void styleChangeButton_Click(object sender, EventArgs e) { StyleChangeAction(); }

        // ログクリアボタン
        private void logClearButton_Click(object sender, EventArgs e){ LogClearAction(monitoringStatusLabel); }
        // ログクリアメニュー
        private void LogClearToolStripMenuItem_Click(object sender, EventArgs e){ LogClearAction(monitoringStatusLabel); }

        // 翻訳表示テキストボックス
        private void dumpTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A){
                dumpTextBox.SelectAll();
            }
        }

        // 最前面オプションチェックボックス
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = !TopMost;
        }

        // 監視用タイマー
        private void watchTimer_Tick(object sender, EventArgs e)
        {
            long distanceByteSize = 0;
            Byte[] result = new Byte[] { };
            Byte[] suteru = new Byte[] { };
            String resultString = "";

            String nowLogFilePath = GetNewestFilePath(Settings.Instance.LogDir);
            if (nowLogFilePath == "")
            {
                MessageBox.Show("監視を設定出来ませんでした");
                return;
            }

            FileInfo sfi = new FileInfo(nowLogFilePath);
            // 未処理のファイルのサイズを取得
            long nowLogFileSize = sfi.Length;

            FileInfo fi = new FileInfo(nowLogFilePath);
            // 未処理のファイルをストリームとして扱う
            FileStream stream = fi.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            if (nowLogFilePath != processedLogFilePath)
            { // 未処理のファイルパスと処理済ファイルパスが異なる場合、処理済ファイルサイズとパスを更新し終了
                processedLogFilePath = nowLogFilePath;
                processedLogFileSize = nowLogFileSize;
                return;
            }

            distanceByteSize = nowLogFileSize - processedLogFileSize;
            if (distanceByteSize <= 0)
            { // ファイルサイズが変わらない場合はなにもせずに終了
                return;
            }

            Array.Resize<Byte>(ref result, (int)distanceByteSize);
            // ストリームのカレント位置を処理済ファイルの位置へ移動
            stream.Seek(processedLogFileSize, SeekOrigin.Current);
            // result に差分のストリームを格納
            stream.Read(result, 0, (int)distanceByteSize);

            // 処理済のファイルのサイズを更新
            processedLogFileSize = nowLogFileSize;

            // resultはbyte配列なので、Stringに加工
            resultString = Encoding.GetEncoding("utf-16").GetString(result);
            // 最終行の改行は削除
            resultString = resultString.TrimEnd('\r', '\n');
            // 改行の後の[記号を1つのデータとして扱う為、区切り文字に置き換え
            resultString = resultString.Replace("\r\n[", Constants.TranslationLogDelimiter + "[");

            // 取得した文字列をログコンテナに格納
            logContainer sourceContainer = new logContainer(resultString);

            // コンテナから発言だけを抜き出して、翻訳用の文字列を区切り文字でつなぐ
            string joinedString = string.Join(Constants.TranslationLogDelimiter, sourceContainer._echoList.ToArray());

            // 文字列を自軍のCTシミュレータに送る
            SelfBarAction(joinedString);

            // 文字列を敵軍のCTシミュレータに送る
            EnamyBarAction(joinedString);

            // 中国語固有名詞を固有名詞の接置詞＋specialWordList上の該当する中国語固有名詞のid＋固有名詞の接置詞に置換する
            // specialWordListではなくspecialWordListOfKeyDescSortでループを回しているのは、より長い文字列で先に置換する為
            foreach (KeyValuePair<string, string> kvp in specialWordListOfKeyDescSort)
            {
                // 中国語固有名詞を固有名詞の接置詞＋specialWordList上の該当する中国語固有名詞のid＋固有名詞の接置詞に置換
                joinedString = joinedString.Replace(kvp.Key, Constants.SpecialWordAdposition + specialWordList.IndexOfKey(kvp.Key) + Constants.SpecialWordAdposition);
            }

            // コンテナから発言者だけ抜き出して、ループを回す
            foreach (string owner in sourceContainer._ownerList) {
                if (maxOwnerLength < owner.Length)
                { // 発言者の文字長で、最大文字長の物が出現した時は更新する
                    maxOwnerLength = owner.Length;
                }
            }

            // WEBクライアントに持っていくデータをsendObjectsに纏める
            object[] sendObjects = new object[2];
            sendObjects[0] = sourceContainer;
            sendObjects[1] = maxOwnerLength;

            // TODO:wc.Encoding = Encoding.UTF8;って本当は書くべきなんだけど書くと文字化けするから書かない。調べなくちゃね。
            WebClient wc = new WebClient();
            try
            {
                wc.DownloadStringCompleted += CompleteDownloadProc; // ダウンロードが終わるとCompleteDownloadProcが呼び出される
                wc.DownloadStringAsync(new Uri("https://translate.google.com/?hl=ja&sl=zh-CN&tl=ja&q=" + Uri.EscapeUriString(joinedString)), sendObjects);
            }
            catch (WebException exc)
            {
                Console.WriteLine(exc.ToString());
                return;
            }
        }

        // 文字列を自軍のCTシミュレータに送る
        private void SelfBarAction(string joinedString)
        {
            Dictionary<string, string> SelfBarActionWords = new Dictionary<string, string> { };
            SelfBarActionWords["發出轟炸請求"] = "#timer1";
            SelfBarActionWords["發出索敵請求"] = "#timer2";
            SelfBarActionWords["發出米諾夫斯基粒子請求"] = "#timer3";
            SelfBarActionWords["發出補給艦請求"] = "#timer4";
            SelfBarActionWords["我軍皇牌機體出擊"] = "#timer5";
            SelfBarActionWords["我軍戰艦信號已設置"] = "#timer6";
            SelfBarActionWords["我軍戰略兵器已設置"] = "#timer7";
            SelfBarActionWords["我軍試作型戰略兵器已設置"] = "#timer8";
            SelfBarActionWords["我軍補給艦信號已設置"] = "#timer9";
            SelfBarActionWords["發出地毯式轟炸請求"] = "#timer10";
            SelfBarActionWords["發出輔助飛行系統請求"] = "#timer11";

            foreach (KeyValuePair<string, string> pair in SelfBarActionWords)
            {
                if (joinedString.Contains(pair.Key))
                {
                    try
                    {
                        string script = @"$('" + pair.Value + @"').click();";
                        SelfBar.chromeBrowser.ExecuteScriptAsync(script);
                    }
                    catch
                    {
                        return;
                    }
                }
            }
        }

        // 文字列を敵軍のCTシミュレータに送る
        private void EnamyBarAction(string joinedString)
        {
            Dictionary<string, string> SelfBarActionWords = new Dictionary<string, string> { };
            SelfBarActionWords["敵軍皇牌機體"] = "#timer5";

            foreach (KeyValuePair<string, string> pair in SelfBarActionWords)
            {
                if (joinedString.Contains(pair.Key))
                {
                    try
                    {
                        string script = @"$('" + pair.Value + @"').click();";
                        EnemyBar.chromeBrowser.ExecuteScriptAsync(script);
                    }
                    catch
                    {
                        return;
                    }
                }
            }
        }

        // 監視開始・停止アクション
        private void MoniterringAction()
        {
            if (watchTimer.Enabled == false)
            { // タイマーが動いていない場合は
                // ディレクトリの存在確認
                if (!Directory.Exists(Settings.Instance.LogDir))
                {
                    MessageBox.Show("ログディレクトリが存在しません");
                    return;
                }
                monitoringStatusLabel.Text = "監視準備";
                monitoringStatusLabel.ForeColor = Color.Yellow;

                

                processedLogFilePath = GetNewestFilePath(Settings.Instance.LogDir);
                if (processedLogFilePath == "")
                {
                    MessageBox.Show("監視を設定出来ませんでした");
                    return;
                }

                // 処理済みのファイルのサイズを保存
                FileInfo sfi = new FileInfo(processedLogFilePath);
                processedLogFileSize = sfi.Length;



                // 監視タイマーを起こす
                watchTimer.Enabled = true;
                Console.WriteLine("監視を開始しました。");

                //moniterringStart(Settings.Instance.LogDir);

                monitoringStatusLabel.Text = "監視中";
                monitoringStatusLabel.ForeColor = Color.Green;
                monitoringToolStripMenuItem.Text = moniterringButton.Text = "停止する";
                monitoringToolStripMenuItem.ForeColor = moniterringButton.ForeColor = Color.Red;
                return;
            }
            else
            { // タイマーが動いている場合は
                monitoringStatusLabel.Text = "停止準備";
                monitoringStatusLabel.ForeColor = Color.Yellow;
                // 監視を終了
                watchTimer.Enabled = false;
                Console.WriteLine("監視を終了しました。");
                monitoringStatusLabel.Text = "停止";
                monitoringStatusLabel.ForeColor = Color.Red;
                monitoringToolStripMenuItem.Text = moniterringButton.Text = "監視開始する";
                monitoringToolStripMenuItem.ForeColor = moniterringButton.ForeColor = Color.Green;
                return;
            }
        }

        // 形状変更アクション
        private void StyleChangeAction()
        {
            Size sizeFrameBorderSize = SystemInformation.FrameBorderSize;
            int nCaptionHeight = SystemInformation.CaptionHeight;
            Point put = new Point(0, 0);
            int sideAreaWidth = 165;

            if (TransparencyKey == System.Drawing.Color.Empty)
            {
                // 枠無しフォームにする
                TransparencyKey = SystemColors.ControlLightLight;
                menuStrip.Visible = false;

                dumpTextBox.Top = 0;
                dumpTextBox.Height = dumpTextBox.Height + menuStrip.Height;
                dumpTextBox.Width  = dumpTextBox.Width + sideAreaWidth;

                Opacity = Settings.Instance.Opacity * 0.01;

                FormBorderStyle = FormBorderStyle.None;
                put.X = Location.X + (sizeFrameBorderSize.Width * 2);
                put.Y = Location.Y + (nCaptionHeight + sizeFrameBorderSize.Height * 2);
                Location = put;

                if (SelfBar.meInstance != null && EnemyBar.meInstance != null) {
                    try { 
                        SelfBar.meInstance.Opacity  = Settings.Instance.Opacity * 0.01;
                        EnemyBar.meInstance.Opacity = Settings.Instance.Opacity * 0.01;
                    }
                    catch
                    {

                    }
                }
            }
            else
            {
                // 枠ありフォームにする
                TransparencyKey = System.Drawing.Color.Empty;
                menuStrip.Visible = true;

                dumpTextBox.Top = menuStrip.Height;
                dumpTextBox.Height = dumpTextBox.Height - menuStrip.Height;
                dumpTextBox.Width  = dumpTextBox.Width - sideAreaWidth;

                Opacity = 0.95;

                FormBorderStyle = FormBorderStyle.Sizable;
                put.X = Location.X - (sizeFrameBorderSize.Width * 2);
                put.Y = Location.Y - (nCaptionHeight + sizeFrameBorderSize.Height * 2);
                Location = put;

                if (SelfBar.meInstance != null && EnemyBar.meInstance != null)
                {
                    try
                    {
                        SelfBar.meInstance.Opacity = 0.95;
                        EnemyBar.meInstance.Opacity = 0.95;
                    }
                    catch
                    {

                    }
                }
            }

            moniterringButton.Visible = !moniterringButton.Visible;
            checkBox1.Visible         = !checkBox1.Visible;
            logClearButton.Visible    = !logClearButton.Visible;
        }

        // ログクリアアクション
        private void LogClearAction(ToolStripStatusLabel strip)
        {
            DialogResult result = MessageBox.Show("本当にクリアしますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                dumpTextBox.Text = "";
                strip.Text = "クリアしました";
                strip.ForeColor = Color.Black;
            }
        }

        // 指定フォルダ内の最新更新ファイルパスの取得
        private string GetNewestFilePath(string dir)
        {
            string[] filePaths = Directory.GetFiles(dir, "*.*");
            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            List<FileInfo> fileList = new List<FileInfo>(dirInfo.GetFiles("*.*"));
            fileList.Sort(delegate (FileInfo x, FileInfo y) { return x.LastWriteTime.CompareTo(y.LastWriteTime); });

            // 古い日付順になるので
            string newest_fileName = "";
            foreach (System.IO.FileInfo attach_path in fileList)
            {
                newest_fileName = attach_path.ToString();
            }
            // MessageBox.Show(newest_fileName);
            if (newest_fileName == "") return "";
            string newest_path = "";
            newest_path = dir + "\\" + newest_fileName;
            return newest_path;
        }
        
        // ダウンロード後プロセス
        public void CompleteDownloadProc(Object sender, DownloadStringCompletedEventArgs e)
        {
            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            object[] sendObjects = (object[])e.UserState;
            logContainer sourceContainer = (logContainer)sendObjects[0];
            int maxOwnerLength = (int)sendObjects[1];
            try
            {
                htmlDoc.LoadHtml(e.Result);
            }
            catch
            {
                return;
            }

            /* PC版翻訳ページをパース */
            HtmlAgilityPack.HtmlNode tranNode = htmlDoc.DocumentNode.SelectSingleNode("//span[@id=\"result_box\"]");
            String tranString = tranNode.InnerText;
            tranString = HttpUtility.HtmlDecode(tranString); // ブラウザ上でのunicode文字列は&#の通常文字列な為変換する
            String[] delimiter = { Constants.TranslationLogDelimiter.Replace("\r", "") };
            String[] tranArray = tranString.Split(delimiter, StringSplitOptions.None); //これで1行づつになる

            int i = 0;
            string processedValue;
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string value in tranArray)
            {
                processedValue = value;

                // 固有名詞の接置詞＋specialWordList上の該当する中国語固有名詞のid＋固有名詞の接置詞を日本語固有名詞文字列に置換
                processedValue = Regex.Replace(
                    processedValue,
                    Constants.SpecialWordAdposition + @"(?<m>.*?)" + Constants.SpecialWordAdposition,
                    new MatchEvaluator(MatchWordReplaceToSpecialWord), 
                    RegexOptions.Singleline | RegexOptions.ExplicitCapture
                    );

                // 不要な文字の削除
                processedValue = processedValue.Replace("\r", "");

                if (sourceContainer._ownerList[i] != "")
                {
                    stringBuilder.Append(string.Format("{0:s} : {1:s}\r\n", Strings.StrConv(sourceContainer._ownerList[i], VbStrConv.Wide).PadRight(maxOwnerLength, '　'), processedValue));
                }
                else
                {
                    stringBuilder.Append(string.Format("{0:s}\r\n", processedValue));
                }
                i++;
            }
            // 出力
            dumpTextBox.AppendText(stringBuilder.ToString());

        }

        // 文字長の降順でソート用のデリゲートメソッド
        static int CompareKeyLengthDesc(KeyValuePair<string, string> x, KeyValuePair<string, string> y)
        {
            // Keyの文字長で比較した結果を返す
            return y.Key.Length - x.Key.Length;
        }

        // 固有名詞の接置詞＋specialWordList上の該当する中国語固有名詞のid＋固有名詞の接置詞を日本語固有名詞文字列に置換するMatchEvaluator用のデリゲートメソッド
        private string MatchWordReplaceToSpecialWord(System.Text.RegularExpressions.Match m)
        {
            int resultIndex;
            if (int.TryParse(m.Groups["m"].Value, out resultIndex) == false)
            {
                return "";
            }
            return specialWordList.Values[resultIndex];// 見つかった特殊文字列のIDを元に固有名詞文字列を返す
        }

        private void InfoIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox f = new AboutBox();
            f.ShowDialog(this);
            f.Dispose();

        }
    }

    //定数用クラス
    static class Constants
    {
        public const string SpecialWordAdposition = "\r♦♦\r"; // 固有名詞の接置詞（前置詞と後置詞）
        public const string TranslationLogDelimiter = "@@@@@@\r";//このデリミターは、日本語変換掛けられた時に前後の文面でも位置すら変化しないものを設定する必要がある。とっても面倒だけど、いろいろ調べてこれに落ち着いた。例えばブラウザで表示した段階で\nが無くなったり、@@@@だけだと、hoge@@@@hogeがhogehoge@@@@とかに変換されたりといろいろあった。
        public const string TranslateGooglSourceXpath = "//textarea[@id=\"source\"]";
        public const string TranslateGoogleResultXpath = "//span[@id=\"result_box\"]";
    }
}
