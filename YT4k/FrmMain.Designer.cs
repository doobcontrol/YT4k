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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.panelDownloaderContainer = new System.Windows.Forms.Panel();
            this.labelStartTask = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabelMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.nudConcurrent = new System.Windows.Forms.NumericUpDown();
            this.cbCurrVListName = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnOpenRecordFileFold = new System.Windows.Forms.Button();
            this.checkBoxClipboardMonitor = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnOpenTaskManage = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudConcurrent)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDownloaderContainer
            // 
            this.panelDownloaderContainer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelDownloaderContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDownloaderContainer.Location = new System.Drawing.Point(0, 54);
            this.panelDownloaderContainer.Name = "panelDownloaderContainer";
            this.panelDownloaderContainer.Size = new System.Drawing.Size(800, 374);
            this.panelDownloaderContainer.TabIndex = 0;
            // 
            // labelStartTask
            // 
            this.labelStartTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelStartTask.Location = new System.Drawing.Point(0, 30);
            this.labelStartTask.Name = "labelStartTask";
            this.labelStartTask.Size = new System.Drawing.Size(800, 24);
            this.labelStartTask.TabIndex = 1;
            this.labelStartTask.Text = "label1";
            this.labelStartTask.Click += new System.EventHandler(this.labelStartTask_Click);
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.labelStartTask);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 54);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnOpenTaskManage);
            this.panel2.Controls.Add(this.nudConcurrent);
            this.panel2.Controls.Add(this.cbCurrVListName);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.checkBoxClipboardMonitor);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 30);
            this.panel2.TabIndex = 3;
            // 
            // nudConcurrent
            // 
            this.nudConcurrent.Location = new System.Drawing.Point(260, 3);
            this.nudConcurrent.Name = "nudConcurrent";
            this.nudConcurrent.Size = new System.Drawing.Size(44, 23);
            this.nudConcurrent.TabIndex = 10;
            // 
            // cbCurrVListName
            // 
            this.cbCurrVListName.FormattingEnabled = true;
            this.cbCurrVListName.Location = new System.Drawing.Point(133, 2);
            this.cbCurrVListName.Name = "cbCurrVListName";
            this.cbCurrVListName.Size = new System.Drawing.Size(121, 25);
            this.cbCurrVListName.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnOpenRecordFileFold);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(768, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(32, 30);
            this.panel3.TabIndex = 8;
            // 
            // btnOpenRecordFileFold
            // 
            this.btnOpenRecordFileFold.AutoSize = true;
            this.btnOpenRecordFileFold.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOpenRecordFileFold.Image = global::YT4k.Properties.Resources.FolderOpenLightBlue;
            this.btnOpenRecordFileFold.Location = new System.Drawing.Point(3, 5);
            this.btnOpenRecordFileFold.Name = "btnOpenRecordFileFold";
            this.btnOpenRecordFileFold.Size = new System.Drawing.Size(22, 22);
            this.btnOpenRecordFileFold.TabIndex = 7;
            this.toolTip1.SetToolTip(this.btnOpenRecordFileFold, "打开下载文件目录");
            this.btnOpenRecordFileFold.UseVisualStyleBackColor = true;
            this.btnOpenRecordFileFold.Click += new System.EventHandler(this.btnOpenRecordFileFold_Click);
            // 
            // checkBoxClipboardMonitor
            // 
            this.checkBoxClipboardMonitor.AutoSize = true;
            this.checkBoxClipboardMonitor.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkBoxClipboardMonitor.Location = new System.Drawing.Point(0, 0);
            this.checkBoxClipboardMonitor.Name = "checkBoxClipboardMonitor";
            this.checkBoxClipboardMonitor.Size = new System.Drawing.Size(87, 30);
            this.checkBoxClipboardMonitor.TabIndex = 2;
            this.checkBoxClipboardMonitor.Text = "监视剪贴板";
            this.checkBoxClipboardMonitor.UseVisualStyleBackColor = true;
            // 
            // btnOpenTaskManage
            // 
            this.btnOpenTaskManage.AutoSize = true;
            this.btnOpenTaskManage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOpenTaskManage.Image = global::YT4k.Properties.Resources.ListBox;
            this.btnOpenTaskManage.Location = new System.Drawing.Point(389, 4);
            this.btnOpenTaskManage.Name = "btnOpenTaskManage";
            this.btnOpenTaskManage.Size = new System.Drawing.Size(22, 22);
            this.btnOpenTaskManage.TabIndex = 11;
            this.btnOpenTaskManage.UseVisualStyleBackColor = true;
            this.btnOpenTaskManage.Click += new System.EventHandler(this.btnOpenTaskManage_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelDownloaderContainer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosingAsync);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudConcurrent)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panelDownloaderContainer;
        private Label labelStartTask;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusLabelMsg;
        private Panel panel1;
        private CheckBox checkBoxClipboardMonitor;
        private Panel panel2;
        private Panel panel3;
        private Button btnOpenRecordFileFold;
        private ToolTip toolTip1;
        private ComboBox cbCurrVListName;
        private NumericUpDown nudConcurrent;
        private Button btnOpenTaskManage;
    }
}