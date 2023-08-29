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
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmVedioList()); //FrmMain
            FrmMain.endLog();
            xConfig.clean();
        }
    }
}