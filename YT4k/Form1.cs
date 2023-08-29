using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Runtime.Intrinsics.X86;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using VideoLibrary;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace YT4k
{
    public partial class Form1 : Form
    {
        CancellationTokenSource? tokenSource;
        CancellationToken token;

        public Form1()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Text = "无任务";

            panel2.Visible = false;

            if (!Directory.Exists(downloadDir))
            {
                Directory.CreateDirectory(downloadDir);
            }
            
            labelPogress.DoubleClick += cancelDownload_DoubleClick;
        }

        private async void labelVdeioUri_Click(object sender, EventArgs e)
        {
            if (!ControlBox)
            {
                return;
            }

            string uStr = Clipboard.GetText();

            if (uStr.StartsWith("https://www.youtube.com/"))
            {
                labelVdeioUri.Text = uStr;

                ControlBox = false;
                await getVedioInfoAsync(labelVdeioUri.Text);
                ControlBox = true;
            }
            else
            {
                labelVdeioUri.Text = "非法地址:" + uStr;
            }
        }

        private async Task getVedioInfoAsync(string vdeioUri)
        {
            Text = "读取视频信息……";
            label1.Text = "读取视频信息……";
            CustomYouTube youTube = new CustomYouTube(); //YouTube.Default; // starting point for YouTube actions
            
            IEnumerable<YouTubeVideo> videoInfos;
            YouTubeVideo maxResolution;
            try
            {
                videoInfos = await youTube.GetAllVideosAsync(vdeioUri);
                maxResolution = videoInfos.First(i => i.Resolution == videoInfos.Max(j => j.Resolution));
            }
            catch (Exception e)
            {
                labelVdeioUri.Text = e.Message;
                Text = "读取视频信息失败";
                label1.Text = "读取视频信息失败";
                return;
            }
            
            string showStr = "  VedioName：" + maxResolution.FullName;
            showStr += "\r\n  Resolution：" + maxResolution.Resolution.ToString();
            showStr += "\r\n  ContentLength：" + string.Format("{0:n0}", maxResolution.ContentLength);
            showStr += "\r\n  VedioFormat：" + maxResolution.Format.ToString();
            label1.Text = showStr;

            tokenSource = new CancellationTokenSource();
            token = tokenSource.Token;

            Text = "下载中……";
            await Task.Run(
                async () => {
                    bool downloadSucceed = false;

                    try
                    {
                        showPogress(pogressMsgType.show, (int)maxResolution.ContentLength);
                        downloadSucceed = await youTube
                            .CreateDownloadAsync(
                            new Uri(maxResolution.Uri),
                            Path.Combine(downloadDir, maxResolution.FullName),
                            0,
                            (long)maxResolution.ContentLength,
                            new Progress<Tuple<long, long>>((Tuple<long, long> v) =>
                            {
                                showPogress(pogressMsgType.progress,  (int)v.Item1);
                            }),
                            token
                            );

                        if (!downloadSucceed
                            && File.Exists(Path.Combine(downloadDir, maxResolution.FullName)))
                        {
                            File.Delete(Path.Combine(downloadDir, maxResolution.FullName));
                        }
                        showMsg("下载成功：" + downloadSucceed);
                    }
                    catch (Exception e)
                    {
                        if (File.Exists(Path.Combine(downloadDir, maxResolution.FullName)))
                        {
                            File.Delete(Path.Combine(downloadDir, maxResolution.FullName));
                        }
                        showMsg("下载失败（" + e.Message + "）");
                    }
                    showPogress(pogressMsgType.hide, 0);
                }
                );
            Text = "下载结束";
        }

        string downloadDir = "downloadFile";

        private void showPogress(pogressMsgType pmt, int value)
        {
            if (panel2.InvokeRequired)
            {
                panel2.BeginInvoke(() => {
                    showPogress(pmt, value);
                }
                    );
            }
            else
            {
                switch (pmt)
                {
                    case pogressMsgType.show:
                        panel2.Visible = true;
                        progressBar1.Maximum = value;
                        progressBar1.Value = 0;
                        labelPogress.Text = string.Format("{0:n0}", value) + "  (双击取消下载)";
                        break;
                    case pogressMsgType.progress:
                        //var percent = (int)((value * 100) / progressBar1.Maximum);
                        progressBar1.Value = value;
                        labelPogress.Text = string.Format("{0:n0}", value) + "/"
                            + string.Format("{0:n0}", progressBar1.Maximum) + " (双击取消下载)";
                        break;
                    case pogressMsgType.hide:
                        panel2.Visible = false;
                        break;
                }
            }
        }

        private void showMsg(string msg)
        {
            if (panel2.InvokeRequired)
            {
                labelVdeioUri.BeginInvoke(() => {
                    showMsg(msg);
                }
                );
            }
            else
            {
                labelVdeioUri.Text = msg;
            }
        }

        private void cancelDownload_DoubleClick(object? sender, EventArgs? e)
        {
            if (MessageBox.Show(
                "是否取消当前下载？",
                "取消下载",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)
            == DialogResult.Yes)
            {
                tokenSource?.Cancel();
            }
        }
    }
}