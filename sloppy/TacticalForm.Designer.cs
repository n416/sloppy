namespace sloppy
{
    partial class TacticalForm
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.label = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeSettingButton = new System.Windows.Forms.Button();
            this.inputText = new System.Windows.Forms.TextBox();
            this.inputLabel = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.timerPreview = new System.Windows.Forms.Label();
            this.statusResetButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.BackgroundColor = System.Drawing.Color.Black;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.ColumnHeadersVisible = false;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.label,
            this.time});
            this.dataGridView.Location = new System.Drawing.Point(0, 73);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidth = 38;
            this.dataGridView.RowTemplate.Height = 21;
            this.dataGridView.Size = new System.Drawing.Size(258, 288);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            this.dataGridView.Resize += new System.EventHandler(this.dataGridView1_Resize);
            // 
            // label
            // 
            this.label.HeaderText = "label";
            this.label.Name = "label";
            this.label.ReadOnly = true;
            // 
            // time
            // 
            this.time.HeaderText = "time";
            this.time.Name = "time";
            this.time.ReadOnly = true;
            // 
            // timeSettingButton
            // 
            this.timeSettingButton.Location = new System.Drawing.Point(125, 3);
            this.timeSettingButton.Name = "timeSettingButton";
            this.timeSettingButton.Size = new System.Drawing.Size(79, 33);
            this.timeSettingButton.TabIndex = 7;
            this.timeSettingButton.Text = "時刻合わせ";
            this.timeSettingButton.UseVisualStyleBackColor = true;
            this.timeSettingButton.Click += new System.EventHandler(this.timeSettingButton_Click);
            // 
            // inputText
            // 
            this.inputText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputText.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.inputText.Location = new System.Drawing.Point(36, 4);
            this.inputText.Name = "inputText";
            this.inputText.Size = new System.Drawing.Size(82, 31);
            this.inputText.TabIndex = 6;
            this.inputText.Text = "1950";
            this.inputText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // inputLabel
            // 
            this.inputLabel.AutoSize = true;
            this.inputLabel.Location = new System.Drawing.Point(5, 14);
            this.inputLabel.Name = "inputLabel";
            this.inputLabel.Size = new System.Drawing.Size(29, 12);
            this.inputLabel.TabIndex = 5;
            this.inputLabel.Text = "時刻";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // timerPreview
            // 
            this.timerPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.timerPreview.BackColor = System.Drawing.Color.Black;
            this.timerPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.timerPreview.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.timerPreview.ForeColor = System.Drawing.SystemColors.GrayText;
            this.timerPreview.Location = new System.Drawing.Point(0, 39);
            this.timerPreview.Name = "timerPreview";
            this.timerPreview.Padding = new System.Windows.Forms.Padding(5);
            this.timerPreview.Size = new System.Drawing.Size(258, 34);
            this.timerPreview.TabIndex = 8;
            this.timerPreview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusResetButton
            // 
            this.statusResetButton.Location = new System.Drawing.Point(208, 3);
            this.statusResetButton.Name = "statusResetButton";
            this.statusResetButton.Size = new System.Drawing.Size(46, 33);
            this.statusResetButton.TabIndex = 9;
            this.statusResetButton.Text = "リセット";
            this.statusResetButton.UseVisualStyleBackColor = true;
            this.statusResetButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // TacticalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 361);
            this.ControlBox = false;
            this.Controls.Add(this.statusResetButton);
            this.Controls.Add(this.timerPreview);
            this.Controls.Add(this.timeSettingButton);
            this.Controls.Add(this.inputText);
            this.Controls.Add(this.inputLabel);
            this.Controls.Add(this.dataGridView);
            this.Name = "TacticalForm";
            this.Opacity = 0.95D;
            this.Text = "TacticalForm";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TacticalForm_FormClosing);
            this.Load += new System.EventHandler(this.TacticalForm_Load);
            this.Shown += new System.EventHandler(this.TacticalForm_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TacticalForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TacticalForm_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.Button timeSettingButton;
        private System.Windows.Forms.TextBox inputText;
        private System.Windows.Forms.Label inputLabel;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label timerPreview;
        private System.Windows.Forms.DataGridViewTextBoxColumn label;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.Button statusResetButton;
    }
}