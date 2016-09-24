namespace logtran
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dumpTextBox = new System.Windows.Forms.TextBox();
            this.styleChangeButton = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.monitoringStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.moniterringButton = new System.Windows.Forms.Button();
            this.logClearButton = new System.Windows.Forms.Button();
            this.ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monitoringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.styleChangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LogClearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.setingFormOpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.watchTimer = new System.Windows.Forms.Timer(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dumpTextBox
            // 
            this.dumpTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dumpTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(30)))), ((int)(((byte)(10)))));
            this.dumpTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dumpTextBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dumpTextBox.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dumpTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(250)))), ((int)(((byte)(244)))));
            this.dumpTextBox.Location = new System.Drawing.Point(0, 24);
            this.dumpTextBox.Multiline = true;
            this.dumpTextBox.Name = "dumpTextBox";
            this.dumpTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.dumpTextBox.Size = new System.Drawing.Size(616, 229);
            this.dumpTextBox.TabIndex = 3;
            this.dumpTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dumpTextBox_KeyDown);
            // 
            // styleChangeButton
            // 
            this.styleChangeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.styleChangeButton.AutoSize = true;
            this.styleChangeButton.BackColor = System.Drawing.SystemColors.Control;
            this.styleChangeButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.styleChangeButton.FlatAppearance.BorderSize = 0;
            this.styleChangeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.styleChangeButton.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.styleChangeButton.Location = new System.Drawing.Point(379, 254);
            this.styleChangeButton.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.styleChangeButton.Name = "styleChangeButton";
            this.styleChangeButton.Size = new System.Drawing.Size(377, 27);
            this.styleChangeButton.TabIndex = 4;
            this.styleChangeButton.Text = "形状変更(&T)";
            this.styleChangeButton.UseVisualStyleBackColor = false;
            this.styleChangeButton.Click += new System.EventHandler(this.styleChangeButton_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.SystemColors.ControlLight;
            this.statusStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.monitoringStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 259);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(784, 22);
            this.statusStrip.TabIndex = 5;
            this.statusStrip.Text = "statusStrip1";
            // 
            // monitoringStatusLabel
            // 
            this.monitoringStatusLabel.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.monitoringStatusLabel.Margin = new System.Windows.Forms.Padding(0, 2, 0, 4);
            this.monitoringStatusLabel.Name = "monitoringStatusLabel";
            this.monitoringStatusLabel.Size = new System.Drawing.Size(71, 16);
            this.monitoringStatusLabel.Text = "起動しました";
            // 
            // moniterringButton
            // 
            this.moniterringButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.moniterringButton.AutoSize = true;
            this.moniterringButton.BackColor = System.Drawing.SystemColors.Control;
            this.moniterringButton.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.moniterringButton.ForeColor = System.Drawing.Color.Green;
            this.moniterringButton.Location = new System.Drawing.Point(622, 27);
            this.moniterringButton.Name = "moniterringButton";
            this.moniterringButton.Size = new System.Drawing.Size(150, 30);
            this.moniterringButton.TabIndex = 6;
            this.moniterringButton.Text = "監視を開始する";
            this.moniterringButton.UseVisualStyleBackColor = false;
            this.moniterringButton.Click += new System.EventHandler(this.moniterringButton_Click);
            // 
            // logClearButton
            // 
            this.logClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.logClearButton.AutoSize = true;
            this.logClearButton.BackColor = System.Drawing.SystemColors.Control;
            this.logClearButton.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.logClearButton.Location = new System.Drawing.Point(622, 215);
            this.logClearButton.Name = "logClearButton";
            this.logClearButton.Size = new System.Drawing.Size(150, 30);
            this.logClearButton.TabIndex = 7;
            this.logClearButton.Text = "ログクリア(&C)";
            this.logClearButton.UseVisualStyleBackColor = false;
            this.logClearButton.Click += new System.EventHandler(this.logClearButton_Click);
            // 
            // ToolStripMenuItem
            // 
            this.ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.monitoringToolStripMenuItem,
            this.styleChangeToolStripMenuItem,
            this.LogClearToolStripMenuItem,
            this.toolStripSeparator1,
            this.setingFormOpenToolStripMenuItem});
            this.ToolStripMenuItem.Name = "ToolStripMenuItem";
            this.ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.M)));
            this.ToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.ToolStripMenuItem.Text = "メニュー(&M)";
            // 
            // monitoringToolStripMenuItem
            // 
            this.monitoringToolStripMenuItem.ForeColor = System.Drawing.Color.Green;
            this.monitoringToolStripMenuItem.Name = "monitoringToolStripMenuItem";
            this.monitoringToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.O)));
            this.monitoringToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.monitoringToolStripMenuItem.Text = "監視を開始する(&O)";
            this.monitoringToolStripMenuItem.Click += new System.EventHandler(this.monitoringStartToolStripMenuItem_Click);
            // 
            // styleChangeToolStripMenuItem
            // 
            this.styleChangeToolStripMenuItem.Name = "styleChangeToolStripMenuItem";
            this.styleChangeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.T)));
            this.styleChangeToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.styleChangeToolStripMenuItem.Text = "形状変更(&T)";
            this.styleChangeToolStripMenuItem.Click += new System.EventHandler(this.styleChangeToolStripMenuItem_Click);
            // 
            // LogClearToolStripMenuItem
            // 
            this.LogClearToolStripMenuItem.Name = "LogClearToolStripMenuItem";
            this.LogClearToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.LogClearToolStripMenuItem.Text = "ログクリア(&C)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(203, 6);
            // 
            // setingFormOpenToolStripMenuItem
            // 
            this.setingFormOpenToolStripMenuItem.Name = "setingFormOpenToolStripMenuItem";
            this.setingFormOpenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.setingFormOpenToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.setingFormOpenToolStripMenuItem.Text = "設定(&S)";
            this.setingFormOpenToolStripMenuItem.Click += new System.EventHandler(this.setingFormOpenToolStripMenuItem_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(784, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // watchTimer
            // 
            this.watchTimer.Interval = 500;
            this.watchTimer.Tick += new System.EventHandler(this.watchTimer_Tick);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBox1.Location = new System.Drawing.Point(637, 63);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(119, 27);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "最前面に表示";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(784, 281);
            this.Controls.Add(this.styleChangeButton);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.moniterringButton);
            this.Controls.Add(this.logClearButton);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.dumpTextBox);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(16, 200);
            this.Name = "MainForm";
            this.Opacity = 0.95D;
            this.Text = "Sloppy";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox dumpTextBox;
        private System.Windows.Forms.Button styleChangeButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel monitoringStatusLabel;
        private System.Windows.Forms.Button moniterringButton;
        private System.Windows.Forms.Button logClearButton;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monitoringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem styleChangeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LogClearToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem setingFormOpenToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.Timer watchTimer;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

