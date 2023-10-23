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
            this.lbVList = new System.Windows.Forms.ListBox();
            this.lvTaskList = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbAddList = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteList = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbDeleteTask = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbVList
            // 
            this.lbVList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbVList.FormattingEnabled = true;
            this.lbVList.ItemHeight = 17;
            this.lbVList.Location = new System.Drawing.Point(0, 25);
            this.lbVList.Name = "lbVList";
            this.lbVList.Size = new System.Drawing.Size(200, 425);
            this.lbVList.TabIndex = 0;
            // 
            // lvTaskList
            // 
            this.lvTaskList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTaskList.Location = new System.Drawing.Point(0, 25);
            this.lvTaskList.Name = "lvTaskList";
            this.lvTaskList.Size = new System.Drawing.Size(600, 425);
            this.lvTaskList.TabIndex = 1;
            this.lvTaskList.UseCompatibleStateImageBehavior = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbVList);
            this.panel1.Controls.Add(this.toolStrip2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 450);
            this.panel1.TabIndex = 2;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddList,
            this.tsbDeleteList});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(200, 25);
            this.toolStrip2.TabIndex = 3;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsbAddList
            // 
            this.tsbAddList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddList.Image = global::YT4k.Properties.Resources.Add;
            this.tsbAddList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddList.Name = "tsbAddList";
            this.tsbAddList.Size = new System.Drawing.Size(23, 22);
            this.tsbAddList.Text = "toolStripButton1";
            this.tsbAddList.ToolTipText = "新增列表";
            this.tsbAddList.Click += new System.EventHandler(this.tsbAddList_Click);
            // 
            // tsbDeleteList
            // 
            this.tsbDeleteList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDeleteList.Image = global::YT4k.Properties.Resources.Delete;
            this.tsbDeleteList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteList.Name = "tsbDeleteList";
            this.tsbDeleteList.Size = new System.Drawing.Size(23, 22);
            this.tsbDeleteList.Text = "toolStripButton2";
            this.tsbDeleteList.ToolTipText = "删除列表";
            this.tsbDeleteList.Click += new System.EventHandler(this.tsbDeleteList_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lvTaskList);
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(200, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(600, 450);
            this.panel2.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbDeleteTask});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(600, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbDeleteTask
            // 
            this.tsbDeleteTask.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDeleteTask.Image = global::YT4k.Properties.Resources.Delete;
            this.tsbDeleteTask.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteTask.Name = "tsbDeleteTask";
            this.tsbDeleteTask.Size = new System.Drawing.Size(23, 22);
            this.tsbDeleteTask.Text = "toolStripButton2";
            this.tsbDeleteTask.ToolTipText = "删除任务";
            this.tsbDeleteTask.Click += new System.EventHandler(this.tsbDeleteTask_Click);
            // 
            // FrmTaskList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmTaskList";
            this.Text = "FrmTaskList";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

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
    }
}