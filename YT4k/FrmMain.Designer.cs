namespace YT4k
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.panelDownloaderContainer = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabelMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelToolBar = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnOpenRecordFileFold = new System.Windows.Forms.Button();
            this.btnPasteTask = new System.Windows.Forms.Button();
            this.btnOpenTaskManage = new System.Windows.Forms.Button();
            this.cbCurrVListName = new System.Windows.Forms.ComboBox();
            this.nudConcurrent = new System.Windows.Forms.NumericUpDown();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1.SuspendLayout();
            this.panelToolBar.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudConcurrent)).BeginInit();
            this.SuspendLayout();
            // 
            // panelDownloaderContainer
            // 
            this.panelDownloaderContainer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelDownloaderContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDownloaderContainer.Location = new System.Drawing.Point(0, 31);
            this.panelDownloaderContainer.Name = "panelDownloaderContainer";
            this.panelDownloaderContainer.Size = new System.Drawing.Size(800, 397);
            this.panelDownloaderContainer.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabelMsg});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabelMsg
            // 
            this.statusLabelMsg.Name = "statusLabelMsg";
            this.statusLabelMsg.Size = new System.Drawing.Size(131, 17);
            this.statusLabelMsg.Text = "toolStripStatusLabel1";
            // 
            // panelToolBar
            // 
            this.panelToolBar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelToolBar.Controls.Add(this.panel2);
            this.panelToolBar.Controls.Add(this.btnPasteTask);
            this.panelToolBar.Controls.Add(this.btnOpenTaskManage);
            this.panelToolBar.Controls.Add(this.cbCurrVListName);
            this.panelToolBar.Controls.Add(this.nudConcurrent);
            this.panelToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelToolBar.Location = new System.Drawing.Point(0, 0);
            this.panelToolBar.Name = "panelToolBar";
            this.panelToolBar.Size = new System.Drawing.Size(800, 31);
            this.panelToolBar.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnOpenRecordFileFold);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(769, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(31, 31);
            this.panel2.TabIndex = 13;
            // 
            // btnOpenRecordFileFold
            // 
            this.btnOpenRecordFileFold.AutoSize = true;
            this.btnOpenRecordFileFold.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOpenRecordFileFold.Image = global::YT4k.Properties.Resources.FolderOpenLightBlue;
            this.btnOpenRecordFileFold.Location = new System.Drawing.Point(3, 3);
            this.btnOpenRecordFileFold.Name = "btnOpenRecordFileFold";
            this.btnOpenRecordFileFold.Size = new System.Drawing.Size(22, 22);
            this.btnOpenRecordFileFold.TabIndex = 7;
            this.toolTip1.SetToolTip(this.btnOpenRecordFileFold, "打开下载文件目录");
            this.btnOpenRecordFileFold.UseVisualStyleBackColor = true;
            this.btnOpenRecordFileFold.Click += new System.EventHandler(this.btnOpenRecordFileFold_Click);
            // 
            // btnPasteTask
            // 
            this.btnPasteTask.AutoSize = true;
            this.btnPasteTask.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPasteTask.Image = global::YT4k.Properties.Resources.Paste;
            this.btnPasteTask.Location = new System.Drawing.Point(208, 4);
            this.btnPasteTask.Name = "btnPasteTask";
            this.btnPasteTask.Size = new System.Drawing.Size(22, 22);
            this.btnPasteTask.TabIndex = 12;
            this.btnPasteTask.UseVisualStyleBackColor = true;
            this.btnPasteTask.Click += new System.EventHandler(this.btnPasteTask_Click);
            // 
            // btnOpenTaskManage
            // 
            this.btnOpenTaskManage.AutoSize = true;
            this.btnOpenTaskManage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOpenTaskManage.Image = global::YT4k.Properties.Resources.ListBox;
            this.btnOpenTaskManage.Location = new System.Drawing.Point(180, 4);
            this.btnOpenTaskManage.Name = "btnOpenTaskManage";
            this.btnOpenTaskManage.Size = new System.Drawing.Size(22, 22);
            this.btnOpenTaskManage.TabIndex = 11;
            this.btnOpenTaskManage.UseVisualStyleBackColor = true;
            this.btnOpenTaskManage.Click += new System.EventHandler(this.btnOpenTaskManage_Click);
            // 
            // cbCurrVListName
            // 
            this.cbCurrVListName.FormattingEnabled = true;
            this.cbCurrVListName.Location = new System.Drawing.Point(3, 3);
            this.cbCurrVListName.Name = "cbCurrVListName";
            this.cbCurrVListName.Size = new System.Drawing.Size(121, 25);
            this.cbCurrVListName.TabIndex = 9;
            // 
            // nudConcurrent
            // 
            this.nudConcurrent.Location = new System.Drawing.Point(130, 4);
            this.nudConcurrent.Name = "nudConcurrent";
            this.nudConcurrent.Size = new System.Drawing.Size(44, 23);
            this.nudConcurrent.TabIndex = 10;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelDownloaderContainer);
            this.Controls.Add(this.panelToolBar);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosingAsync);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelToolBar.ResumeLayout(false);
            this.panelToolBar.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudConcurrent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panelDownloaderContainer;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusLabelMsg;
        private Panel panelToolBar;
        private Button btnOpenRecordFileFold;
        private ToolTip toolTip1;
        private ComboBox cbCurrVListName;
        private NumericUpDown nudConcurrent;
        private Button btnOpenTaskManage;
        private Button btnPasteTask;
        private Panel panel2;
    }
}