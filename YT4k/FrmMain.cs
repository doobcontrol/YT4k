using com.xiyuansoft.pub.log;
using com.xiyuansoft.xyConfig;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace YT4k
{
    public partial class FrmMain : Form
    {
        static Dictionary<string, UcYtDownloader> downloadingDic 
            = new Dictionary<string, UcYtDownloader>();
        static string ListParName = "yt4kbp";
        static string ListItemNodeIDAttr = "id";
        static string ListItemNodeVListNameAttr = "ln";
        static string ListParName_startBlock = "startBlock";
        static string ListParName_vFile = "vFile";

        static public string downloadDir = "download";
        static public string taskListsDir = "taskLists";

        string appTitle;
        public FrmMain()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.yt4kicon;

            //临时解决方案，避免后续写的时候出被写保护错，导致保存的下载断点不一至（需要在xConfig库解决）
            xConfig.setOnePar("starttime",DateTime.Now.ToString("yyyyMMdd-HHmmss"));

            appTitle = Application.ProductName + "(V" + Application.ProductVersion.ToString() + ") - ";
            Text = appTitle + downloadingDic.Count + "项任务";

            cbCurrVListName.DropDownStyle = ComboBoxStyle.DropDownList;
            toolTip1.SetToolTip(cbCurrVListName, "视频列表");

            nudConcurrent.Minimum = 1;
            nudConcurrent.Maximum = 10; 
            toolTip1.SetToolTip(nudConcurrent, "同时下载数");
            nudConcurrent.Value = int.Parse(xConfig.getOnePar("Concurrent", "1"));
            nudConcurrent.ValueChanged += NudConcurrent_ValueChanged;

            toolTip1.SetToolTip(btnOpenTaskManage, "管理等待下载的任务");
            toolTip1.SetToolTip(btnPasteTask, "直接从剪贴板粘贴并下载");

            panelDownloaderContainer.AutoScroll = true;
            panelDownloaderContainer.BorderStyle = BorderStyle.FixedSingle;

            statusLabelMsg.Text = "";

            statusLabelMsg.Spring = true; //内容过长时不会消失。但会剧中，因此有下行代码
            statusLabelMsg.TextAlign = ContentAlignment.MiddleLeft; 
            
            this.StartPosition = FormStartPosition.Manual;
            getFormPars(this);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Dictionary<string, Dictionary<string, string>> bpList = xConfig.getList(ListParName);
            if (bpList != null)
            {
                foreach (Dictionary<string, string> bpDic in bpList.Values)
                {
                    startDownloadTaskAsync(
                        bpDic[ListItemNodeIDAttr],
                        bpDic[ListItemNodeVListNameAttr],
                        bpDic[ListParName_vFile],
                        long.Parse(bpDic[ListParName_startBlock]) + 1);
                }
            }
            initDownloadTaskList();

            startDownloadTaskFromList();
        }

        private void NudConcurrent_ValueChanged(object? sender, EventArgs e)
        {
            xConfig.setOnePar("Concurrent", nudConcurrent.Value.ToString());

            startDownloadTaskFromList();
        }

        private void btnOpenRecordFileFold_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(downloadDir))
                {
                    Directory.CreateDirectory(downloadDir);
                }
                string windir = Environment.GetEnvironmentVariable("WINDIR");
                System.Diagnostics.Process prc = new System.Diagnostics.Process();
                prc.StartInfo.FileName = windir + @"\explorer.exe";
                prc.StartInfo.Arguments = downloadDir;
                prc.Start();
            }
            catch
            {

            }
        }

        private void btnOpenTaskManage_Click(object sender, EventArgs e)
        {
            //先清剪贴板
            //Because the Clipboard is shared by multiple processes,
            //calling this method may have an impact on those processes.
            Clipboard.Clear();

            new FrmTaskList().ShowDialog();
            resetCurrVListName();

            startDownloadTaskFromList();
        }

        private void btnPasteTask_Click(object sender, EventArgs e)
        {
            string uStr = Clipboard.GetText();
            if (checkYoutubeUri(uStr))
            {
                if (downloadingDic.Count >= nudConcurrent.Value)
                {
                    addOneDownloadTaskItem(uStr.Split("=")[1], cbCurrVListName.Text);
                }
                else
                {
                    startDownloadTaskAsync(uStr, cbCurrVListName.Text);
                }
            }
            else
            {
                statusLabelMsg.Text = "无效地址:请先拷贝youtube视频页面地址再点本按钮";
            }
        }

        static public bool checkYoutubeUri(string uStr)
        {
            string vUrl = uStr;
            if (uStr.IndexOf('&') != -1)
            {
                vUrl = uStr.Split('&')[0];
            }

            if (vUrl.IndexOf("\r") != -1
                || vUrl.IndexOf("\n") != -1
                )
            {
                return false;
            }
            if (!vUrl.StartsWith("http"))
            {
                return false;
            }
            if (vUrl.StartsWith("https://www.youtube.com/watch?v="))
            {
                if (!downloadingDic.ContainsKey(vUrl))
                {
                    return true;
                }
                else
                {
                    //statusLabelMsg.Text = "重复地址:" + vUrl;
                    log(LogTask.logType_info, "重复地址:" + vUrl, null);
                    return false;
                }
            }
            else
            {
                //statusLabelMsg.Text = "非法地址:" + vUrl;
                log(LogTask.logType_info, "非法地址:" + vUrl, null);
                return false;
            }
        }
        private void startDownloadTaskAsync(string uStr, string vListName, string savedFile, long startBlock)
        {
            UcYtDownloader ytDownloderCt = new UcYtDownloader();
            ytDownloderCt.DownloadStoped += UcYtDownloader_DownloadStoped;
            ytDownloderCt.ChunkDownloaded += UcYtDownloader_ChunkDownloaded;
            ytDownloderCt.VedioInfoGot += UcYtDownloader_VedioInfoGot;

            string vUrl = uStr;
            if (uStr.IndexOf('&') != -1)
            {
                vUrl = uStr.Split('&')[0];
            }

            panelDownloaderContainer.Controls.Add(ytDownloderCt);
            downloadingDic.Add(vUrl, ytDownloderCt);

            if (downloadingDic.Count == 1)
            {
                SystemSleepManagement.PreventSleep();
            }

            statusLabelMsg.Text = "任务已添加，总" + downloadingDic.Count + "项";
            Text = appTitle + downloadingDic.Count + "项任务";

            log(LogTask.logType_info, "启动任务（" + downloadingDic.Count + "）：" + vUrl, null);

            _ = ytDownloderCt.startAsync(vUrl, vListName, savedFile, startBlock);
        }
        private void startDownloadTaskAsync(string uStr, string vListName)
        {
            startDownloadTaskAsync(uStr, vListName, null, 0);
        }

        private bool inDownloadTaskFromList = false;

        private void FrmMain_FormClosingAsync(object sender, FormClosingEventArgs e)
        {
            if (downloadingDic.Count > 0)
            {
                if (MessageBox.Show(
                    "未下载完的任务将在下次程序打开时继续下载，是否退出？",
                    "退出确认",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                    ) == DialogResult.Yes)
                {
                    this.ControlBox = false;
                    Text = appTitle + "退出处理中……";
                    statusLabelMsg.Text = "开始退出处理……";
                    log(LogTask.logType_info, "开始退出处理……", null);

                    foreach (UcYtDownloader ytDownloderCt in downloadingDic.Values)
                    {
                        ytDownloderCt.CancelDownload();
                    }

                    Task.Run(() => {
                        while (downloadingDic.Count > 0);
                        this.BeginInvoke(() => Close());
                    }
                    );
                }
                e.Cancel = true;
            }
        }

        #region 下载类事件

        private void UcYtDownloader_DownloadStoped(object? sender, DownloadStopedEventArgs? e)
        {
            bool deleteConfig = false;

            UcYtDownloader senderUcYtDownloader = sender as UcYtDownloader;
            string msg = "";
            if (e.Success)
            {
                msg = "下载成功（"
                    + senderUcYtDownloader.TotalBytesCopied + "/"
                    + senderUcYtDownloader.FileSize + "）" + senderUcYtDownloader.VedioName;
                log(LogTask.logType_info, "下载成功（"
                    + senderUcYtDownloader.TotalBytesCopied + "/"
                    + senderUcYtDownloader.FileSize + "）："
                    + senderUcYtDownloader.VedioName, null);
                deleteConfig = true;
            }
            else
            {
                string vedioName;
                if (senderUcYtDownloader.VedioName != null && senderUcYtDownloader.VedioName != "")
                {
                    vedioName = senderUcYtDownloader.VedioName;
                }
                else
                {
                    vedioName = senderUcYtDownloader.VedioUri;
                }
                if (e.Canceled)
                {
                    msg = "任务已取消（"
                    + senderUcYtDownloader.TotalBytesCopied + "/"
                    + senderUcYtDownloader.FileSize + "）" + vedioName;
                    log(LogTask.logType_info, "任务已取消（"
                    + senderUcYtDownloader.TotalBytesCopied + "/"
                    + senderUcYtDownloader.FileSize + "）" + vedioName + "\r\n"
                    + senderUcYtDownloader.VedioUri, null);

                    deleteConfig = senderUcYtDownloader.DeleteConfig;
                }
                else
                {
                    msg = "下载失败（"
                    + senderUcYtDownloader.TotalBytesCopied + "/"
                    + senderUcYtDownloader.FileSize + "）" + vedioName;
                    string eMsg = "";
                    if (e.e != null)
                    {
                        msg = "下载失败:"+ e.e.Message + "（"
                        + senderUcYtDownloader.TotalBytesCopied + "/"
                        + senderUcYtDownloader.FileSize + "）" + vedioName;
                        eMsg = e.e.Message;
                        eMsg += " - " + e.e.StackTrace;
                    }
                    log(LogTask.logType_info, "下载失败（"
                    + senderUcYtDownloader.TotalBytesCopied + "/"
                    + senderUcYtDownloader.FileSize + "）" + vedioName + "\r\n"
                    + senderUcYtDownloader.VedioUri + "\r\n - " + eMsg, null);
                }
            }

            removeDownloadTask(senderUcYtDownloader, msg);

            if (deleteConfig)
            {
                xConfig.delListPar(ListParName, senderUcYtDownloader.VedioUri);
            }

            //开始关闭程序时写为此标志为false，因此用以判断 是否启动新任务
            if (this.ControlBox)
            {
                startDownloadTaskFromList();
            }
        }
        private void UcYtDownloader_ChunkDownloaded(object? sender, ChunkDownloadedEventArgs? e)
        {
            UcYtDownloader senderUcYtDownloader = sender as UcYtDownloader;

            xConfig.editListPar(
                ListParName,
                senderUcYtDownloader.VedioUri,
                ListParName_startBlock,
                e.chuckIndex.ToString());
        }
        private void UcYtDownloader_VedioInfoGot(object? sender, EventArgs? e)
        {
            UcYtDownloader ytDownloderCt = sender as UcYtDownloader;

            //保存
            Dictionary<string, string> taskPars = new Dictionary<string, string>();
            taskPars.Add(ListItemNodeIDAttr, ytDownloderCt.VedioUri);
            taskPars.Add(ListItemNodeVListNameAttr, ytDownloderCt.VedioListName);
            taskPars.Add(ListParName_startBlock, "-1");
            taskPars.Add(ListParName_vFile, ytDownloderCt.SaveFile);
            xConfig.editListPar(ListParName, taskPars);
        }
       
        private void removeDownloadTask(UcYtDownloader senderUcYtDownloader, string msg)
        {
            senderUcYtDownloader.removed = true;
            if (this.InvokeRequired)
            {
                this.BeginInvoke(
                    () => removeDownloadTask(senderUcYtDownloader, msg)
                    );
            }
            else
            {
                senderUcYtDownloader.DownloadStoped -= UcYtDownloader_DownloadStoped;
                senderUcYtDownloader.ChunkDownloaded -= UcYtDownloader_ChunkDownloaded;
                senderUcYtDownloader.VedioInfoGot -= UcYtDownloader_VedioInfoGot;
                downloadingDic.Remove(senderUcYtDownloader.VedioUri);
                panelDownloaderContainer.Controls.Remove(senderUcYtDownloader);
                
                senderUcYtDownloader.Dispose();

                statusLabelMsg.Text = msg;
                Text = appTitle + downloadingDic.Count + "项任务";

                if (downloadingDic.Count == 0)
                    {
                        SystemSleepManagement.RestoreSleep();
                    }
                }
        }

        #endregion

        #region 任务列表管理

        static public string defaultListName = "defaultList";
        static public Dictionary<string, List<string>>
            DownloadTaskList = new Dictionary<string, List<string>>();

        /// <summary>
        /// 程序启动时加载任务列表
        /// 从配置文件目录中读取列表文件，文件名为列表名，内容为列表项
        /// </summary>
        private void initDownloadTaskList()
        {
            if (!Directory.Exists(taskListsDir))
            {
                Directory.CreateDirectory(taskListsDir);
            }

            string[] vdListArr = Directory.GetFiles(taskListsDir);
            List<string> tList;
            foreach(string vListFile in vdListArr)
            {
                tList = new List<string>();
                foreach (string line in File.ReadLines(vListFile))
                {
                    tList.Add(line);
                }
                DownloadTaskList.Add(Path.GetFileName(vListFile), tList);
                cbCurrVListName.Items.Add(Path.GetFileName(vListFile));
            }

            if (DownloadTaskList.Count == 0)
            {
                DownloadTaskList.Add(defaultListName, new List<string>());
                cbCurrVListName.Items.Add(defaultListName);
            }
        }

        private void addOneDownloadTaskItem(string vID, string vListName)
        {
            List<string> tList = getDownloadTaskList(vListName);
            if (tList.Contains(vID))
            {
                statusLabelMsg.Text = "重复地址:已存在于当前待下载列表";
            }
            else
            {
                tList.Add(vID);
                saveDownloadTaskList(vListName, getDownloadTaskList(vListName));
                statusLabelMsg.Text = "超出最大同时下载数，已加入待下载列表";
            }
        }

        private List<string> getDownloadTaskList(string vListName)
        {
            List<string> tList = DownloadTaskList.GetValueOrDefault(vListName);
            if (tList == null)
            {
                tList = new List<string>();
                DownloadTaskList.Add(vListName, tList);
                cbCurrVListName.Items.Add(vListName);
            }
            return tList;
        }

        static public void saveDownloadTaskList(string vListName, List<string> tList)
        {
            if (tList.Count > 0)
            {
                StringBuilder taskListstr = new StringBuilder();
                foreach (string tItem in tList)
                {
                    taskListstr.Append(tItem + System.Environment.NewLine);
                }
                File.WriteAllText(Path.Combine(taskListsDir, vListName), taskListstr.ToString());
            }
            else
            {
                if(File.Exists(Path.Combine(taskListsDir, vListName)))
                {
                    File.Delete(Path.Combine(taskListsDir, vListName));
                }
            }
        }

        private void startDownloadTaskFromList()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(
                    () => startDownloadTaskFromList()
                    );
            }
            else
            {
                if (!inDownloadTaskFromList)
                {
                    inDownloadTaskFromList = true;

                    while (
                        downloadingDic.Count < nudConcurrent.Value
                        && DownloadTaskList.Count > 0
                        )
                    {
                        //磁盘空间
                        DriveInfo di = new DriveInfo(Directory.GetDirectoryRoot(downloadDir));
                        //空间低于100M就禁止写入（或改为公共变量注册申请制？？）
                        if (di.DriveType != DriveType.Network
                            && di.TotalFreeSpace < 1L * 1024 * 1024 * 1024
                            )
                        {
                            statusLabelMsg.Text = "磁盘空间低于1G，不能启动下载";
                            break;
                        }

                        string vListName = DownloadTaskList.Keys.First();
                        List<string> fList = DownloadTaskList[vListName];
                        if (fList.Count > 0)
                        {
                            string vID= fList.First();
                            string uStr = "https://www.youtube.com/watch?v=" + vID;
                            startDownloadTaskAsync(uStr, vListName);
                            fList.Remove(vID);
                        }
                        else
                        {
                            DownloadTaskList.Remove(vListName);
                        }
                        saveDownloadTaskList(vListName, fList);
                    }

                    //若全部完成，增加一个默认列表
                    if (DownloadTaskList.Count == 0)
                    {
                        DownloadTaskList.Add(defaultListName, new List<string>());
                        cbCurrVListName.Items.Add(defaultListName);
                    }

                    //重置默认列表选择
                    resetCurrVListName();

                    inDownloadTaskFromList = false;
                }
            }
        }

        private void resetCurrVListName()
        {
            string oName = cbCurrVListName.Text;
            cbCurrVListName.Items.Clear();
            foreach (string lName in DownloadTaskList.Keys)
            {
                cbCurrVListName.Items.Add(lName);
            }
            if (cbCurrVListName.Items.Contains(oName))
            {
                cbCurrVListName.Text = oName;
            }
            else
            {
                cbCurrVListName.Text = DownloadTaskList.Keys.First();
            }
        }

        #endregion

        #region 日志

        private static IXYLogger xyLogger;
        public static void initLog()
        {
            xyLogger = new XYFileLogger();
            xyLogger.initLog(new Dictionary<string, string>() {
            {"logDir","log/"},
            {"logFileName","log"}
            });
            log(LogTask.logType_info, " 程序启动（V"+ Application.ProductVersion.ToString() + "）", null);
        }
        public static void endLog()
        {
            if (xyLogger != null)
            {
                log(LogTask.logType_info, " 退出程序" + "\r\n", null);
                xyLogger.stopLog(null);
            }
        }
        public static void log(string logType, string logInfo, Exception? logErro)
        {
            if (
                logInfo == null
                || logInfo == ""
                )
            {
                return;
            }

            if (xyLogger != null)
            {
                LogTask lt = new LogTask();
                lt.LogType = logType;
                lt.LogInfo = logInfo;
                lt.LogError = logErro;
                lt.LogTime = DateTime.Now;
                xyLogger.log(lt);
            }
        }

        #endregion

        #region 保存和恢复窗体参数（位置，大小等）

        static public string strFormParsTableName = "formpars";
        static public string formStartPosition = "StartPosition";
        static public string formLocationX = "LocationX";
        static public string formLocationY = "LocationY";
        static public string formWindowState = "FormWindowState";
        static public string formWidth = "formWidth";
        static public string formHeight = "formHeight";

        static public void getFormPars(Form form)
        {
            getFormPars(form, true, true);
        }
        static public void getFormPars(Form form, bool getSize, bool getLocate)
        {
            string rowName = form.Name;
            Dictionary<string, string> parsDic = xConfig.getTabledRowPars(strFormParsTableName, rowName);

            if (parsDic != null)
            {
                if (getLocate && parsDic.ContainsKey(formLocationX))
                {
                    form.Location = new System.Drawing.Point(
                    int.Parse(parsDic[formLocationX]),
                    int.Parse(parsDic[formLocationY]));
                }

                if (getSize && parsDic.ContainsKey(formWidth))
                {
                    form.Width = int.Parse(parsDic[formWidth]);
                    form.Height = int.Parse(parsDic[formHeight]);
                }

                if (parsDic.ContainsKey(formWindowState))
                {
                    FormWindowState fws = (FormWindowState)
                        Enum.Parse(
                            typeof(FormWindowState), parsDic[formWindowState]);
                    form.WindowState = fws;
                }
            }

            if (getLocate)
            {
                form.LocationChanged += form_LocationChanged;
            }
            if (getSize)
            {
                form.Resize += form_Resize;
            }
        }

        static private void form_LocationChanged(object sender, EventArgs e)
        {
            Form form = sender as Form;
            if (form.WindowState == FormWindowState.Normal)
            {
                Dictionary<string, string> parsDic = new Dictionary<string, string>();
                parsDic.Add(formLocationX, form.Location.X.ToString());
                parsDic.Add(formLocationY, form.Location.Y.ToString());
                xConfig.editTabledParsRow(strFormParsTableName, form.Name, parsDic); //暂不支持同对象多窗体？？
            }
        }

        static private void form_Resize(object sender, EventArgs e)
        {
            Form form = sender as Form;
            Dictionary<string, string> parsDic = new Dictionary<string, string>();

            parsDic.Add(formWindowState, form.WindowState.ToString());
            if (form.WindowState == FormWindowState.Normal)
            {
                parsDic.Add(formWidth, form.Width.ToString());
                parsDic.Add(formHeight, form.Height.ToString());
            }

            xConfig.editTabledParsRow(strFormParsTableName, form.Name, parsDic);
        }

        #endregion
    }
    class ClipboardMonitor
    {
        IntPtr nextClipboardViewer;
        public event EventHandler ClipboardMsgHandler;

        private string _clipboardString;
        public string ClipboardString { get { return _clipboardString; } }

        /// <summary>
        /// 要处理的 WindowsSystem.Windows.Forms.Message。
        /// </summary>
        /// <param name="m"></param>
        public bool WndProc(ref Message m)
        {
            // defined in winuser.h
            const int WM_DRAWCLIPBOARD = 0x308;
            const int WM_CHANGECBCHAIN = 0x030D;

            bool msgDone = false;

            switch (m.Msg)
            {
                case WM_DRAWCLIPBOARD:
                    DisplayClipboardData();
                    SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam); 
                    msgDone = true;
                    break;
                case WM_CHANGECBCHAIN:
                    if (m.WParam == nextClipboardViewer)
                        nextClipboardViewer = m.LParam;
                    else
                        SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
                    msgDone = true;
                    break;
                default:
                    //base.WndProc(ref m);
                    break;
            }
            return msgDone;
        }
        /// <summary>
        /// 显示剪贴板内容
        /// </summary>
        public void DisplayClipboardData()
        {
            try
            {
                IDataObject iData = new DataObject();
                iData = Clipboard.GetDataObject();

                //只处理纯文本内容
                if (iData.GetDataPresent(DataFormats.Text))
                {
                    _clipboardString = (string)iData.GetData(DataFormats.Text);
                    ClipboardMsgHandler(this, null);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void changeMonitorStatus(bool inClipboardMonitor, IntPtr Handle)
        {
            if (inClipboardMonitor)
            {
                startMonitor(Handle);
            }
            else
            {
                stopMonitor(Handle);
            }
        }
        /// <summary>
        /// 停止监视,从观察链移除
        /// </summary>
        public void stopMonitor(IntPtr Handle)
        {
            ChangeClipboardChain(Handle, nextClipboardViewer);
        }
        /// <summary>
        /// 开始监视,从观察链移除
        /// </summary>
        public void startMonitor(IntPtr Handle)
        {
            nextClipboardViewer = (IntPtr)SetClipboardViewer((int)Handle);
        }

        #region WindowsAPI
        /// <summary>
        /// 将CWnd加入一个窗口链,每当剪贴板的内容发生变化时,就会通知这些窗口
        /// </summary>
        /// <param name="hWndNewViewer">句柄</param>
        /// <returns>返回剪贴板观察器链中下一个窗口的句柄</returns>
        [DllImport("User32.dll")]
        protected static extern int SetClipboardViewer(int hWndNewViewer);

        /// <summary>
        /// 从剪贴板链中移出的窗口句柄
        /// </summary>
        /// <param name="hWndRemove">从剪贴板链中移出的窗口句柄</param>
        /// <param name="hWndNewNext">hWndRemove的下一个在剪贴板链中的窗口句柄</param>
        /// <returns>如果成功,非零;否则为0。</returns>
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

        /// <summary>
        /// 将指定的消息发送到一个或多个窗口
        /// </summary>
        /// <param name="hwnd">其窗口程序将接收消息的窗口的句柄</param>
        /// <param name="wMsg">指定被发送的消息</param>
        /// <param name="wParam">指定附加的消息特定信息</param>
        /// <param name="lParam">指定附加的消息特定信息</param>
        /// <returns>消息处理的结果</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);
        #endregion

    }
}
