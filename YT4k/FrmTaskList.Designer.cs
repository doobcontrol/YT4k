namespace YT4k
{
    partial class FrmTaskList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTaskList));
            lbVList = new ListBox();
            lvTaskList = new ListView();
            panel1 = new Panel();
            toolStrip2 = new ToolStrip();
            tsbAddList = new ToolStripButton();
            tsbDeleteList = new ToolStripButton();
            tsbSetCurrentList = new ToolStripButton();
            tsbSetNextList = new ToolStripButton();
            panel2 = new Panel();
            toolStrip1 = new ToolStrip();
            tsbDeleteTask = new ToolStripButton();
            txtSearch = new ToolStripTextBox();
            tsbSearch = new ToolStripButton();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            panel1.SuspendLayout();
            toolStrip2.SuspendLayout();
            panel2.SuspendLayout();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // lbVList
            // 
            lbVList.Dock = DockStyle.Fill;
            lbVList.FormattingEnabled = true;
            lbVList.ItemHeight = 17;
            lbVList.Location = new Point(0, 25);
            lbVList.Name = "lbVList";
            lbVList.Size = new Size(222, 403);
            lbVList.TabIndex = 0;
            // 
            // lvTaskList
            // 
            lvTaskList.Dock = DockStyle.Fill;
            lvTaskList.Location = new Point(0, 25);
            lvTaskList.Name = "lvTaskList";
            lvTaskList.Size = new Size(578, 403);
            lvTaskList.TabIndex = 1;
            lvTaskList.UseCompatibleStateImageBehavior = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(lbVList);
            panel1.Controls.Add(toolStrip2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(222, 428);
            panel1.TabIndex = 2;
            // 
            // toolStrip2
            // 
            toolStrip2.Items.AddRange(new ToolStripItem[] { tsbAddList, tsbDeleteList, tsbSetCurrentList, tsbSetNextList });
            toolStrip2.Location = new Point(0, 0);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(222, 25);
            toolStrip2.TabIndex = 3;
            toolStrip2.Text = "toolStrip2";
            // 
            // tsbAddList
            // 
            tsbAddList.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbAddList.Image = Properties.Resources.Add;
            tsbAddList.ImageTransparentColor = Color.Magenta;
            tsbAddList.Name = "tsbAddList";
            tsbAddList.Size = new Size(23, 22);
            tsbAddList.Text = "toolStripButton1";
            tsbAddList.ToolTipText = "新增列表";
            tsbAddList.Click += tsbAddList_Click;
            // 
            // tsbDeleteList
            // 
            tsbDeleteList.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbDeleteList.Image = Properties.Resources.Delete;
            tsbDeleteList.ImageTransparentColor = Color.Magenta;
            tsbDeleteList.Name = "tsbDeleteList";
            tsbDeleteList.Size = new Size(23, 22);
            tsbDeleteList.Text = "toolStripButton2";
            tsbDeleteList.ToolTipText = "删除列表";
            tsbDeleteList.Click += tsbDeleteList_Click;
            // 
            // tsbSetCurrentList
            // 
            tsbSetCurrentList.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbSetCurrentList.Image = (Image)resources.GetObject("tsbSetCurrentList.Image");
            tsbSetCurrentList.ImageTransparentColor = Color.Magenta;
            tsbSetCurrentList.Name = "tsbSetCurrentList";
            tsbSetCurrentList.Size = new Size(23, 22);
            tsbSetCurrentList.Text = "toolStripButton2";
            tsbSetCurrentList.ToolTipText = "删除列表";
            tsbSetCurrentList.Click += tsbSetCurrentList_Click;
            // 
            // tsbSetNextList
            // 
            tsbSetNextList.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbSetNextList.Image = (Image)resources.GetObject("tsbSetNextList.Image");
            tsbSetNextList.ImageTransparentColor = Color.Magenta;
            tsbSetNextList.Name = "tsbSetNextList";
            tsbSetNextList.Size = new Size(23, 22);
            tsbSetNextList.Text = "toolStripButton2";
            tsbSetNextList.ToolTipText = "删除列表";
            tsbSetNextList.Click += tsbSetNextList_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(lvTaskList);
            panel2.Controls.Add(toolStrip1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(222, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(578, 428);
            panel2.TabIndex = 3;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbDeleteTask, txtSearch, tsbSearch });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(578, 25);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // tsbDeleteTask
            // 
            tsbDeleteTask.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbDeleteTask.Image = Properties.Resources.Delete;
            tsbDeleteTask.ImageTransparentColor = Color.Magenta;
            tsbDeleteTask.Name = "tsbDeleteTask";
            tsbDeleteTask.Size = new Size(23, 22);
            tsbDeleteTask.Text = "toolStripButton2";
            tsbDeleteTask.ToolTipText = "删除任务";
            tsbDeleteTask.Click += tsbDeleteTask_Click;
            // 
            // txtSearch
            // 
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(100, 25);
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // tsbSearch
            // 
            tsbSearch.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbSearch.Image = (Image)resources.GetObject("tsbSearch.Image");
            tsbSearch.ImageTransparentColor = Color.Magenta;
            tsbSearch.Name = "tsbSearch";
            tsbSearch.Size = new Size(23, 22);
            tsbSearch.Text = "toolStripButton2";
            tsbSearch.ToolTipText = "删除任务";
            tsbSearch.Click += tsbSearch_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 4;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(131, 17);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // FrmTaskList
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            Name = "FrmTaskList";
            Text = "FrmTaskList";
            Load += FrmTaskList_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lbVList;
        private ListView lvTaskList;
        private Panel panel1;
        private ToolStrip toolStrip2;
        private ToolStripButton tsbAddList;
        private ToolStripButton tsbDeleteList;
        private Panel panel2;
        private ToolStrip toolStrip1;
        private ToolStripButton tsbDeleteTask;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripTextBox txtSearch;
        private ToolStripButton tsbSearch;
        private ToolStripButton tsbSetCurrentList;
        private ToolStripButton tsbSetNextList;
    }
}