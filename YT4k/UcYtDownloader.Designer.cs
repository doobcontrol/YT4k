namespace YT4k
{
    partial class UcYtDownloader
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelPogress = new System.Windows.Forms.Panel();
            this.labelPogress = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelVedioUri = new System.Windows.Forms.Label();
            this.labelVedioInfo = new System.Windows.Forms.Label();
            this.labelMsg = new System.Windows.Forms.Label();
            this.panelPogress.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPogress
            // 
            this.panelPogress.Controls.Add(this.labelPogress);
            this.panelPogress.Controls.Add(this.progressBar1);
            this.panelPogress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPogress.Location = new System.Drawing.Point(0, 66);
            this.panelPogress.Name = "panelPogress";
            this.panelPogress.Size = new System.Drawing.Size(849, 29);
            this.panelPogress.TabIndex = 3;
            // 
            // labelPogress
            // 
            this.labelPogress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPogress.Location = new System.Drawing.Point(0, 0);
            this.labelPogress.Name = "labelPogress";
            this.labelPogress.Size = new System.Drawing.Size(849, 23);
            this.labelPogress.TabIndex = 5;
            this.labelPogress.Text = "label2";
            this.labelPogress.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 23);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(849, 6);
            this.progressBar1.TabIndex = 4;
            // 
            // labelVedioUri
            // 
            this.labelVedioUri.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelVedioUri.Location = new System.Drawing.Point(0, 0);
            this.labelVedioUri.Name = "labelVedioUri";
            this.labelVedioUri.Size = new System.Drawing.Size(849, 17);
            this.labelVedioUri.TabIndex = 4;
            this.labelVedioUri.Text = "label1";
            // 
            // labelVedioInfo
            // 
            this.labelVedioInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelVedioInfo.Location = new System.Drawing.Point(0, 34);
            this.labelVedioInfo.Name = "labelVedioInfo";
            this.labelVedioInfo.Size = new System.Drawing.Size(849, 32);
            this.labelVedioInfo.TabIndex = 5;
            this.labelVedioInfo.Text = "label2";
            // 
            // labelMsg
            // 
            this.labelMsg.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelMsg.Location = new System.Drawing.Point(0, 17);
            this.labelMsg.Name = "labelMsg";
            this.labelMsg.Size = new System.Drawing.Size(849, 17);
            this.labelMsg.TabIndex = 6;
            this.labelMsg.Text = "label1";
            // 
            // UcYtDownloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelVedioInfo);
            this.Controls.Add(this.labelMsg);
            this.Controls.Add(this.labelVedioUri);
            this.Controls.Add(this.panelPogress);
            this.Name = "UcYtDownloader";
            this.Size = new System.Drawing.Size(849, 95);
            this.panelPogress.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelPogress;
        private Label labelPogress;
        private ProgressBar progressBar1;
        private Label labelVedioUri;
        private Label labelVedioInfo;
        private Label labelMsg;
    }
}
