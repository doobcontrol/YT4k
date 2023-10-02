using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoLibrary;
using System.Reflection.Emit;
using com.xiyuansoft.pub.log;
using System.Net.Http;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using VideoLibrary.Exceptions;

namespace YT4k
{
    public partial class UcYtDownloader : UserControl
    {
        public event EventHandler<DownloadStopedEventArgs> DownloadStoped;
        public event EventHandler<ChunkDownloadedEventArgs> ChunkDownloaded;
        public event EventHandler VedioInfoGot;
        private void youTube_ChunkDownloaded(object? sender, ChunkDownloadedEventArgs? e)
        {
            ChunkDownloaded(this, e);
        }

        CancellationTokenSource? tokenSource;
        CancellationToken token;

        string downloadDir = "downloadFile";

        #region 属性

        string vedioUri;
        public string VedioUri { get { return vedioUri; } }

        string saveFile;
        public string SaveFile { get { return saveFile; } }

        int vedioResolution;
        public int VedioResolution { get { return vedioResolution; } }

        string vedioName;
        public string VedioName { get { return vedioName; } }

        long _fileSize;
        public long FileSize { get { return _fileSize; } }

        long totalBytesCopied;
        public long TotalBytesCopied
        {
            get
            {
                if (youTube != null)
                {
                    totalBytesCopied = youTube.totalBytesCopied;
                }
                return totalBytesCopied;
            }
        }

        bool deleteConfig = false;
        public bool DeleteConfig { get { return deleteConfig; } }

        #endregion

        public UcYtDownloader()
        {
            InitializeComponent();

            this.Dock = DockStyle.Top;
            this.BackColor = SystemColors.Control;
            this.BorderStyle= BorderStyle.FixedSingle;

            labelPogress.DoubleClick += cancelDownload_DoubleClick;

            labelVedioUri.Text = "";
            labelMsg.Text = "";
            labelVedioInfo.Text = "";
            labelPogress.Text = "双击取消下载";

            if (!Directory.Exists(Path.Combine(downloadDir, "temp")))
            {
                Directory.CreateDirectory(Path.Combine(downloadDir, "temp"));
            }
        }

