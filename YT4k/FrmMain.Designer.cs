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
            components = new System.ComponentModel.Container();
            panelDownloaderContainer = new Panel();
            statusStrip1 = new StatusStrip();
            statusLabelMsg = new ToolStripStatusLabel();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            tsslCurrentList = new ToolStripStatusLabel();
            tsslNextList = new ToolStripStatusLabel();
            panelToolBar = new Panel();
            panel2 = new Panel();
            btnOpenRecordFileFold = new Button();
            btnPasteTask = new Button();
            btnOpenTaskManage = new Button();
            cbCurrVListName = new ComboBox();
            nudConcurrent = new NumericUpDown();
            toolTip1 = new ToolTip(components);
            statusStrip1.SuspendLayout();
            panelToolBar.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudConcurrent).BeginInit();
            SuspendLayout();
            // 
            // panelDownloaderContainer
            // 
            panelDownloaderContainer.BackColor = SystemColors.ControlDark;
            panelDownloaderContainer.Dock = DockStyle.Fill;
            panelDownloaderContainer.Location = new Point(0, 31);
            panelDownloaderContainer.Name = "panelDownloaderContainer";
            panelDownloaderContainer.Size = new Size(800, 397);
            panelDownloaderContainer.TabIndex = 0;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { statusLabelMsg, toolStripStatusLabel1, tsslCurrentList, tsslNextList });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // statusLabelMsg
            // 
            statusLabelMsg.Name = "statusLabelMsg";
            statusLabelMsg.Size = new Size(131, 17);
            statusLabelMsg.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.AutoSize = false;
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.RightToLeft = RightToLeft.No;
            toolStripStatusLabel1.Size = new Size(392, 17);
            toolStripStatusLabel1.Spring = true;
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // tsslCurrentList
            // 
            tsslCurrentList.Name = "tsslCurrentList";
            tsslCurrentList.Size = new Size(131, 17);
            tsslCurrentList.Text = "toolStripStatusLabel2";
            tsslCurrentList.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tsslNextList
            // 
            tsslNextList.Name = "tsslNextList";
            tsslNextList.Size = new Size(131, 17);
            tsslNextList.Text = "toolStripStatusLabel3";
            tsslNextList.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelToolBar
            // 
            panelToolBar.BackColor = SystemColors.GradientInactiveCaption;
            panelToolBar.Controls.Add(panel2);
            panelToolBar.Controls.Add(btnPasteTask);
            panelToolBar.Controls.Add(btnOpenTaskManage);
            panelToolBar.Controls.Add(cbCurrVListName);
            panelToolBar.Controls.Add(nudConcurrent);
            panelToolBar.Dock = DockStyle.Top;
            panelToolBar.Location = new Point(0, 0);
            panelToolBar.Name = "panelToolBar";
            panelToolBar.Size = new Size(800, 31);
            panelToolBar.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnOpenRecordFileFold);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(769, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(31, 31);
            panel2.TabIndex = 13;
            // 
            // btnOpenRecordFileFold
            // 
            btnOpenRecordFileFold.AutoSize = true;
            btnOpenRecordFileFold.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnOpenRecordFileFold.Image = Properties.Resources.FolderOpenLightBlue;
            btnOpenRecordFileFold.Location = new Point(3, 3);
            btnOpenRecordFileFold.Name = "btnOpenRecordFileFold";
            btnOpenRecordFileFold.Size = new Size(22, 22);
            btnOpenRecordFileFold.TabIndex = 7;
            toolTip1.SetToolTip(btnOpenRecordFileFold, "打开下载文件目录");
            btnOpenRecordFileFold.UseVisualStyleBackColor = true;
            btnOpenRecordFileFold.Click += btnOpenRecordFileFold_Click;
            // 
            // btnPasteTask
            // 
            btnPasteTask.AutoSize = true;
            btnPasteTask.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnPasteTask.Image = Properties.Resources.Paste;
            btnPasteTask.Location = new Point(208, 4);
            btnPasteTask.Name = "btnPasteTask";
            btnPasteTask.Size = new Size(22, 22);
            btnPasteTask.TabIndex = 12;
            btnPasteTask.UseVisualStyleBackColor = true;
            btnPasteTask.Click += btnPasteTask_Click;
            // 
            // btnOpenTaskManage
            // 
            btnOpenTaskManage.AutoSize = true;
            btnOpenTaskManage.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnOpenTaskManage.Image = Properties.Resources.ListBox;
            btnOpenTaskManage.Location = new Point(180, 4);
            btnOpenTaskManage.Name = "btnOpenTaskManage";
            btnOpenTaskManage.Size = new Size(22, 22);
            btnOpenTaskManage.TabIndex = 11;
            btnOpenTaskManage.UseVisualStyleBackColor = true;
            btnOpenTaskManage.Click += btnOpenTaskManage_Click;
            // 
            // cbCurrVListName
            // 
            cbCurrVListName.FormattingEnabled = true;
            cbCurrVListName.Location = new Point(3, 3);
            cbCurrVListName.Name = "cbCurrVListName";
            cbCurrVListName.Size = new Size(121, 25);
            cbCurrVListName.TabIndex = 9;
            // 
            // nudConcurrent
            // 
            nudConcurrent.Location = new Point(130, 4);
            nudConcurrent.Name = "nudConcurrent";
            nudConcurrent.Size = new Size(44, 23);
            nudConcurrent.TabIndex = 10;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelDownloaderContainer);
            Controls.Add(panelToolBar);
            Controls.Add(statusStrip1);
            Name = "FrmMain";
            Text = "FrmMain";
            FormClosing += FrmMain_FormClosingAsync;
            Load += FrmMain_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panelToolBar.ResumeLayout(false);
            panelToolBar.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudConcurrent).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel tsslCurrentList;
        private ToolStripStatusLabel tsslNextList;
    }
}