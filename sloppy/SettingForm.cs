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
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            // XMLファイルから設定を読み込む
            Settings.LoadFromXmlFile();

            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            logFolderTextBox.Text = Settings.Instance.LogDir;
            previewDumpTextBox.Font = new Font(Settings.Instance.DumpTextBoxFontName, Settings.Instance.DumpTextBoxFontSize);
            previewDumpTextBox.ForeColor = Settings.Instance.DumpTextBoxForeColor;
            previewDumpTextBox.BackColor = Settings.Instance.DumpTextBoxBackColor;
            opacityTrackBar.Value    = Settings.Instance.Opacity;
        }

        private void logFolderDialogOpenButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.Description = "ログの保存されているディレクトリを指定して下さい";
            fd.RootFolder = Environment.SpecialFolder.Desktop;
            fd.SelectedPath = logFolderTextBox.Text;

            if (fd.ShowDialog(this) == DialogResult.OK)
            {
                logFolderTextBox.Text = fd.SelectedPath;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // バリデーション
            if (!System.IO.Directory.Exists(logFolderTextBox.Text))
            {
                MessageBox.Show("ログディレクトリが存在しません");
                return;
            }

            // 設定を変更する
            Settings.Instance.LogDir               = logFolderTextBox.Text;
            Settings.Instance.DumpTextBoxFontSize  = (int)previewDumpTextBox.Font.SizeInPoints;
            Settings.Instance.DumpTextBoxFontName  = previewDumpTextBox.Font.Name;
            Settings.Instance.DumpTextBoxForeColor = previewDumpTextBox.ForeColor;
            Settings.Instance.DumpTextBoxBackColor = previewDumpTextBox.BackColor;
            Settings.Instance.Opacity              = opacityTrackBar.Value;
            // 現在の設定をXMLファイルに保存する
            Settings.SaveToXmlFile();

            MainForm fm = (MainForm)this.Owner;
            fm.RefleshFlag = true;
            fm.selfTacticalForm.RefleshFlag = true;
            fm.enemyTacticalForm.RefleshFlag = true;
            fm.selfTacticalForm.setingDeployAction();
            fm.enemyTacticalForm.setingDeployAction();
            Close();
        }


        private void fontDialogOpenButton_Click(object sender, EventArgs e)
        {
            //FontDialogクラスのインスタンスを作成
            FontDialog fd = new FontDialog();

            //初期のフォントを設定
            fd.Font = previewDumpTextBox.Font;
            //初期の色を設定
            fd.Color = previewDumpTextBox.ForeColor;
            //ユーザーが選択できるポイントサイズの最大値を設定する
            fd.MaxSize = 30;
            fd.MinSize = 7;
            //存在しないフォントやスタイルをユーザーが選択すると
            //エラーメッセージを表示する
            fd.FontMustExist = true;
            //横書きフォントだけを表示する
            fd.AllowVerticalFonts = false;
            //色を選択できるようにする
            fd.ShowColor = true;
            //取り消し線、下線、テキストの色などのオプションを指定可能にする
            fd.ShowEffects = true;
            //固定ピッチフォント以外も表示する
            fd.FixedPitchOnly = false;
            //ベクタ フォントを選択できるようにする
            fd.AllowVectorFonts = true;

            //ダイアログを表示する
            if (fd.ShowDialog() != DialogResult.Cancel)
            {
                //TextBox1のフォントと色を変える
                previewDumpTextBox.Font      = fd.Font;
                previewDumpTextBox.ForeColor = fd.Color;
            }
        }

        private void backColorDialogOpenButton_Click(object sender, EventArgs e)
        {
            //ColorDialogクラスのインスタンスを作成
            ColorDialog cd = new ColorDialog();

            //はじめに選択されている色を設定
            cd.Color = previewDumpTextBox.BackColor;
            //色の作成部分を表示可能にする
            //デフォルトがTrueのため必要はない
            cd.AllowFullOpen = true;
            //純色だけに制限しない
            //デフォルトがFalseのため必要はない
            cd.SolidColorOnly = false;
            //[作成した色]に指定した色（RGB値）を表示する
            cd.CustomColors = new int[] {
                0x33, 0x66, 0x99, 0xCC, 0x3300, 0x3333,
                0x3366, 0x3399, 0x33CC, 0x6600, 0x6633,
                0x6666, 0x6699, 0x66CC, 0x9900, 0x9933};

            //ダイアログを表示する
            if (cd.ShowDialog() == DialogResult.OK)
            {
                //選択された色の取得
                previewDumpTextBox.BackColor = cd.Color;
            }
        }

        private void opacityTrackBar_Scroll(object sender, EventArgs e)
        {
            Opacity = opacityTrackBar.Value * 0.01;
            OpacityChangeButtonRefresh();
        }


        private void opacityChangeButton_Click(object sender, EventArgs e)
        {
            if(Opacity == 1) {
                Opacity = opacityTrackBar.Value * 0.01;
            }
            else
            {
                Opacity = 1;
            }
            OpacityChangeButtonRefresh();
        }

        private void OpacityChangeButtonRefresh()
        {
            if (Opacity != 1)
            {
                opacityChangeButton.Text = "ＯＫ";
            }
            else
            {
                opacityChangeButton.Text = "プレビュー";
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            previewDumpTextBox.Focus();
        }

        private void returnDefaultButton_Click(object sender, EventArgs e)
        {
            Settings.LoadFromXmlFile();
            logFolderTextBox.Text = Settings.Instance.LogDir;
            previewDumpTextBox.Font = new Font(Settings.Instance.DumpTextBoxFontName, Settings.Instance.DumpTextBoxFontSize);
            previewDumpTextBox.ForeColor = Settings.Instance.DumpTextBoxForeColor;
            previewDumpTextBox.BackColor = Settings.Instance.DumpTextBoxBackColor;
            opacityTrackBar.Value = Settings.Instance.Opacity;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SettingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 翻訳表示テキストボックスのフォントを設定
            MainForm.meInstance.dumpTextBox.Font = new Font(Settings.Instance.DumpTextBoxFontName, Settings.Instance.DumpTextBoxFontSize);
            // 翻訳表示テキストボックスのフォント色を設定
            MainForm.meInstance.dumpTextBox.ForeColor = Settings.Instance.DumpTextBoxForeColor;
            // 翻訳表示テキストボックスの背景色を設定
            MainForm.meInstance.dumpTextBox.BackColor = Settings.Instance.DumpTextBoxBackColor;
        }
    }
}