        CustomYouTube? youTube;
        public async Task startAsync(string vUri, string savedFile, long startBlock)
        {
            this.vedioUri = vUri;
            labelVedioUri.Text = vUri;

            youTube = new CustomYouTube(); //YouTube.Default; // starting point for YouTube actions
            youTube.ChunkDownloaded += youTube_ChunkDownloaded;
            youTube.dUriGeter += getDownloadUriAsync;

            tokenSource = new CancellationTokenSource();
            token = tokenSource.Token;

            //showPogress(pogressMsgType.show, 0);

            showMsg("读取视频信息……");

            YouTubeVideo? maxResolution;

            try
            {
                maxResolution = await getmaxResolutionVedio();
            }
            catch (UnavailableStreamException e)
            {
                showMsg("视频无效：" + e.Message);
                DownloadStoped(this, new DownloadStopedEventArgs()
                {
                    e = e,
                    Success = false,
                    Canceled = false
                });
                return;
            }

            if (cancelDownloadBeforeCreateItem(startBlock != 0))
            {
                return;
            }

            vedioName = maxResolution.FullName;
            vedioResolution = maxResolution.Resolution;

            string showStr = "  VedioName：" + vedioName;
            showStr += "\r\n  Resolution：" + vedioResolution;
            showVedioInfo(showStr);

            await Task.Run(
                async () => {
                    while (!token.IsCancellationRequested)
                    {
                        long? cLength = null;
                        try
                        {
                            cLength = maxResolution.ContentLength;
                        }
                        catch (Exception e)
                        {
                            FrmMain.log(LogTask.logType_erro, "读取视频长度失败:", e);
                        }

                        if (cLength.HasValue)
                        {
                            _fileSize = cLength.Value;
                            FrmMain.log(LogTask.logType_erro, "视频长度:"+ _fileSize, null);
                            break;
                        }

                        showMsg("读取视频长度失败，重试……");
                        FrmMain.log(LogTask.logType_erro, "读取视频长度失败，重试", null);
                    }
                });

            if (cancelDownloadBeforeCreateItem(startBlock != 0))
            {
                return;
            }

            saveFile = savedFile; 
            if (startBlock == 0)
            {
                saveFile = System.Guid.NewGuid().ToString("N");//下载到临时文件，成功再拷贝  maxResolution.FullName;
                VedioInfoGot(this, null);
            }
            
            showPogress(pogressMsgType.show, _fileSize);
            showPogress(pogressMsgType.progress, startBlock * CustomYouTube.chunkSize);
            
            showMsg("启动视频下载……");
            DownloadStopedEventArgs dsea = new DownloadStopedEventArgs
            {
                Success = true,
                Canceled = false,
                e = null
            };
            _ = Task.Run(
                async () => {
                    bool downloadSucceed = false;
                    try
                    {
                        showMsg("正在下载视频……");
                        downloadSucceed = await youTube
                            .CreateDownloadAsync(
                            new Uri(await getDownloadUriAsync(maxResolution)),
                            Path.Combine(downloadDir, "temp", saveFile),
                            startBlock,
                            _fileSize,
                            new Progress<Tuple<long, long>>((Tuple<long, long> v) =>
                            {
                                showPogress(pogressMsgType.progress, (long)v.Item1);
                            }),
                            token
                            );

                        if (!downloadSucceed)
                        {
                            if (File.Exists(Path.Combine(downloadDir, "temp", saveFile)))
                            {
                                if (deleteConfig)
                                {
                                    File.Delete(Path.Combine(downloadDir, "temp", saveFile));
                                }
                            }
                            showMsg("任务已取消");
                            dsea.Canceled = true;
                        }
                        else
                        {
                            string targetFile = repeatingFileCheck(
                                downloadDir,
                                Path.GetFileNameWithoutExtension(vedioName),
                                Path.GetExtension(vedioName)
                            );
                            File.Move(Path.Combine(downloadDir, "temp", saveFile), targetFile);
                            showMsg("下载成功");
                        }
                        dsea.Success = downloadSucceed;
                    }
                    catch (Exception e)
                    {
                        showMsg("下载失败（" + e.Message + "）");
                        dsea.Success = false;
                        dsea.e = e;
                    }
                    showPogress(pogressMsgType.hide, 0);

                    _ = Task.Run(
                       () =>
                       {
                           DownloadStoped(this, dsea);
                       }
                       );
                }
                );
        }
        private bool cancelDownloadBeforeCreateItem(bool isBakedItem)
        {
            if (token.IsCancellationRequested)
            {
                showMsg("已取消下载"); 
                deleteConfig = isBakedItem; //还未建立下载记录，不用删除(备份的记录，则删除)
                DownloadStoped(this, new DownloadStopedEventArgs()
                {
                    Success = false,
                    Canceled = true
                });
                return true;
            }
            return false;
        }

        public async Task<YouTubeVideo> getmaxResolutionVedio()
        {
            YouTubeVideo maxResolution = null;

            showMsg("读取视频信息……");
            while (maxResolution == null && !token.IsCancellationRequested)
            {
                try
                {
                    IEnumerable<YouTubeVideo> videoInfos = await youTube.GetAllVideosAsync(vedioUri);
                    YouTubeVideo nmaxResolution = videoInfos.First(i => i.Resolution == videoInfos.Max(j => j.Resolution));
                    maxResolution = nmaxResolution;
                }
                catch (UnavailableStreamException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    showMsg("读取视频信息失败，重试……");
                    FrmMain.log(LogTask.logType_erro, "读取视频信息失败，重试", e);
                }
            }

            showMsg("读取视频信息成功");
            return maxResolution;
        }
        public async Task<string> getDownloadUriAsync()
        {
            return await getDownloadUriAsync(null);
        }
        public async Task<string> getDownloadUriAsync(YouTubeVideo YTv)
        {
            YouTubeVideo YTV = YTv;
            if (YTV == null)
            {
                YTV = await getmaxResolutionVedio();
            }

            showMsg("读取视频下载地址……"); //跨线程操作错
            string retUri = null;
            while (retUri == null && !token.IsCancellationRequested)
            {
                try
                {
                    string newUri = YTV.Uri;
                    retUri = newUri;
                }
                catch (Exception e)
                {
                    showMsg("读取视频下载地址失败，重试……");
                    FrmMain.log(LogTask.logType_erro, "读取视频下载地址失败，重试", e);
                }
            }

            showMsg("读取视频下载地址成功，开始下载……");

            return retUri;
        }

