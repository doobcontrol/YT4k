namespace YT4k
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelVdeioUri = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelPogress = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelVdeioUri
            // 
            this.labelVdeioUri.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelVdeioUri.Location = new System.Drawing.Point(0, 0);
            this.labelVdeioUri.Name = "labelVdeioUri";
            this.labelVdeioUri.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.labelVdeioUri.Size = new System.Drawing.Size(936, 27);
            this.labelVdeioUri.TabIndex = 0;
            this.labelVdeioUri.Text = "视频链接，点击粘贴";
            this.labelVdeioUri.Click += new System.EventHandler(this.labelVdeioUri_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(936, 98);
            this.label1.TabIndex = 1;
            this.label1.Text = "视频信息";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(936, 135);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelPogress);
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 98);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(936, 37);
            this.panel2.TabIndex = 2;
            // 
            // labelPogress
            // 
            this.labelPogress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPogress.Location = new System.Drawing.Point(0, 0);
            this.labelPogress.Name = "labelPogress";
            this.labelPogress.Size = new System.Drawing.Size(936, 23);
            this.labelPogress.TabIndex = 5;
            this.labelPogress.Text = "label2";
            this.labelPogress.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 23);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(936, 14);
            this.progressBar1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 162);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelVdeioUri);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label labelVdeioUri;
        private Label label1;
        private Panel panel1;
        private Panel panel2;
        private Label labelPogress;
        private ProgressBar progressBar1;
    }
}