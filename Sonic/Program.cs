using System.Xml;

namespace Sonic {
    internal static class Program {
        public static SongDatabase songdb;
        public static MainForm mainForm;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            songdb = new SongDatabase();
            songdb.LoadSongDatabase("C:\\Users\\oscar\\Documents\\Programs\\Music\\SongDb.xml");
            mainForm = new MainForm();
            Application.Run(mainForm);
        }
    }
}