        public bool removed = false;
        private void showPogress(pogressMsgType pmt, long value)
        {
            if (removed)
            {
                return;
            }
            if (panelPogress.InvokeRequired)
            {
                try
                {
                    panelPogress.BeginInvoke(
                        () => {
                            showPogress(pmt, value);
                        }
                    );
                }
                catch (InvalidOperationException e)
                {
                    //控件已删除，不处理
                }
            }
            else
            {
                try
                {
                    switch (pmt)
                    {
                        case pogressMsgType.show:
                            labelPogress.Text = ((value == 0) ? ("双击取消下载") : (string.Format("{0:n0}", value))) + "  (双击取消下载)";
                            panelPogress.Visible = true;
                            progressBar1.Maximum = 100;
                            progressBar1.Value = 0;
                            progressBar1.Tag = value;
                            break;
                        case pogressMsgType.progress:
                            labelPogress.Text = string.Format("{0:n0}", value) + "/"
                                + string.Format("{0:n0}", (long)progressBar1.Tag) + " (双击取消下载)";
                            var percent = (int)(value * 100 / (long)progressBar1.Tag);
                            progressBar1.Value = percent;
                            break;
                        case pogressMsgType.hide:
                            //panelPogress.Visible = false;
                            break;
                    }
                }
                catch(Exception e)
                {
                    FrmMain.log(LogTask.logType_erro, 
                        "进度条失败("+ value + "/"+ progressBar1.Tag + ")：", e);
                }
            }
        }

        private void showMsg(string msg)
        {
            if (labelMsg.InvokeRequired)
            {
                labelMsg.BeginInvoke(() => {
                    showMsg(msg);
                }
                );
            }
            else
            {
                labelMsg.Text = msg;
            }
        }
        private void showVedioInfo(string msg)
        {
            if (labelVedioInfo.InvokeRequired)
            {
                labelVedioInfo.BeginInvoke(() => {
                    showVedioInfo(msg);
                }
                );
            }
            else
            {
                labelVedioInfo.Text = msg;
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
                deleteConfig = true;
                CancelDownload();
            }
        }
        public void CancelDownload()
        {
            showMsg("正在取消下载……");
            tokenSource?.Cancel();
        }
        private string repeatingFileCheck(
            string savePath,
            string itemName,
            string fileExt
            )
        {
            string retFile = Path.Combine(savePath,
                itemName + fileExt
                );
            //重名检查
            int fileIndex = 1;
            while (System.IO.File.Exists(retFile))
            {
                retFile = Path.Combine(savePath,
                itemName + "-" + fileIndex + fileExt
                );
                fileIndex++;
            }
            return retFile;
        }
    }
    class CustomHandler
    {
        public HttpMessageHandler GetHandler()
        {
            CookieContainer cookieContainer = new CookieContainer();
            cookieContainer.Add(new Cookie("CONSENT", "YES+cb", "/", "youtube.com"));
            return new HttpClientHandler
            {
                UseCookies = true,
                CookieContainer = cookieContainer
            };

        }
    }
    class CustomYouTube : YouTube
    {
        public event EventHandler<ChunkDownloadedEventArgs> ChunkDownloaded;
        public regetDownloadUri dUriGeter;

