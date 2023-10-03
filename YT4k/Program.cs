using com.xiyuansoft.pub.log;
using com.xiyuansoft.xyConfig;

namespace YT4k
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            FrmMain.initLog();

            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmMain());
            FrmMain.endLog();
            xConfig.clean();
        }

        #region 线程错误处理

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            FrmMain.log(LogTask.logType_erro, "应用程序错误", e.Exception);
            MessageBox.Show("应用程序错误。请查看日志");
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            FrmMain.log(LogTask.logType_erro, "CurrentDomain错误", e.ExceptionObject as Exception);
            MessageBox.Show("应用程序(CurrentDomain)错误。请查看日志");
        }

        #endregion
    }
}