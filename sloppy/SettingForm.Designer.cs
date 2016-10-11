namespace sloppy
{
    partial class SettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param label="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.logFolderTextBox = new System.Windows.Forms.TextBox();
            this.logFolderDialogOpenButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.logFolderLabel = new System.Windows.Forms.Label();
            this.returnDefaultButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.previewDumpTextBoxGroupBox = new System.Windows.Forms.GroupBox();
            this.opacityChangeButton = new System.Windows.Forms.Button();
            this.backColorDialogOpenButton = new System.Windows.Forms.Button();
            this.previewDumpTextBox = new System.Windows.Forms.TextBox();
            this.fontDialogOpenButton = new System.Windows.Forms.Button();
            this.opacityTrackBar = new System.Windows.Forms.TrackBar();
            this.opacityLabel = new System.Windows.Forms.Label();
            this.previewDumpTextBoxGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opacityTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // logFolderTextBox
            // 
            this.logFolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logFolderTextBox.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.logFolderTextBox.Location = new System.Drawing.Point(83, 12);
            this.logFolderTextBox.Name = "logFolderTextBox";
            this.logFolderTextBox.Size = new System.Drawing.Size(612, 22);
            this.logFolderTextBox.TabIndex = 0;
            // 
            // logFolderDialogOpenButton
            // 
            this.logFolderDialogOpenButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.logFolderDialogOpenButton.Location = new System.Drawing.Point(701, 13);
            this.logFolderDialogOpenButton.Name = "logFolderDialogOpenButton";
            this.logFolderDialogOpenButton.Size = new System.Drawing.Size(75, 23);
            this.logFolderDialogOpenButton.TabIndex = 1;
            this.logFolderDialogOpenButton.Text = "参照";
            this.logFolderDialogOpenButton.UseVisualStyleBackColor = true;
            this.logFolderDialogOpenButton.Click += new System.EventHandler(this.logFolderDialogOpenButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(626, 292);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(150, 30);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "保存する(&S)";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // logFolderLabel
            // 
            this.logFolderLabel.AutoSize = true;
            this.logFolderLabel.Location = new System.Drawing.Point(5, 18);
            this.logFolderLabel.Name = "logFolderLabel";
            this.logFolderLabel.Size = new System.Drawing.Size(72, 12);
            this.logFolderLabel.TabIndex = 3;
            this.logFolderLabel.Text = "ログディレクトリ";
            this.logFolderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // returnDefaultButton
            // 
            this.returnDefaultButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.returnDefaultButton.Location = new System.Drawing.Point(7, 292);
            this.returnDefaultButton.Name = "returnDefaultButton";
            this.returnDefaultButton.Size = new System.Drawing.Size(150, 30);
            this.returnDefaultButton.TabIndex = 11;
            this.returnDefaultButton.Text = "規定値に戻す(&D)";
            this.returnDefaultButton.UseVisualStyleBackColor = true;
            this.returnDefaultButton.Click += new System.EventHandler(this.returnDefaultButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(470, 292);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(150, 30);
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Text = "キャンセル(&C)";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // previewDumpTextBoxGroupBox
            // 
            this.previewDumpTextBoxGroupBox.Controls.Add(this.opacityChangeButton);
            this.previewDumpTextBoxGroupBox.Controls.Add(this.backColorDialogOpenButton);
            this.previewDumpTextBoxGroupBox.Controls.Add(this.previewDumpTextBox);
            this.previewDumpTextBoxGroupBox.Controls.Add(this.fontDialogOpenButton);
            this.previewDumpTextBoxGroupBox.Controls.Add(this.opacityTrackBar);
            this.previewDumpTextBoxGroupBox.Controls.Add(this.opacityLabel);
            this.previewDumpTextBoxGroupBox.Location = new System.Drawing.Point(12, 48);
            this.previewDumpTextBoxGroupBox.Name = "previewDumpTextBoxGroupBox";
            this.previewDumpTextBoxGroupBox.Size = new System.Drawing.Size(764, 237);
            this.previewDumpTextBoxGroupBox.TabIndex = 13;
            this.previewDumpTextBoxGroupBox.TabStop = false;
            this.previewDumpTextBoxGroupBox.Text = "表示";
            this.previewDumpTextBoxGroupBox.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // opacityChangeButton
            // 
            this.opacityChangeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.opacityChangeButton.Location = new System.Drawing.Point(614, 202);
            this.opacityChangeButton.Name = "opacityChangeButton";
            this.opacityChangeButton.Size = new System.Drawing.Size(138, 23);
            this.opacityChangeButton.TabIndex = 18;
            this.opacityChangeButton.Text = "プレビュー";
            this.opacityChangeButton.UseVisualStyleBackColor = true;
            this.opacityChangeButton.Click += new System.EventHandler(this.opacityChangeButton_Click);
            // 
            // backColorDialogOpenButton
            // 
            this.backColorDialogOpenButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.backColorDialogOpenButton.Location = new System.Drawing.Point(677, 54);
            this.backColorDialogOpenButton.Name = "backColorDialogOpenButton";
            this.backColorDialogOpenButton.Size = new System.Drawing.Size(75, 23);
            this.backColorDialogOpenButton.TabIndex = 14;
            this.backColorDialogOpenButton.Text = "背景色";
            this.backColorDialogOpenButton.UseVisualStyleBackColor = true;
            this.backColorDialogOpenButton.Click += new System.EventHandler(this.backColorDialogOpenButton_Click);
            // 
            // previewDumpTextBox
            // 
            this.previewDumpTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.previewDumpTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.previewDumpTextBox.Location = new System.Drawing.Point(14, 25);
            this.previewDumpTextBox.Multiline = true;
            this.previewDumpTextBox.Name = "previewDumpTextBox";
            this.previewDumpTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.previewDumpTextBox.Size = new System.Drawing.Size(657, 106);
            this.previewDumpTextBox.TabIndex = 12;
            this.previewDumpTextBox.Text = "ほげ　： 祗園精舎の鐘の声、\r\nふが　： 諸行無常の響きあり。\r\nほげ　： 娑羅双樹の花の色、\r\nふが　： 盛者必衰の理をあらはす。\r\nほげ　： おごれる人も久し" +
    "からず、唯春の夜の夢のごとし。\r\nふが　： たけき者も遂にはほろびぬ、偏に風の前の塵に同じ。\r\n";
            // 
            // fontDialogOpenButton
            // 
            this.fontDialogOpenButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fontDialogOpenButton.Location = new System.Drawing.Point(677, 25);
            this.fontDialogOpenButton.Name = "fontDialogOpenButton";
            this.fontDialogOpenButton.Size = new System.Drawing.Size(75, 23);
            this.fontDialogOpenButton.TabIndex = 13;
            this.fontDialogOpenButton.Text = "フォント";
            this.fontDialogOpenButton.UseVisualStyleBackColor = true;
            this.fontDialogOpenButton.Click += new System.EventHandler(this.fontDialogOpenButton_Click);
            // 
            // opacityTrackBar
            // 
            this.opacityTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.opacityTrackBar.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.opacityTrackBar.LargeChange = 1;
            this.opacityTrackBar.Location = new System.Drawing.Point(14, 158);
            this.opacityTrackBar.Maximum = 100;
            this.opacityTrackBar.Minimum = 40;
            this.opacityTrackBar.Name = "opacityTrackBar";
            this.opacityTrackBar.Size = new System.Drawing.Size(738, 45);
            this.opacityTrackBar.TabIndex = 16;
            this.opacityTrackBar.Value = 40;
            this.opacityTrackBar.Scroll += new System.EventHandler(this.opacityTrackBar_Scroll);
            // 
            // opacityLabel
            // 
            this.opacityLabel.AutoSize = true;
            this.opacityLabel.Location = new System.Drawing.Point(4, 142);
            this.opacityLabel.Name = "opacityLabel";
            this.opacityLabel.Size = new System.Drawing.Size(41, 12);
            this.opacityLabel.TabIndex = 15;
            this.opacityLabel.Text = "透明度";
            this.opacityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 334);
            this.Controls.Add(this.previewDumpTextBoxGroupBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.returnDefaultButton);
            this.Controls.Add(this.logFolderLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.logFolderDialogOpenButton);
            this.Controls.Add(this.logFolderTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SettingForm";
            this.Text = "設定";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingForm_FormClosing);
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.previewDumpTextBoxGroupBox.ResumeLayout(false);
            this.previewDumpTextBoxGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opacityTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox logFolderTextBox;
        private System.Windows.Forms.Button logFolderDialogOpenButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label logFolderLabel;
        private System.Windows.Forms.Button returnDefaultButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox previewDumpTextBoxGroupBox;
        private System.Windows.Forms.Button opacityChangeButton;
        private System.Windows.Forms.Button backColorDialogOpenButton;
        private System.Windows.Forms.TextBox previewDumpTextBox;
        private System.Windows.Forms.Button fontDialogOpenButton;
        private System.Windows.Forms.TrackBar opacityTrackBar;
        private System.Windows.Forms.Label opacityLabel;
    }
}