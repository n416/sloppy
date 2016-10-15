using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace sloppy
{
    public partial class TacticalForm : Form
    {
        public TacticalForm()
        {
            InitializeComponent();
        }
        public TacticalForm(int inputMode):this()
        {
            mode = inputMode;
        }

        // 表示のリフレッシュフラグ
        public static Boolean refleshFlag = false;
        public Boolean RefleshFlag
        {
            set { refleshFlag = value; }
            get { return refleshFlag; }
        }

        // ドラッグ中のマウス位置
        private Point mousePoint;

        public const int ModeEnemy = 0;
        public const int ModeSelf = 1;

        public int allSec = 1190;
        public int mode;
        public TacticalForm myInstance;
        public List<RowContiner> gridBacks;

        private void TacticalForm_Load(object sender, EventArgs e)
        {
            // フォームで仕様する各種変数の初期化
            int rowIndex = 0;
            gridBacks = new List<RowContiner>();
            RefleshFlag = true;

            // 設定を反映
            setingDeployAction();

            // グリッドビューの初期化
            dataGridView.Rows.Add(Weapons.allList.Count);
            foreach (WeaponModel Weapon in Weapons.allList)
            {
                WeaponStatusModel st = Weapon.statusList[0];// ステータスの初期値を0固定とする
                st.setEndingTime(MainForm.meInstance.selfTacticalForm.allSec);
                gridBacks.Add(new RowContiner(rowIndex, Weapon.label, (st.specialText != "") ? st.specialText : IntToTime(st.endingTime), st, st.time));
                rowIndex++;
            }

            // セルサイズを調整
            gridResizeAction();

            // 時刻合わせ等の全体コントロールを非表示
            if (mode == ModeEnemy) controlGroupVisible(false);

            // グリッドビューにマウスダウンイベントを追加
            dataGridView.MouseDown += new MouseEventHandler(TacticalForm_MouseDown);
            // グリッドビューにマウスムーブイベントを追加
            dataGridView.MouseMove += new MouseEventHandler(TacticalForm_MouseMove);

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView.Font = new Font("メイリオ", 11);

            myInstance = this;
        }

        // 時刻合わせ等のコントロール系表示
        public void controlGroupVisible(bool v)
        {
            Size sizeFrameBorderSize = SystemInformation.FrameBorderSize;
            int nCaptionHeight = SystemInformation.CaptionHeight;
            Point put = new Point(0, 0);

            if (v == false) { 
                inputLabel.Visible = false;
                inputText.Visible = false;
                statusResetButton.Visible = false;
                timeSettingButton.Visible = false;
                timerPreview.Visible = false;

                dataGridView.Location = new Point(0, 0);
                dataGridView.Height = Height - (SystemInformation.CaptionHeight + sizeFrameBorderSize.Height * 2);
                if (mode == ModeSelf) dataGridView.Height += 32;

                put.X = Location.X + (sizeFrameBorderSize.Width * 2);
                put.Y = Location.Y + (nCaptionHeight + sizeFrameBorderSize.Height * 2);
                Location = put;
            }
            else
            {
                inputLabel.Visible = true;
                inputText.Visible = true;
                timeSettingButton.Visible = true;
                statusResetButton.Visible = true;
                timerPreview.Visible = true;

                dataGridView.Location = new Point(0, 73);
                dataGridView.Height = (Height - (SystemInformation.CaptionHeight + sizeFrameBorderSize.Height * 2)) - 73;

                put.X = Location.X + (sizeFrameBorderSize.Width * 2);
                put.Y = Location.Y + (nCaptionHeight + sizeFrameBorderSize.Height * 2);
                if (mode == ModeSelf)
                {
                    put.X -= 16;
                    put.Y -= 62;
                }
                Location = put;

            }

        }


        // グリッドを再描画
        public void gridRewrite()
        {
            foreach(RowContiner row in gridBacks)
            {
                dataGridView[0, row.rowIndex].Value = row.caption;
                dataGridView[0, row.rowIndex].Style.Padding = new Padding(20, 0, 10, 0);

                string outputValue = "";
                if (row.status.specialText != "") outputValue = outputValue + row.status.specialText;
                if (row.status.time != 0) outputValue = outputValue + ":" + IntToTime(row.status.endingTime);
                dataGridView[1, row.rowIndex].Value = outputValue;
                dataGridView[1, row.rowIndex].Style.ForeColor = row.status.forColor;
            }
            dataGridView.CurrentCell = null;
        }

        private void TacticalForm_Shown(object sender, EventArgs e)
        {
            // グリッドを再描画
            gridRewrite();
        }
        
        private void dataGridView1_Resize(object sender, EventArgs e)
        {
            // セルサイズを調整
            gridResizeAction();
        }

        private void gridResizeAction()
        {
            if (gridBacks == null) return;
            if (gridBacks.Count == 0) return;
            int rowHeight = (dataGridView.Height - 2) / gridBacks.Count;
            int colWidth = (dataGridView.Width - 2) / 2;
            /* 均等に */
            for (int i = 0; i < gridBacks.Count; i++)
            {
                dataGridView.Rows[i].Height = rowHeight;
            }
            if(colWidth < 274/2)
            {
                for (int i = 0; i < gridBacks.Count; i++) dataGridView[0, i].Style.Padding = new Padding(10, 0, 10, 0);
                dataGridView.Columns[0].Width = 80;
                dataGridView.Columns[1].Width = dataGridView.Width-100;
            }
            else
            {
                for (int i = 0; i < gridBacks.Count; i++) dataGridView[0, i].Style.Padding = new Padding((int)Math.Floor(Width * 0.12), 0, 10, 0);
                dataGridView.Columns[0].Width = 80;

            }

        }

        private void timeSettingButton_Click(object sender, EventArgs e)
        {
            if(timer.Enabled == false)
            {
                MainForm.meInstance.selfTacticalForm.allSec = TimeToInt(inputText.Text);
                timer.Enabled = true;

                foreach (RowContiner row in gridBacks)
                {
                    row.time = MainForm.meInstance.selfTacticalForm.allSec - row.status.time;
                    row.data = (row.status.specialText != "")? row.status.specialText :IntToTime(row.time);
                }

                gridRewrite();
                timeSettingButton.Text = "停止";
            }
            else
            {
                timer.Enabled = false;
                timeSettingButton.Text = "時計合わせ";
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            // 時計表示
            timerPreview.Text = IntToTime(MainForm.meInstance.selfTacticalForm.allSec);
            if (MainForm.meInstance.selfTacticalForm.allSec < 1)
            {
                timer.Enabled = false;
                timeSettingButton.Text = "時計合わせ";
            }

            for(int i = 0; i < gridBacks.Count; i++)
            {
                var row = gridBacks[i];
                if (row.status.endingTime >= MainForm.meInstance.selfTacticalForm.allSec && row.status.infinityFlag == false)
                {
                    //次のステータスを取得して、gridBacksにセット
                    gridBacks[row.rowIndex].status = Weapons.getNextStatus(row.caption, row.status, MainForm.meInstance.selfTacticalForm.allSec);
                    gridRewrite();
                }
            }

            MainForm.meInstance.selfTacticalForm.allSec--;
        }

        private string IntToTime(int intTime)
        {
            double d = intTime / 60;
            double min = Math.Floor(d);
            int sec = intTime % 60;
            // 99'99
            return min.ToString() + "'" + sec.ToString().PadLeft(2, '0');

        }

        private int TimeToInt(string stringTime)
        {
            Regex regex = new Regex(@"[^0-9]");
            int inputInt;
            if (int.TryParse(regex.Replace(stringTime, ""), out inputInt) == false) return 0;
            // int
            return ((inputInt - inputInt % 100) / 100 * 60) + inputInt % 100;
        }

        public class RowContiner
        {
            public int rowIndex { get; set; }
            public string caption { get; set; }
            public string data { get; set; }
            public int time { get; set; }
            public WeaponStatusModel status { get; set; }

            public RowContiner(int inputRowIndex, string inputCaption, string inputData,WeaponStatusModel inputStatus, int inputTime)
            {
                caption = inputCaption;
                data = inputData;
                rowIndex = inputRowIndex;
                status = inputStatus;
                time = inputTime;
            }
        }

        //フォームマウスダウン
        private void TacticalForm_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
                mousePoint = new Point(e.X, e.Y);
        }

        // フォームマウスムーブ
        private void TacticalForm_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
                Location = new Point(Location.X + e.X - mousePoint.X, Location.Y + e.Y - mousePoint.Y);
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TacticalForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }


        public void setingDeployAction()
        {

            if (RefleshFlag == false) return;

            // グリッドビューの背景色を設定
            Color backColor = Settings.Instance.DumpTextBoxBackColor;
            if (mode == ModeEnemy) backColor = ColorTranslator.FromHtml(nearColorString(Settings.Instance.DumpTextBoxBackColor, "#550000"));
            dataGridView.DefaultCellStyle.BackColor = backColor;
            dataGridView.DefaultCellStyle.SelectionBackColor = backColor;
            dataGridView.BackgroundColor = backColor;

            // グリッドビューの前景色を設定
            dataGridView.DefaultCellStyle.ForeColor = Settings.Instance.DumpTextBoxForeColor;

            // フォームの位置を設定
            if (mode == ModeEnemy)
            {
                Location = Settings.Instance.enemyBarLocation;
                Size = Settings.Instance.enemyBarFormSize;
                Text = "敵軍サイド";
            }
            else
            {
                Location = Settings.Instance.selfBarLocation;
                Size = Settings.Instance.selfBarFormSize;
                Text = "自軍サイド";
            }

            RefleshFlag = false;
        }

        // TODO:かなりいい加減な色合わせメソッド。ヒマになりすぎたら良い物に作りかえる
        private String nearColorString(Color inputColor,string neearRGB)
        {
            string red   = ColorTranslator.ToHtml(Color.FromArgb(inputColor.ToArgb())).Substring(1, 2);
            string green = ColorTranslator.ToHtml(Color.FromArgb(inputColor.ToArgb())).Substring(3, 2);
            string blue  = ColorTranslator.ToHtml(Color.FromArgb(inputColor.ToArgb())).Substring(5, 2);
            if(neearRGB.Length != 7) return "#" + red + green + blue;

            int nearRed   = int.Parse(neearRGB.Substring(1, 2), System.Globalization.NumberStyles.HexNumber);
            int nearGreen = int.Parse(neearRGB.Substring(3, 2), System.Globalization.NumberStyles.HexNumber);
            int nearBlue  = int.Parse(neearRGB.Substring(5, 2), System.Globalization.NumberStyles.HexNumber);

            int max = nearRed;
            string near = nameof(nearRed);
            if (max < nearGreen) { max = nearGreen; near = nameof(nearGreen); }
            if (max < nearBlue) { max = nearBlue; near = nameof(nearBlue); }
            string hexMax = Convert.ToString(max, 16);
            switch (near)
            {
                case nameof(nearRed):
                    return "#" + hexMax + green + blue;
                case nameof(nearGreen):
                    return "#" + red + hexMax + blue;
                case nameof(nearBlue):
                    return "#" + red + green + hexMax;
            }
            return "#" + red + green + blue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (WeaponModel Weapon in Weapons.allList)
            {
                WeaponStatusModel st = Weapon.statusList[0];// ステータスの初期値を0固定とする
                st.setEndingTime(MainForm.meInstance.selfTacticalForm.allSec);
                MainForm.meInstance.selfTacticalForm.gridBacks[i].status = st;
                MainForm.meInstance.enemyTacticalForm.gridBacks[i].status = st;
                i++;
            }
            gridRewrite();
        }
    }

}
