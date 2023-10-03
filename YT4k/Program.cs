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

        #region �̴߳�����

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            FrmMain.log(LogTask.logType_erro, "Ӧ�ó������", e.Exception);
            MessageBox.Show("Ӧ�ó��������鿴��־");
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            FrmMain.log(LogTask.logType_erro, "CurrentDomain����", e.ExceptionObject as Exception);
            MessageBox.Show("Ӧ�ó���(CurrentDomain)������鿴��־");
        }

        #endregion
    }
}