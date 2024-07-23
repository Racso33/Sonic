using System.Xml;

namespace Sonic {
    internal static class Program {
        public static SongDatabase songdb;
        public static MainForm mainForm;
        public static Persistent persistent;
        public static string FfmpegPath;
        public static string YtDlpPath;
        public static string DownloadLocation;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            songdb = new SongDatabase();
            persistent = new Persistent("DB.xml");
            persistent.Load();
            mainForm = new MainForm();
            Application.Run(mainForm);
            persistent.Write();
        }
    }
}