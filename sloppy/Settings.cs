using System;
using System.IO;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Drawing;
namespace sloppy
{
    [Serializable()]
    public class Settings
    {
        // 設定を保存するフィールド
        private string _logdir;   // ログの保存パス
        private Point  _location; // フォームの表示位置
        private Size   _formSize; // フォームの縦横サイズ
        private int    _opacity;  // フォームの透明度（0-100）
        private string _dumpTextBoxForeColorString; // 翻訳表示のフォントの色
        private string _dumpTextBoxBackColorString; // 翻訳表示の背景色
        private string _dumpTextBoxFontName;        // 翻訳表示のフォント名
        private int    _dumpTextBoxFontSize;        // 翻訳表示のフォントサイズ
        private Point _selfBarLocation;  // 自軍サイドフォームの表示位置
        private Point _enemyBarLocation; // 敵軍サイドフォームの表示位置
        private Size _selfBarFormSize;   // 自軍サイドフォームの縦横サイズ
        private Size _enemyBarFormSize;  // 敵軍サイドフォームの縦横サイズ

        // 設定のプロパティ
        public string LogDir
        {
            get { return _logdir; }
            set { _logdir = value; }
        }
        public Point FormLocation
        {
            get { return _location; }
            set { _location = value; }
        }
        public int Opacity
        {
            get { return _opacity; }
            set { _opacity = value; }
        }
        public Size FormSize
        {
            get { return _formSize; }
            set { _formSize = value; }
        }
        public string DumpTextBoxForeColorString
        {
            get { return ColorTranslator.ToHtml(DumpTextBoxForeColor); }
            set { _dumpTextBoxForeColorString = value;
                _dumpTextBoxForeColor = ColorTranslator.FromHtml(value);
            }
        }
        public string DumpTextBoxBackColorString
        {
            get { return ColorTranslator.ToHtml(DumpTextBoxBackColor); }
            set { DumpTextBoxBackColor = ColorTranslator.FromHtml(value); }
        }
        public string DumpTextBoxFontName
        {
            get { return _dumpTextBoxFontName; }
            set { _dumpTextBoxFontName = value; }
        }
        public int DumpTextBoxFontSize
        {
            get { return _dumpTextBoxFontSize; }
            set { _dumpTextBoxFontSize = value; }
        }
        public Point selfBarLocation
        {
            get { return _selfBarLocation; }
            set { _selfBarLocation = value; }
        }
        public Point enemyBarLocation
        {
            get { return _enemyBarLocation; }
            set { _enemyBarLocation = value; }
        }
        public Size selfBarFormSize
        {
            get { return _selfBarFormSize; }
            set { _selfBarFormSize = value; }
        }
        public Size enemyBarFormSize
        {
            get { return _enemyBarFormSize; }
            set { _enemyBarFormSize = value; }
        }

        //コンストラクタ
        public Settings()
        {
            _logdir               = @"C:\Program Files (x86)\Gameone\Gundam_Online\GundamOnline\chat"; 
            _location             = new Point(600, 800);
            _formSize             = new Size(800, 320);
            _opacity              = 80;
            _dumpTextBoxForeColor = Color.FromArgb(244, 250, 244);
            _dumpTextBoxBackColor = Color.FromArgb(10, 30, 10);
            _dumpTextBoxFontName  = "メイリオ";
            _dumpTextBoxFontSize  = 12;
            _selfBarLocation      = new Point(1500, 300);
            _enemyBarLocation     = new Point(300, 300);
            _selfBarFormSize      = new Size(275, 400);
            _enemyBarFormSize     = new Size(275, 400);
            
        }
        [System.Xml.Serialization.XmlIgnore]
        public Color DumpTextBoxForeColor
        {
            get { return _dumpTextBoxForeColor; }
            set {
                _dumpTextBoxForeColor = value;
                _dumpTextBoxForeColorString = ColorTranslator.ToHtml(value);
            }
        }
        [System.Xml.Serialization.XmlIgnore]
        public Color DumpTextBoxBackColor
        {
            get { return _dumpTextBoxBackColor; }
            set {
                _dumpTextBoxBackColor = value;
                _dumpTextBoxBackColorString = ColorTranslator.ToHtml(value);
            }
        }

        //Settingsクラスのただ一つのインスタンス
        [NonSerialized()]
        private Color _dumpTextBoxForeColor;
        [NonSerialized()]
        private Color _dumpTextBoxBackColor;
        [NonSerialized()]
        private static Settings _instance;
        [System.Xml.Serialization.XmlIgnore]
        public static Settings Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Settings();
                return _instance;
            }
            set { _instance = value; }
        }

        /// <summary>
        /// 設定をXMLファイルから読み込み復元する
        /// </summary>
        public static void LoadFromXmlFile()
        {
            string path = GetSettingPath();
            // 設定ファイルが無い場合の処理
            if (!System.IO.File.Exists(path)){
                _instance = new Settings();
                SaveToXmlFile();
            }
            StreamReader sr = new StreamReader(path, new UTF8Encoding(false));
            try
            { 
                System.Xml.Serialization.XmlSerializer xs =
                    new System.Xml.Serialization.XmlSerializer(typeof(Settings));
                //読み込んで逆シリアル化する
                object obj = xs.Deserialize(sr);
                sr.Close();

                Instance = (Settings)obj;
                Instance._dumpTextBoxForeColor = ColorTranslator.FromHtml(Instance._dumpTextBoxForeColorString);
                Instance._dumpTextBoxBackColor = ColorTranslator.FromHtml(Instance._dumpTextBoxBackColorString);
            }
            catch
            {
                // TODO：ここにXMLファイルを削除する処理を書く
                return;
            }
        }

        /// <summary>
        /// 現在の設定をXMLファイルに保存する
        /// </summary>
        public static void SaveToXmlFile()
        {
            string path = GetSettingPath();

            StreamWriter sw = new StreamWriter(path, false ,new UTF8Encoding(false));
            System.Xml.Serialization.XmlSerializer xs =
                new System.Xml.Serialization.XmlSerializer(typeof(Settings));
            //シリアル化して書き込む
            xs.Serialize(sw, Instance);
            sw.Close();
        }

        private static string GetSettingPath()
        {
            return Application.StartupPath + "\\" + Application.ProductName + ".xml";
        }
    
    }
}