        static public long chunkSize = 81920;//10_485_760;
        public long _fileSize = 0L;
        public long totalBytesCopied = 0L;
        private HttpClient _client = new HttpClient();
        protected override HttpClient MakeClient(HttpMessageHandler handler)
        {
            HttpClient retHc = base.MakeClient(handler);
            retHc.Timeout = TimeSpan.FromMinutes(10);
            return retHc;
        }
        protected override HttpMessageHandler MakeHandler()
        {
            return new CustomHandler().GetHandler();
        }
        public async Task<bool> CreateDownloadAsync(
            Uri uri,
            string filePath,
            long breakPoint, //断点块号
            long fileSize,
            IProgress<Tuple<long, long>> progress,
            CancellationToken ct
            )
        {
            Uri workUri = uri;
            _client.Timeout = TimeSpan.FromMinutes(10);
            totalBytesCopied = chunkSize * breakPoint;// 0L;

            _fileSize = fileSize;

            Stream output;
            if (breakPoint != 0)
            {
                output = new FileStream(filePath, FileMode.Append);
            }
            else
            {
                output = File.OpenWrite(filePath);
            }

            using (output)
            {
                //output.
                var segmentCount = (int)Math.Ceiling(1.0 * _fileSize / chunkSize);
                for (var i = breakPoint; i < segmentCount; i++)
                {
                    var from = i * chunkSize;
                    var to = (i + 1) * chunkSize - 1;
                    while (!ct.IsCancellationRequested)
                    {
                        var request = new HttpRequestMessage(HttpMethod.Get, workUri);
                        request.Headers.Range = new RangeHeaderValue(from, to);
                        using (request)
                        {
                            // Download Stream
                            HttpResponseMessage response;

                            try
                            {
                                response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                                response.EnsureSuccessStatusCode();
                            }
                            catch (HttpRequestException e)
                            {
                                if(HttpStatusCode.Forbidden == e.StatusCode)
                                {
                                    FrmMain.log(LogTask.logType_erro, "获取块" + i
                                        + "失败（可能是下载链接失效），重新获取下载链接", null);
                                    workUri = new Uri(await dUriGeter());
                                }
                                else
                                {
                                    FrmMain.log(LogTask.logType_erro, "获取块" + i
                                        + "失败（" + "StatusCode:" + e.StatusCode + "），重试", null);
                                }
                                continue;
                            }
                            catch (Exception e)
                            {
                                FrmMain.log(LogTask.logType_erro, "获取块" + i + "失败，重试", e);
                                continue;
                            }

                            var stream = await response.Content.ReadAsStreamAsync();
                            //File Steam
                            Dictionary<int, byte[]> buffersDic = new Dictionary<int, byte[]>();
                            Dictionary<int, int> byteCountDic = new Dictionary<int, int>();
                            int index = 0;
                            int bytesCopied;
                            int chunkbytes = 0;
                            bool succeedRead = true;
                            do
                            {
                                try
                                {
                                    byte[] buffer = new byte[chunkSize];
                                    bytesCopied = await stream.ReadAsync(buffer, 0, buffer.Length);
                                    buffersDic.Add(index, buffer);
                                    byteCountDic.Add(index, bytesCopied);
                                    chunkbytes += bytesCopied;
                                    index++;
                                }
                                catch (IOException ioe)
                                {
                                    FrmMain.log(LogTask.logType_info, "StatusCode:" + response.StatusCode, null);
                                    FrmMain.log(LogTask.logType_erro, "读块失败，重试", ioe);
                                    succeedRead = false;
                                    break;
                                }
                            } while (bytesCopied > 0 && !ct.IsCancellationRequested);
                            if (succeedRead && !ct.IsCancellationRequested)
                            {
                                if(chunkbytes == chunkSize
                                    || totalBytesCopied + chunkbytes == _fileSize
                                    )
                                {
                                    //磁盘空间
                                    DriveInfo di = new DriveInfo(Directory.GetDirectoryRoot(filePath));

                                    //空间低于100M就禁止写入（或改为公共变量注册申请制？？）
                                    if(di.DriveType != DriveType.Network
                                        && di.TotalFreeSpace < chunkbytes + 100 * 1024 * 1024
                                        )
                                    {
                                        throw new Exception("磁盘已满");
                                    }
                                    else
                                    {
                                        for (int bufferindex = 0; bufferindex < index; bufferindex++)
                                        {
                                            try
                                            {
                                                output.Write(buffersDic[bufferindex], 0, byteCountDic[bufferindex]);
                                            }
                                            catch (Exception e)
                                            {
                                                throw new Exception("写磁盘错误：" + e.Message, e);
                                            }
                                            totalBytesCopied += byteCountDic[bufferindex];
                                            progress.Report(new Tuple<long, long>(totalBytesCopied, _fileSize));
                                        }
                                        ChunkDownloaded(null, new ChunkDownloadedEventArgs() { chuckIndex = i });

                                        break;
                                    }
                                }
                                else
                                {
                                    FrmMain.log(LogTask.logType_info, "StatusCode:" + response.StatusCode, null);
                                    FrmMain.log(LogTask.logType_erro, "块" + i 
                                        + "未读到全部字节（"+ chunkbytes + "/" + chunkSize + "），重试", null);
                                }
                            }
                        }
                    }
                    if (ct.IsCancellationRequested)
                    {
                        break;
                    }
                }
            }
            if (ct.IsCancellationRequested)
            {
                return false;
            }
            if (_fileSize != totalBytesCopied)
            {
                throw new Exception("没有下载到全部内容");
            }
            return true;
        }
        public async Task<long?> GetContentLengthAsync(string requestUri, bool ensureSuccess = true)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Head, requestUri))
            {
                _client.Timeout = TimeSpan.FromMinutes(10);
                var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                if (ensureSuccess)
                    response.EnsureSuccessStatusCode();
                return response.Content.Headers.ContentLength;
            }
        }
    }
    delegate Task<string> regetDownloadUri();
    public class DownloadStopedEventArgs : EventArgs
    {
        public bool Success { get; set; }
        public bool Canceled { get; set; }
        public Exception e { get; set; }
    }

    public class ChunkDownloadedEventArgs : EventArgs
    {
        public long chuckIndex { get; set; }
    }

    enum pogressMsgType { show, progress, hide };
}
